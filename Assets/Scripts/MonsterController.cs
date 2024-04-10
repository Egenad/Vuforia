using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour{

    public Camera cam;
    public NavMeshAgent agent;

    private bool isPressed = false;

    private Vector3 pos = Vector3.zero;

    private AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
                Ray ray = cam.ScreenPointToRay(pos);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit)) {
                    agent.SetDestination(hit.point);
                }
            }
    }

    void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "Point"){
            other.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
}
