using UnityEngine;

public class UroshNewGun : MonoBehaviour
{
    Transform cam;
    CPMPlayer player;

    public GameObject round;

    public Transform launchOrigin;

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

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<CPMPlayer>();

        }
    }

    void Update()
    {
        cam = player.playerView;
 
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
        Debug.Log("Shooting");
        nextFire = Time.time + (1 / fireRate);

        gunShot.Play();

        //  shots.Play();

        GameObject projectile = Instantiate(round, launchOrigin.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        // Calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - launchOrigin.position).normalized;
        }

        // Add force
        Vector3 forceToAdd = cam.transform.forward * bulletTravelSpeed;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

    }

    void ReloadTrigger()
    {
        ammo = maxAmmo;
    }

}
