using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float fullHealth = 100f;
    public float currentHealth;
    Animator myAnim;
    Enemy enemy;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        myAnim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage)
    {
        
        if (damage <= 0)
        {
            return;
        }
        // ShowNextHealthSprite();

        currentHealth -= damage;
        
        Coroutine flash;
        flash = StartCoroutine(Flash());

        


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
            StartCoroutine(Death(this.gameObject));
            

        }
    }
    IEnumerator Flash()
    {
        enemy.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator Death(GameObject enemy)
    {

        yield return new WaitForSeconds(0.2f);
        
        
        Destroy(enemy);
        




        Debug.Log("You Win!");
        yield return new WaitForSeconds(1.2f);

        //timerIsStopped = true;
        yield break;


    }
}
