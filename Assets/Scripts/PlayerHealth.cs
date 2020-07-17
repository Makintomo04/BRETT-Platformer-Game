using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool isGrounded;
    public float fullHealth = 50f;
    public float currentHealth;
    player player;
    Animator myAnim;
    bool isDead = false;
    public Sprite[] healthSprites;
    public Sprite fullHealthSprite;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip deathSound;
    public int healthDeduction;
    public GameObject imageObj;
    public GameObject gameManager;
    AudioSource myAudioSource;
    HealthPack hp;
    //public GameObject heartUp;
    public Slider healthSlider;
    void Start()
    {
        
        currentHealth = fullHealth;
        myAnim = GetComponent<Animator>();
        player = GetComponent<player>();
        hp = GetComponent<HealthPack>();
        myAudioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = fullHealth;
        healthSlider.minValue = 0f;
        healthSlider.value = currentHealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //resetHealthSprite();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    /*public void resetHealthSprite()
    {
        if (heartUp.GetComponent<HealthPack>().hasHealthPack == true)
        {
            healthDeduction*=0;
            heartUp.GetComponent<HealthPack>().hasHealthPack = false;
        }
    }*/
    public void takeDamage(float damage)
    {
        if (healthDeduction <= healthSprites.Length)
        {
            healthDeduction++;
        }
        if (damage <= 0)
        {
            return;
        }
           // ShowNextHealthSprite();
        
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        Coroutine flash;
        flash =  StartCoroutine(Flash());
        
        if(player != null && currentHealth > 0)
        {
            AudioClip clip = hurtSound;
            myAudioSource.PlayOneShot(clip);  
        }
      
      
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            AudioClip clip = deathSound;
            myAudioSource.PlayOneShot(clip);
            player.GetComponent<player>().isDead = true;
            StartCoroutine(Death(this.gameObject));
            StartCoroutine(Wait());
            
        }
    }
    
    IEnumerator Flash() { 
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }
        IEnumerator Wait() {
        yield return new WaitForSeconds(1.2f);
        gameManager.GetComponent<GameManager>().RestartScene();
    }
    IEnumerator Death(GameObject player)
    {

        yield return new WaitForSeconds(0.2f);
        myAnim.SetTrigger("Death");
            yield return new WaitForSeconds(1.2f);
            Destroy(player);
            isDead = true;
        
           
            

            Debug.Log("GAME OVER!");
            yield return new WaitForSeconds(1.2f);
        
            //timerIsStopped = true;
            yield break;

        
    }
    /*public void ShowNextHealthSprite()
    {
        
            int spriteIndex = healthDeduction - 1;
        
            if (spriteIndex <= healthSprites.Length - 1)
            {
                if (healthSprites[spriteIndex] != null)
                {
                    imageObj.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[spriteIndex];

                }
            }

    }*/
    
    }
