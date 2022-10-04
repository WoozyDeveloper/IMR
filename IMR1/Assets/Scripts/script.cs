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
        StartCoroutine(MyCoroutine());
        
    }

    IEnumerator MyCoroutine()
    {
        
        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(touch.position, hits))
        {
            Pose pose = hits[0].pose;
            Instantiate(model, pose.position, Quaternion.Euler(.0f, .0f, .0f));
            yield return new WaitForSeconds(2);
        }
    }

   /* bool isPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
            return false;
        PointerEventData data = new PointerEventData(EventSystem.current);
        data.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        return results.Count > 0;
    }*/
}
