using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelection : MonoBehaviour
{
    public float players;
    public static bool isSelectingTeam = true;

    public GameObject teamSelectionOne;
    public GameObject teamSelectionTwo;


    public GameObject player;


    void Update()
    {
        if(Input.GetButtonDown("SelectTeam"))
        {
            isSelectingTeam = true;
        }

        if (isSelectingTeam == true)
        {


            if (Input.GetButtonDown("TeamOne"))
            {
                Debug.Log("TeamOne");
                isSelectingTeam = false;

                player.AddComponent<Enemies>();

                NewGun.isTeamOne = true;

                }

            if (Input.GetButtonDown("TeamTwo"))
            {
                Debug.Log("TeamTwo");
                isSelectingTeam = false;

                player.AddComponent<Enemies>();

                NewGun.isTeamTwo = true;
            }
        }

        if(isSelectingTeam == false)
        {
            teamSelectionOne.SetActive(false);
            teamSelectionTwo.SetActive(false);
        }
    }
    
}
