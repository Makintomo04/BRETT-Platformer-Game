using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueClose : MonoBehaviour
{
    public GameObject obj;
    public GameObject Dia;
    public GameObject SpatialUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            obj.SetActive(false);
            Dia.SetActive(false);
            SpatialUI.SetActive(false);
        }

    }
}
