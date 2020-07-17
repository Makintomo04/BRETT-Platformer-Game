using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;
 
 void Awake()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
