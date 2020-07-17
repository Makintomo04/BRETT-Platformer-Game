using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    public GameObject gm;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(WinActions());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WinActions()
    {
        GameManager.instance.Win();
          yield return new WaitForSeconds(5f);
        gm.GetComponent<GameManager>().LoadNextScene();
    }
}
