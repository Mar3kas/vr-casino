using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform boneTransform;
    public bool isSpinning = false;
    public bool startSpin = false;

    public float decelaration = 50f;
    public float initialRotationSpeed = 0f;

    private GameObject instantiatedBall;

    // Update is called once per frame
    void Update()
    {
        if (!isSpinning && startSpin)
        {
            spinWheel();
        }
    }

    private void FixedUpdate()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.forward, initialRotationSpeed * Time.fixedDeltaTime);
            boneTransform.Rotate(Vector3.forward, initialRotationSpeed * Time.fixedDeltaTime);
            initialRotationSpeed -= decelaration * Time.fixedDeltaTime;
            if (initialRotationSpeed <= 0f)
            {
                isSpinning = false;
                startSpin = false;
                initialRotationSpeed = 0f;
            }
        }
    }

    private void spinWheel()
    {
        if (instantiatedBall != null)
        {
            Destroy(instantiatedBall);
        }
        isSpinning = true;
        initialRotationSpeed = 720f;
        instantiatedBall = Instantiate(ballPrefab, new Vector3(-7.039f, 2.774f, 15.7959f), ballPrefab.transform.rotation);
        Rigidbody ballRigidbody = instantiatedBall.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(Vector3.left, ForceMode.Impulse);
    }
}
