﻿using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class Shoot : MonoBehaviour
{
    GestureRecognizer recognizer;
    public float ForceMagnitude = 5000f;

    AudioSource audioSource = null;
    AudioClip shootClip = null;

    // Use this for initialization
    void Start()
    {
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += ShootBall;
        recognizer.StartCapturingGestures();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 20f;

        shootClip = Resources.Load<AudioClip>("Footstep04");
    }

    private void ShootBall(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // create a ball/spehere to shoot
        ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // resize the ball
        var rigidBody = ball.AddComponent<Rigidbody>();
        // make tha ball adhere to gravity
        rigidBody.mass = 0.5f;
        // make the nall a little floaty, like a beer pong ball
        rigidBody.position = transform.position;
        // set the ball at the curret position
        var transformForward = transform.forward;
        // set the shoot angle
        transformForward = Quaternion.AngleAxis(0, transform.right) * transformForward;
        // shoot !!
        rigidBody.AddForce(transformForward * ForceMagnitude);

        audioSource.clip = shootClip;
        audioSource.Play();
    }

    public void OnShoot()
    {
        ShootBall(InteractionSourceKind.Voice, 1, new Ray());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
