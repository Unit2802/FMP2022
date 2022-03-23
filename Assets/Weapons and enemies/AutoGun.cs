using UnityEngine;

public class AutoGun : MonoBehaviour
{
    [Header("======Weapon Stats======")]
    public float damage = 25f;
    public float range = 100f;

    [Range(0f, 50f)]public float ammo = 50f;
    public float maxAmmo = 10f;

    public float fireRate = 1f;
    private float nextFire = 0f;

    [Space(30)]
    public Camera fpsCam;

    [Tooltip("If the box is checked, the TeamOneEnemy script needs to be on the enemies. Otherwise, use TeamTwoEnemy.")]
    public bool isTeamOne = true;



    public static bool isWeaponOne = true;

    void Update()
      {   

            if(isWeaponOne == true)

     {

    

          if(Input.GetButton("Fire1") && ammo > 0 && Time.time > nextFire)
          {
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
        if(Input.GetButtonDown("Weapon1"))
        {
            isWeaponOne = true;
            Gun.isWeaponTwo = false;
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
