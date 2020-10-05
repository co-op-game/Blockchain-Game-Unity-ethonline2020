using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Webhook between game and html interface for web3 - connect to wallet. 
public class JavascriptHook : NetworkBehaviour
{
    public PlayerSpawn playerspawn;
    private bool spawned;

    public Text AddressUI;
    public Text AddressUIinGame;


    [SyncVar]string address;
    void Start()
    {
        spawned = false;
        address = null;
    }

    public void WebHookSpawn(string recievedaddress) //called from frontend webgl html.
    {
        if (this.isLocalPlayer)
        {
                address = recievedaddress;
                Debug.Log("Connected:");
                Debug.Log(recievedaddress);
                AddressUI.text = address;
                AddressUIinGame.text = address;
        }
    }

    [ClientRpc]
    public void RpcGameStartSpawn()
    {
        if (this.isLocalPlayer)
        {
            if (spawned == !true)
            {
                if (address != null) //check if wallet is connected /came through webhookspawn>^ //enable in live environment.
                {
                    playerspawn.Spawn(address);
                    spawned = true;
                }
                Debug.Log("NULL Adress ID");
            }
        }
        playerspawn.AfterQueOverFn();

    }


        //below for debugging only. 
        void Update()
        {
            if (this.isLocalPlayer)
            {
                if (spawned == !true)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerspawn.Spawn(address);
                        spawned = true;
                    }
                }
            }  

        }
}   
