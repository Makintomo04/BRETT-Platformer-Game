using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    float lowY;
    float lowX;
    [SerializeField]float highY = 20f;
    [SerializeField] float highX = 192f;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        lowY = transform.position.y;
        lowX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 camPos = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);
            if (transform.position.y < lowY)
            {
                transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
            }
            if (transform.position.x < lowX)
            {
                transform.position = new Vector3(lowX, transform.position.y, transform.position.z);
            }
            if(transform.position.y> highY)
            {
                transform.position = new Vector3(transform.position.x, highY, transform.position.z);
            }
            if(transform.position.x > highX)
            {
                transform.position = new Vector3(highX,transform.position.y, transform.position.z);
            }


        }
    }
}
