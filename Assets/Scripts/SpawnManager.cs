using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public int nextPlayersTeam;

    public Spawnpoint[] spawnpointsTeamOne, spawnpointsTeamTwo;
    

    private void Awake()
    {
        Instance = this;
       
    }

    public Transform GetSpawnpoint()
    {
        return spawnpointsTeamOne[Random.Range(0, spawnpointsTeamOne.Length)].transform;
        
    }

    public Transform GetSpawnpointTeamTwo()
    {
        return spawnpointsTeamTwo[Random.Range(0, spawnpointsTeamTwo.Length)].transform;
    }

    public void UpdateTeam()
    {
        if(nextPlayersTeam == 1)
        {
            nextPlayersTeam = 2;
        }
        else
        {
            nextPlayersTeam = 1;
        }
    }

}
