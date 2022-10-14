using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blastoff : MonoBehaviour
{
    float mainThrust = 2.6f;
    float rotationThrust = 90f;

    Rigidbody myRigidbody;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RocketMovement();
    }

    private void RocketMovement()
    {

        Thrusting();
        Rotating(rotationThrust);

    }

    private void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
            myRigidbody.AddRelativeForce(Vector3.up * mainThrust);
        }
        else
        {
            myAudioSource.Stop();
        }
    }

    private void Rotating(float rotationThrust)
    {
        myRigidbody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationThrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        }

        myRigidbody.freezeRotation = false;
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
