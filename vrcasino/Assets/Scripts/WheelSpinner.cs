using UnityEngine;

public class WheelSpinner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform boneTransform;
    public bool isSpinning = false;
    public bool finishedSpinning = false;
    public string winningCell = "";
    public LayerMask layerMask;

    public float decelaration = 50f;
    public float initialRotationSpeed = 0f;

    private GameObject instantiatedBall;

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
                finishedSpinning = true;
                initialRotationSpeed = 0f;
            }
        }
    }

    public void spinWheel()
    {
        if (!isSpinning)
        {
            if (instantiatedBall != null)
            {
                Destroy(instantiatedBall);
            }

            isSpinning = true;
            initialRotationSpeed = 720f;
            instantiatedBall = Instantiate(ballPrefab, new Vector3(-6.841f, 2.774f, 15.7959f), ballPrefab.transform.rotation);
            Rigidbody ballRigidbody = instantiatedBall.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(Vector3.left, ForceMode.Impulse);
        }
    }
}
