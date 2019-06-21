using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void hitPointsDecresser(float weaponDamage)
    {   
        hitPoints -= weaponDamage;
        
        if (hitPoints <= 0 )
        {
            Destroy(gameObject);
        }
        print(hitPoints);
    }
}
