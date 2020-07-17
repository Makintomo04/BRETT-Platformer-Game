using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue1 : MonoBehaviour
{
    public GameObject Dia1;
    public GameObject obj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obj.SetActive(true);
            Dia1.SetActive(true);
        }
        
    }
}
