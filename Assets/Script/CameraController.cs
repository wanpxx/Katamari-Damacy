using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float somoothing = 0.5f;
    Vector3 offset;


    void Start()
    {
        offset =  target.position  - transform.position;
    }
    void LateUpdate() {

        transform.position = Vector3.Lerp(transform.position, target.position - offset, somoothing);
        //transform.position = target.position - offset ;

    }
}
