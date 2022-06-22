using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 2000f;
    [SerializeField] float rotateAmount = 300f;

    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem leftEnginePS;
    [SerializeField] ParticleSystem rigthEnginePS;
    [SerializeField] ParticleSystem mainEnginePS;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRigth();
        }
        else
        {
            StopRotation();
        }
    }


    void StartThrusting()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
        if (!mainEnginePS.isPlaying)
        {
            mainEnginePS.Play();
        }

        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
    }

    void StopThrusting()
    {
        mainEnginePS.Stop();
        audioSource.Stop();
    }

    

    

    void RotateLeft()
    {
        if (!rigthEnginePS.isPlaying) rigthEnginePS.Play();

        ApplyRotation(rotateAmount);
    }

    void RotateRigth()
    {
        if (!leftEnginePS.isPlaying) leftEnginePS.Play();

        ApplyRotation(-rotateAmount);
    }

    void StopRotation()
    {
        rigthEnginePS.Stop();
        leftEnginePS.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
