using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class PlayerSpawn : NetworkBehaviour
{   
    [SerializeField]
    GameObject playerprefab;

    Vector3 spawnPosition;
    Quaternion spawnRotation;
    public GameObject[] disableafterQue;
    public GameObject[] enableafterQue;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    public void Awake()
    {
        spawnPosition = new Vector3(UnityEngine.Random.Range(-8.0f, 8.0f), 0.0f, UnityEngine.Random.Range(-8.0f, 8.0f));
        spawnRotation = Quaternion.Euler(0.0f, UnityEngine.Random.Range(0.0f, 180.0f), 0);
       
    }

    public void AfterQueOverFn()
    {
        for (int i = 0; i < disableafterQue.Length; i++)
        {
            disableafterQue[i].SetActive(false);
        }

        if (isLocalPlayer)
        {
            for (int i = 0; i < enableafterQue.Length; i++)
            {
                enableafterQue[i].SetActive(true);
            }
        }

    }

    public void Spawn(string address)
    {
        Cmdspawns(address);
    }

    [Command]
    void Cmdspawns(string address)
    {

        /*

        //if player name(address) is already spawned return(to avoid multiple person with same wallet).
        GameObject[] CurrentPlayers = GameObject.FindGameObjectsWithTag("Player"); //find all players currently spawned in server
        foreach (GameObject currplayer in CurrentPlayers)
        {
            if (address.Equals(currplayer.name, StringComparison.InvariantCultureIgnoreCase)) 
            {
                Debug.Log("WalletID already connected, multiple id");
                return;
            }
        }

    */


            GameObject player = (GameObject)Instantiate(playerprefab, spawnPosition, spawnRotation);
            GameObject owner = this.gameObject;
            NetworkServer.SpawnWithClientAuthority(player, owner);
            player.name = address;
            //player.name = "debug";
    }
}
