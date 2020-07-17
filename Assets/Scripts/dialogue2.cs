using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue2 : MonoBehaviour
{
    public GameObject Dia1;
    public GameObject Dia2;
    public GameObject SpatialUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dia1.SetActive(false);
            Dia2.SetActive(true);
            SpatialUI.SetActive(true);
        }

    }
}
