using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
       if (Input.GetMouseButton(0))
       {
           Shoot();
       }
    }

    private void Shoot()
    {           
        RaycastHit hit;
       
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print(hit.transform.name);
        }
        else
        {
            return;
        }
    }
}
