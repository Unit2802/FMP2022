using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public float xSense = 30f;
    public float ySense = 30f;



    public static RoomManager Instance;

    void Awake()
    {
        if(Instance) //checks if another instance of the room manager exists
        {
            Destroy(gameObject); //destroys it if there is, there can only be one
            return;
        }
        DontDestroyOnLoad(gameObject); //Makes sure it is the only room manager that exists 
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable(); 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }

    

    
}
