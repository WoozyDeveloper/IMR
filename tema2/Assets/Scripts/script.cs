using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class script : MonoBehaviour
{
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Intru");
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics characteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(characteristics,devices);
        Debug.Log(devices.Count);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Intru");
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        Debug.Log(devices.Count);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
    }
}
