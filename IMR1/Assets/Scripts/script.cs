using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;


public class script : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;

    public GameObject model;


    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.GetMouseButtonDown(0) && raycastManager.Raycast(touch.position, hits))
        {
            Pose pose = hits[0].pose;
            Instantiate(model, pose.position, Quaternion.Euler(.0f, .0f, .0f));
        }
    }

}
