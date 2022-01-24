using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private float startTime, spawnTime;
    public float initialSpawnTime;
    public float spawnOffset, spawnPositionOffset;
    GameObject cameraComp;
    private float cameraXNow, cameraXBefore;

    private void Start()
    {
        //Se encuentra el componente cámara y se obtiene su posición en X
        cameraComp = GameObject.Find("PlayerCam");
        cameraXBefore = cameraComp.transform.position.x;

        //Se obtiene el singleton del ObjectPooler
        objectPooler = ObjectPooler.SharedInstance;

        //El tiempo de spawn variará según el initialSpawnTime y +- su spawnOffset
        startTime = Time.time;
        spawnTime = Random.Range(initialSpawnTime - spawnOffset, initialSpawnTime + spawnOffset);
    }

    private void Update()
    {
        //Si es momento de spawnear un objeto
        if ((Time.time - startTime) > spawnTime)
        {
            //Se le otorga un valor random de offset en Y para el Spawn del objeto a partir de la posición del Spawner 
            float offset = Random.Range(-spawnPositionOffset, spawnPositionOffset);
            Vector3 offsetVector = new Vector3(0.0f, offset, 0.0f);

            //Con un 50% de probabilidades se generarán sillas o mesas con la posición generada de manera aleatoria
            if ((Random.Range(1, 10) % 2) == 0)
            {
                ObjectPooler.SharedInstance.SpawnFromPool("Chair", transform.position + offsetVector);
            }
            else
            {
                ObjectPooler.SharedInstance.SpawnFromPool("Table", transform.position + offsetVector);
            }

            //Se resetea el SpawnTime de nuevo
            startTime = Time.time;
            spawnTime = Random.Range(initialSpawnTime - spawnOffset, initialSpawnTime + spawnOffset);
        }

        //Mover el Spawn lo mismo que se mueva la cámara para que siempre esté a la derecha de la misma fuera de plano
        cameraXNow = cameraComp.transform.position.x;
        if (cameraXNow != cameraXBefore)
        {
            Vector3 offset = new Vector3((cameraXNow - cameraXBefore), 0.0f, 0.0f);
            this.transform.position += offset;
            cameraXBefore = cameraXNow;
        }
    }
}
