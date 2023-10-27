using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    private WheelSpinner wheelSpinner;
    // Start is called before the first frame update
    void Start()
    {
        wheelSpinner = GameObject.Find("Wheel").GetComponent<WheelSpinner>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("WinningCell") && wheelSpinner.finishedSpinning)
        {
            wheelSpinner.winningCell = other.gameObject.name;
        }
    }
}
