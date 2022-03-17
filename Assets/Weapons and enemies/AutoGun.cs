using UnityEngine;

public class AutoGun : MonoBehaviour
{
   
    public float damage = 25f;
    public float range = 100f;

    public float ammo = 10f;
    public float maxAmmo = 10f;

    public Camera fpsCam;

    public bool isTeamOne = true;

    public float fireRate = 1f;
    private float nextFire = 0f;

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
