using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotGun : Gun
{

    public AudioSource gunShot;

    public float nextFire = 0f;

    public float fireRate = 1f;

    [SerializeField] Camera cam;
    public override void Use()
    {
        if (Time.time > nextFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFire = Time.time + fireRate;

        AudioSource gunShot = GetComponent<AudioSource>();

        gunShot.Play();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
        }
    }
}
