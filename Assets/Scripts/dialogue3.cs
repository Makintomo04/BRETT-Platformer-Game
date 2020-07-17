using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue3 : MonoBehaviour
{
    public GameObject Dia2;
    public GameObject Dia3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dia2.SetActive(false);
            Dia3.SetActive(true);
        }

    }
}
