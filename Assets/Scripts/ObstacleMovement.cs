using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour, IPooledObject
{
    public float baseSpeed = 5.0f;
    public float speedOffset = 3.0f;
    private float speed;
    public bool hasCollided;

    //Función obligatoria de la interfaz para setear ciertos valores en el momento del Spawn
    public void OnObjectSpawn()
    {
        speed = Random.Range(baseSpeed - speedOffset, baseSpeed + speedOffset);
        hasCollided = false;
        this.transform.Translate(new Vector2(-1.0f, 0.0f) * baseSpeed * Time.deltaTime, Space.World);
    }

    //Función de movimiento simple siempre en la misma dirección
    private void LateUpdate()
    {
        this.transform.Translate(new Vector2(-1.0f, 0.0f) * speed * Time.deltaTime, Space.World);
    }
}
