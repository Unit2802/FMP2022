using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{

    PhotonView PV;

    GameObject controller;

    public int myTeam;


    void Awake()
    {
       PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
            if (PV.IsMine)
            {
                PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);
            }
        
    }

    // Update is called once per frame
    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        Transform spawnpointTeamTwo = SpawnManager.Instance.GetSpawnpointTeamTwo();
        if (myTeam == 1)
        {
            controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        }
        else
        {
            controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpointTeamTwo.position, spawnpointTeamTwo.rotation, 0, new object[] { PV.ViewID });
        }
    }

    

    private void Update()
    {
        if (controller == null && myTeam != 0)
        {
            if (myTeam == 1)
            {
                Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
                if (PV.IsMine)
                {
                    controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
                }
            }
            else
            {
                Transform spawnpointTeamTwo = SpawnManager.Instance.GetSpawnpointTeamTwo();
                if (PV.IsMine)
                {
                    controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpointTeamTwo.position, spawnpointTeamTwo.rotation, 0, new object[] { PV.ViewID });
                }
            }
        }
    }



    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }

    [PunRPC]
    void RPC_GetTeam()
    {
        myTeam = SpawnManager.Instance.nextPlayersTeam;
        SpawnManager.Instance.UpdateTeam();
        PV.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);

    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        myTeam = whichTeam;
    }
}
