using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float parallaxEffect;
    GameObject cameraComp;
    private float length, startpos;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cameraComp = GameObject.Find("PlayerCam");
    }

    void Update()
    {
        //Realizar el movimiento parallax relativo al valor de Parallax Effect que tenga cada fondo
        float temp = cameraComp.transform.position.x * (1 - parallaxEffect);
        float dist = cameraComp.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        //Mover los fondos si se salen de plano
        if(temp > (startpos + length))
        {
            startpos += length;
        }
        else if(temp < (startpos - length))
        {
            startpos -= length;
        }
    }
}
