using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;

    private int actualPoint = 1;
    private float t = 0f;
    private readonly float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;
        
        if(actualPoint == 1){
            moveToPoint(point1, point2);
        }else{
            moveToPoint(point2, point1);
        }
    }

    private void moveToPoint(GameObject origin, GameObject destination){
        
        transform.position = Vector3.Lerp(origin.transform.position, destination.transform.position, t);
        
        if (t >= 1f){
            t = 0f;
            
            if(actualPoint == 1) actualPoint++;
            else actualPoint--;
        }
    }
}
