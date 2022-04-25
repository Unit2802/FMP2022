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
    CPMPlayer player;
    

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    AbilityHolder ab;
    KeyCode throwKey;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;


    public override void Activate(GameObject parent)
    {
        readyToThrow = true;

        if (ab == null)
        {
            ab = GameObject.Find("PlayerController").GetComponent<AbilityHolder>();
        }
        if (player == null)
        {
            player = GameObject.Find("PlayerController").GetComponent<CPMPlayer>();
           
        }


        throwKey = ab.key;
        cam = player.playerView;



        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }

    }

    private void Throw()
    {
        readyToThrow = false;

        // Instantiate the object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Get rigidbody component
        Rigidbody projectilerb = projectile.GetComponent<Rigidbody>();

        // Add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + objectToThrow.transform.up * throwUpwardForce;
    }

}
