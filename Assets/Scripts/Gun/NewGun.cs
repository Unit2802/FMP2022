using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGun : MonoBehaviour
{
    public GameObject round;

    public GameObject launchOrigin;

    public float ammo = 10;

    public float maxAmmo;

    public float bulletTravelSpeed;

    public float fireRate = 1;
    public float nextFire = 0;

    public AudioSource gunShot;

    public ParticleSystem shots;

    public bool isWeaponOne; //Crossbow
    public bool isWeaponTwo; //Machine Gun
    public bool isWeaponThree; //Shotgun

    //Player team

    public static bool isTeamOne = false;
    public static bool isTeamTwo = false;

    public bool isReloading = false;

    void Update()
    {

 
        if (Input.GetButtonDown("Fire1") && ammo > 0 && Time.time > nextFire && isReloading == false)
        {
            Shoot();
            
        }

        if(Input.GetButtonDown("Reload"))
        {
            ReloadTrigger();
        }

        if(ammo == 0)
        {
            ReloadTrigger();
        }


    }

    void Shoot()
    {
        nextFire = Time.time + (1 / fireRate);

        gunShot.Play();

        shots.Play();

        GameObject spawnedRound = Instantiate(
        round,
        launchOrigin.transform.position + launchOrigin.transform.forward,
        transform.rotation
               );

        spawnedRound.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, bulletTravelSpeed));
    }

    void ReloadTrigger()
    {
        isReloading = true;
        
    }
}
