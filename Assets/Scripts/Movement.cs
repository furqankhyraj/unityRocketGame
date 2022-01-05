using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem rocketBottomThrust;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;

    AudioSource audioSource;

    bool isAlive;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rocketBottomThrust.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }


            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            leftThrust.Play();
            ApplyRotation(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rightThrust.Play();
            ApplyRotation(-rotateThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //for manually rotation when there is obstacles
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
