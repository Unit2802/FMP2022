using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GrenadeAbility : MonoBehaviour
{
    public static GrenadeAbility Instance;


    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    CPMPlayer player;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;
    public KeyCode throwKey;
    

    bool readyToThrow;

    private void Start()
    {
        Instance = this;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<CPMPlayer>();

        }
    }
    private void Update()
    {
        readyToThrow = true;
        cam = player.playerView;



        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }

        //Debug.Log(totalThrows);


    }

    private void Throw()
    {
        readyToThrow = false;

        // Instantiate the object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectile.GetComponent<ProjectileAddon>().player = gameObject;

        // Calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // Add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // Implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
        

    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }


    

}
