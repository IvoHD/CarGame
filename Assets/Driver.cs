using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 220;
    [SerializeField] public float MoveSpeed = 10.5f;
    [SerializeField] public float SlowSpeed = 7.5f;
    [SerializeField] public float BoostSpeed = 18.5f;
    float SteerAmount;
    float MoveAmount;

    // Update is called once per frame
    void Update()
    {
        MoveAmount = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        SteerAmount = 0;                        //Stops spinning after stop
        if (Input.GetAxis("Vertical") != 0)     //if car isn't standing still
            SteerAmount = Input.GetAxis("Horizontal") * SteerSpeed * Time.deltaTime;

        transform.Translate(0, MoveAmount, 0);
        transform.Rotate(0, 0, -SteerAmount);
    }



    
}
