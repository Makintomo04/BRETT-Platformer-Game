using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public float playerSpeed = 15f;
    Rigidbody2D myRB;
    Animator myAnim;
    BossHealth bH;
    bool isGrounded;
    bool facingRight;
    public float movement = 0f;
    public float jumpHeight = 300f;
    public float groundCheckRadius = 0.1f;
    public float Strength;
    public LayerMask groundLayer;
    public Transform groundCheck;
    AudioSource myAudioSource;
    [SerializeField] AudioClip moveSound;
    [SerializeField] AudioClip jumpSound;
    public GameObject cam2;


    PlayerHealth pH;
   // float damage = 10f;
    public bool isDead;
    float startBoundary = -37.98866f;
    float secondaryStartBoundary = 110.43f;

    // Start is called before the first frame update
    void Start()
    {
        
        pH = GetComponent<PlayerHealth>();
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        isDead = false;
        facingRight = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * playerSpeed;
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetTrigger("Jump");
            myRB.AddForce((Vector2.up * jumpHeight)*Time.fixedDeltaTime);


        }
    }
    private void FixedUpdate()
    {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetFloat("speed", Mathf.Abs(movement));
            if (isDead==true)
            {
            movement = 0;
            myRB.velocity = new Vector2(movement, 0);

        }
         
            myRB.velocity = new Vector2(movement * Time.fixedDeltaTime , myRB.velocity.y);
            if (movement > 0 && !facingRight)
            {
                FlipPlayer();
            }
            else if (movement < 0 && facingRight)
            {
                FlipPlayer();
            }
            if (transform.position.x < startBoundary)
            {
                transform.position = new Vector3(startBoundary, transform.position.y, transform.position.z);
            }

        if (SceneManager.GetActiveScene().buildIndex ==2 && cam2.activeSelf && transform.position.x < secondaryStartBoundary)
        {
          
             transform.position = new Vector3(secondaryStartBoundary, transform.position.y, transform.position.z);
        }
        
    }
    private void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void Attack()
    {

        myAnim.SetTrigger("Attack");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Attack();
            bH.takeDamage(Strength);
            
        }
    }

}
