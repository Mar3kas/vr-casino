using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RouletteStartButton : MonoBehaviour
{
    private WheelSpinner wheelSpinner;
    // Start is called before the first frame update
    void Start()
    {
        wheelSpinner = GameObject.Find("Wheel").GetComponent<WheelSpinner>();
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => wheelSpinner.spinWheel());
    }
}
