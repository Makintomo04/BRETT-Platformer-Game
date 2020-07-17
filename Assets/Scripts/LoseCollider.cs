using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Sprite[] deathSprite;
    public GameObject imageObj;
    public GameObject gameManager;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().currentHealth = 0f;
            player.GetComponent<PlayerHealth>().healthSlider.value = player.GetComponent<PlayerHealth>().currentHealth;
            imageObj.GetComponent<UnityEngine.UI.Image>().sprite = deathSprite[0];
            StartCoroutine(Restart());
           

        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.2f);
        gameManager.GetComponent<GameManager>().RestartScene();
    }

}