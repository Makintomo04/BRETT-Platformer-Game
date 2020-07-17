using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer : MonoBehaviour
{
    [SerializeField] AudioClip cheerSound;
    AudioSource myAudioSource;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            AudioClip clip = cheerSound;
            myAudioSource.PlayOneShot(clip);
        }
    }
}
