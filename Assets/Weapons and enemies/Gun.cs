using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("======Weapon Stats======")]
    public float damage = 25f;
    public float range = 100f;

    [Range(0f, 10f)]public float ammo = 10f;
    public float maxAmmo = 10f;
    public float fireRate = 1f;
    private float nextFire = 0f;

    [Space(30)]
    public Camera fpsCam;

    [Tooltip("If the box is checked, the TeamOneEnemy script needs to be on the enemies. Otherwise, use TeamTwoEnemy.")]
    public bool isTeamOne = true;

    private AudioSource mAudioSrc;



    public static bool isWeaponTwo = false;

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }



    void Update()
    { 
    
            if(isWeaponTwo == true)

            {  //activate shots
                    if(Input.GetButtonDown("Fire1") && ammo > 0 && Time.time > nextFire)
                    {

                         // mAudioSrc.Play();    
                          Shoot();
                          ammo -= 1;
                    }

                    if(Input.GetButtonDown("Reload") && ammo != maxAmmo )
                    {
                         Reload();
                    }
            }

     else

     {
         if(Input.GetButtonDown("Weapon2"))
         {
             isWeaponTwo = true;
             AutoGun.isWeaponOne = false;
         }
     }
    }

    void Shoot()
    {
            //when clicking on something - shoot weapon
            nextFire = Time.time + fireRate;

            RaycastHit hit;
           if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
           {
               Debug.Log(hit.transform.name);
                
                if(isTeamOne == true)
                {

                //Hit an enemy if you are team one

               TeamOneEnemy targetOne = hit.transform.GetComponent<TeamOneEnemy>();
               if (targetOne != null)
               {
                   targetOne.TakeDamage(damage);
               }
            }
                //Hit an enemy as team two
                     else
                     {
                         TeamTwoEnemy targetTwo = hit.transform.GetComponent<TeamTwoEnemy>();
                         if(targetTwo != null)
                         {
                             targetTwo.TakeDamage(damage);
                         }
                    }
           }
    }

    void Reload()
    {
        ammo = maxAmmo;
    }
}
