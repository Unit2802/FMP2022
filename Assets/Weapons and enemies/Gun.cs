using UnityEngine;

public class Gun : MonoBehaviour
{
 

    public bool isWeaponTwo = false;
  
    [Header("======Weapon One Stats======")]
    public float weaponOneDamage = 25f;
    public float weaponOneRange = 100f;

    [Range(0f, 50f)] public float weaponOneAmmo = 50f;
    public float weaponOneMaxAmmo = 10f;

    public float weaponOneFireRate = 1f;
    private float weaponOneNextFire = 0f;

    [Space(30)]

    [Header("======Weapon Two Stats======")]
  
    public float weaponTwoDamage = 25f;
    public float weaponTwoRange = 100f;

    [Range(0f, 50f)]public float weaponTwoAmmo = 10f;
    public float weaponTwoMaxAmmo = 10f;
    public float weaponTwoFireRate = 1f;
    private float weaponTwoNextFire = 0f;

    [Space(30)]
    public Camera fpsCam;

    [Tooltip("If the box is checked, the TeamOneEnemy script needs to be on the enemies. Otherwise, use TeamTwoEnemy.")]
    public bool isTeamOne = true;

    private AudioSource mAudioSrc;





    public bool isWeaponOne = true;
    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }



    void Update()
    { 
    
            if(isWeaponTwo == true)

            {  //activate shots
                    if(Input.GetButtonDown("Fire1") && weaponTwoAmmo > 0 && Time.time > weaponTwoNextFire)
                    {

                         // mAudioSrc.Play();    
                          weaponTwoShoot();
                          weaponTwoAmmo -= 1;
                    }

                    if(Input.GetButtonDown("Reload") && weaponTwoAmmo != weaponTwoMaxAmmo )
                    {
                         WeaponTwoReload();
                    }
            }

     else

     {
         if(Input.GetButtonDown("Weapon2"))
         {
             isWeaponTwo = true;
             isWeaponOne = false;
         }
     }

        if (isWeaponOne == true)

        {



            if (Input.GetButton("Fire1") && weaponOneAmmo > 0 && Time.time > weaponOneNextFire)
            {
                WeaponOneShoot();
                weaponOneAmmo -= 1;
            }

            if (Input.GetButtonDown("Reload") && weaponOneAmmo != weaponOneMaxAmmo)
            {
                WeaponOneReload();
            }
        }

        else
        {
            if (Input.GetButtonDown("Weapon1"))
            {
                isWeaponOne = true;
                isWeaponTwo = false;
            }
        }
    }

    void weaponTwoShoot()
    {
            //when clicking on something - shoot weapon
            weaponTwoNextFire = Time.time + weaponTwoFireRate;

            RaycastHit hit;
           if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weaponTwoRange))
           {
               Debug.Log(hit.transform.name);
                
                if(isTeamOne == true)
                {

                //Hit an enemy if you are team one

               TeamOneEnemy targetOne = hit.transform.GetComponent<TeamOneEnemy>();
               if (targetOne != null)
               {
                   targetOne.TakeDamage(weaponTwoDamage);
               }
            }
                //Hit an enemy as team two
                     else
                     {
                         TeamTwoEnemy targetTwo = hit.transform.GetComponent<TeamTwoEnemy>();
                         if(targetTwo != null)
                         {
                             targetTwo.TakeDamage(weaponTwoDamage);
                         }
                    }
           }
    }

    void WeaponTwoReload()
    {
        weaponTwoAmmo = weaponTwoMaxAmmo;
    }
 
    void WeaponOneShoot()
    {
        //when clicking on something - shoot weapon
        weaponOneNextFire = Time.time + weaponOneFireRate;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weaponOneRange))
        {
            Debug.Log(hit.transform.name);

            if (isTeamOne == true)
            {

                //Hit an enemy if you are team one

                TeamOneEnemy targetOne = hit.transform.GetComponent<TeamOneEnemy>();
                if (targetOne != null)
                {
                    targetOne.TakeDamage(weaponOneDamage);
                }
            }
            //Hit an enemy as team two
            else
            {
                TeamTwoEnemy targetTwo = hit.transform.GetComponent<TeamTwoEnemy>();
                if (targetTwo != null)
                {
                    targetTwo.TakeDamage(weaponOneDamage);
                }
            }
        }
    }

    void WeaponOneReload()
    {
        weaponOneAmmo = weaponOneMaxAmmo;
    }
}
