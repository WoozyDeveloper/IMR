using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Active: " + XRSettings.isDeviceActive);
        Debug.Log("Name: " + XRSettings.loadedDeviceName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
