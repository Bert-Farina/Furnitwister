using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Clase Pool que contiene los datos para cada pool de objetos
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //Singleton para llamar a la clase desde el spawner
    public static ObjectPooler SharedInstance;
    private void Awake()
    {
        SharedInstance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    //Al iniciar se recorren los pools creados en el inspector y se preinstancian sus Game Objects y se añaden a su correspondiente cola
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            GameObject tmp;
            for (int i = 0; i < pool.size; i++)
            {
                tmp = Instantiate(pool.prefab);
                tmp.SetActive(false);
                objectPool.Enqueue(tmp);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //Función que se llama desde el Spawner para genera uno de los objetos del Pool con el tag correspondiente en la posición indicada.
    public GameObject SpawnFromPool(string tag, Vector2 position)
    {
        //Si el diccionario de colas no contiene ese tag devuelve null
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        //Asigna la posición del objeto a la que se pasa a la función y se le da una rotación aleatoria en Z
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        objectToSpawn.SetActive(true);

        //Se llama a la función OnObjectSpawn si el objeto tiene implementada esa interfaz
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        //Se vuelve a encolar el objeto para ser llamado de nuevo
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
