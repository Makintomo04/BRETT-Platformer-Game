using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   
    public GameObject pH;
    
    Animator myAnim;
    [SerializeField] float damage;
    public float damageRate;
    public float pushBackForce;
    float nextDamage;
    //
    public float distance = 0.5f;
    public float speed;
    public bool movingRight = false;
    public Transform groundCheck;
    public Transform playerCheck;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    bool isAttacking = false;
    public float fullHealth = 100f;
    public float currentHealth;
    public Slider healthBar;
    bool isDead = false;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        healthBar.maxValue = currentHealth;
        healthBar.minValue = 0f;
        healthBar.value = currentHealth;
        
        myAnim = GetComponent<Animator>();
        pH.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bc2d in myColliders) bc2d.enabled = false;
            StartCoroutine(Death(this.gameObject));
            GameManager.instance.WinGame();
        }
        if (currentHealth < 100)
        {
            speed = 12f;
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.left, 0.1f, groundLayer);
        if (groundInfo&& isDead==false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        RaycastHit2D playerInfo = Physics2D.Raycast(groundCheck.position, Vector2.left, 0.1f, playerLayer);
        if (playerInfo)
        {
            
            StartCoroutine(Attack());

        }
    IEnumerator Attack()
        {
            myAnim.SetBool("isInCloseProximity", true);
            isAttacking = true;
            yield return new WaitForSeconds(0.5f);
            
            myAnim.SetBool("isInCloseProximity", false);
            isAttacking = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isAttacking == true)
        {
            PlayerHealth pH = collision.gameObject.GetComponent<PlayerHealth>();
            pH.takeDamage(damage);
            nextDamage = Time.time + damageRate;
        }
       
    }
    public void takeDamage(float damage)
    {
        healthBar.gameObject.SetActive(true);
        currentHealth -= damage;
        healthBar.value = currentHealth;
        Coroutine flash;
        flash = StartCoroutine(Flash());
    }
    IEnumerator Flash()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    IEnumerator Death(GameObject enemy)
    {
        
        yield return new WaitForSeconds(0.2f);
        speed = 0;
        transform.Translate(Vector2.zero);
        myAnim.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        Destroy(enemy);
        isDead = true;
        Debug.Log("You Win!");
        yield return new WaitForSeconds(1.2f);
        yield break;


    }
}
