using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Sprite[] bounceSprites;
    public float pushBackForce;
    int bounceNo;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool isGrounded;
    [SerializeField] AudioClip bounceSound;
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded == false)
        {
            ShowFirstHitSprite();
        }
    }
    private void FixedUpdate()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        bounceNo++;
        if (collision.tag == "Player")
        {
            pushBack(collision.transform);
            AudioClip clip = bounceSound;
            myAudioSource.PlayOneShot(clip);
            ShowNextHitSprite();
            
        }
     
    }
    private void ShowFirstHitSprite()
    {
        int spriteIndex = 0;
        if (bounceSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = bounceSprites[spriteIndex];

        }
    }
        private void ShowNextHitSprite()
    {
        int spriteIndex = 1;
        if (bounceSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = bounceSprites[spriteIndex];

        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
        
    }
    private void pushBack(Transform pushObj)
    {
        Vector2 pushDirection = new Vector2(0f, 1f).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushObj.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
