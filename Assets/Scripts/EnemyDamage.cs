using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float pushBackForce;
    public GameObject pH;

    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        pH.GetComponent<PlayerHealth>();
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    }
       void OnTriggerStay2D(Collider2D collision)
        {
            if (pH.GetComponent<PlayerHealth>().currentHealth>0 && collision.tag == "Player" && nextDamage<Time.time)
            {
                PlayerHealth pH = collision.gameObject.GetComponent<PlayerHealth>();
                pH.takeDamage(damage);
                nextDamage = Time.time + damageRate;
                pushBack(collision.transform);
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
