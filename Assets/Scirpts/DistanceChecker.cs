using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public GameObject RayCastShooter;
    public vehicleAiController VAIC;
    public Rigidbody rb;
    public float xVelocity;
    public IEnumerator Wait() //just in case
    {
        yield return new WaitForSecondsRealtime(2);
    }

    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("Car");
        LayerMask Redlight = LayerMask.GetMask("RedLight"); // Future support for red lights
        LayerMask Pedestrian = LayerMask.GetMask("Pedestrian");
        RaycastHit hit;
        xVelocity = rb.velocity.magnitude;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 6.5f, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            VAIC.totalPower = (xVelocity >= 0.15f) ? Mathf.Lerp(0, -500f, 1) : -0f; // ? Means then , : means else
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4, Color.white);
            
            VAIC.totalPower = 35f;
        }
        //Red Light yield
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.5f, Redlight))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            VAIC.totalPower = (xVelocity >= 0.15f) ? Mathf.Lerp(0, -550f, 1) : 0f; // ? Means then , : means else;
        }
        // pedestrian yield
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 6.5f, Pedestrian))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            VAIC.totalPower = (xVelocity >= 0.15f) ? Mathf.Lerp(0, -550f, 1) : 0f; // ? Means then , : means else;
        }
    }




}



