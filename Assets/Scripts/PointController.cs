using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public GameObject point;

    private bool isPressed = false;

    private Vector3 pos = Vector3.zero;

    public Camera camera;


    // Update is called once per frame
    void Update()
    {
        if(point != null){
            #if UNITY_EDITOR || UNITY_STANDALONE
                if(Input.GetMouseButtonDown(0)) {
                    Debug.Log("GetMouseButtonDown");
                    isPressed = true;
                    pos = Input.mousePosition;
                }
            #elif UNITY_IOS || UNITY_ANDROID
                Touch t = Input.GetTouch(0);
                if((t.phase == TouchPhase.Stationary) || (t.phase == TouchPhase.Moved && t.deltaPosition.magnitude < 1.5f)) {
                    Debug.Log("GetTouch");
                    isPressed = true;
                    pos = t.position;
                }
            #endif
                if(isPressed) {
                    Ray ray = camera.ScreenPointToRay(pos);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit)) {
                        point.SetActive(true);
                        point.transform.position = new Vector3(hit.point.x, 0f, hit.point.z);
                    }
                    isPressed = false;
                }
        }
    }
}
