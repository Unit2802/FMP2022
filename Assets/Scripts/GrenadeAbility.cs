using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class GrenadeAbility : Ability
{
    
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    AbilityHolder ab;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    void Start()
    {
       

     
    }

    void Update()
    {
      
        
    }


    public override void Activate(GameObject parent)
    {
        
    }


}
