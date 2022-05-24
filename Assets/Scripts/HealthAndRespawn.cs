using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthAndRespawn : MonoBehaviourPunCallbacks, IPunObservable
{
    Renderer[] visuals;

    public int health = 100;

    public Transform spawnPoint;

    public AudioSource damage25;

    public AudioSource damage50;

    public AudioSource extraDamage;

    public AudioSource killPlayer;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
        }
    }

        public void TakeDamage(int damage)
    {
        health -= damage;

        if(damage <= 25)
        {
            damage25.Play();
        }

        if (damage <= 50 && damage > 25)
        {
            damage50.Play();
        }

        if(damage <= 100 && damage > 50)
        {
            extraDamage.Play();
        }

        if(health <= 0)
        {
            killPlayer.Play();
        }
    }

    IEnumerator Respawn()
    {
        SetRenderers(false);
        health = 100;
        GetComponent<CharacterController>().enabled = false;
        //transform.position = spawnPoint.transform.position;
        transform.position = new Vector3(68, 9, 39);
        yield return new WaitForSeconds(3);
        SetRenderers(true);
        GetComponent<CharacterController>().enabled = true;

    }

    void SetRenderers(bool state)
    {
        foreach (var renderer in visuals)
        {
            renderer.enabled = state;
        }    
    }


    void Start()
    {
        visuals = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        if(health <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

}