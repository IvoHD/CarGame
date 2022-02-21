using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera postion same as car position
public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject Car;
    void LateUpdate()
    {
        transform.position = Car.transform.position + new Vector3 (0,0,-5.5f);
    }    
}
