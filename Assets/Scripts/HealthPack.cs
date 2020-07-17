using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject heartUI;
    public bool hasHealthPack;
    PlayerHealth pH;
    // Start is called before the first frame update
    void Start()
    {
        pH = GetComponent<PlayerHealth>();
        hasHealthPack = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            hasHealthPack = true;
            player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().fullHealth;
            player.GetComponent<PlayerHealth>().healthSlider.value = player.GetComponent<PlayerHealth>().currentHealth;
            //heartUI.GetComponent<UnityEngine.UI.Image>().sprite = player.GetComponent<PlayerHealth>().fullHealthSprite;
            //pH.resetHealthSprite();
            StartCoroutine(Disappear(gameObject));
        }
        
    }
    IEnumerator Disappear(GameObject obj)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(obj);
    }
    void HealthUp()
    {
        player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().fullHealth;
    }
}
