using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10f;    
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitFx;

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
           Shoot();
       }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }


    private void ProcessRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            print(hit.transform.name);
            
            processHitFX(hit);

            EnemyHelth target = hit.transform.GetComponent<EnemyHelth>();
            if (target)
            {
                target.hitPointsDecresser(weaponDamage);
            }

        }
        else
        {
            return;
        }
    }

    private void processHitFX(RaycastHit hit)
    {
       GameObject impact = Instantiate (hitFx, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 2f);
    }
}
