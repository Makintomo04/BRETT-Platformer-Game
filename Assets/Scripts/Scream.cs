using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    [SerializeField] AudioClip screamSound;
    AudioSource myAudioSource;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.tag == "Player")
        {
            AudioClip clip = screamSound;
            myAudioSource.PlayOneShot(clip);
        }
    }
}
