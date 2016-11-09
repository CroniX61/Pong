using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour
{
    
    public Rigidbody rigidbody;
    public float InputForceScale = 40.0f;
    private AudioSource audioSource;
    public AudioClip WallSound;
    public AudioClip PaddleSound;

    // Use this for initialization
    void Start()
    {
        Vector3 force =
            Quaternion.Euler((int)UnityEngine.Random.Range(-60, 60), 0, 0) *
            Vector3.right;
        force = force * InputForceScale;

        rigidbody.AddForce(force);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= 14f)
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject =
            collision.gameObject;

        if (gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(WallSound);
        }
        else if (gameObject.CompareTag("Pl1") || gameObject.CompareTag("Pl2"))
        {
            
            audioSource.PlayOneShot(PaddleSound);
        }
    }
}