using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartClickPrefab : NetworkBehaviour
{
    GameObject startquestart;
    ClientServerStartUIConnection clientServerStartUI;

    void Start()
    {
        if(!isServer)
        { 
            Debug.Log("notserver"); return;
        }

        startquestart = GameObject.Find("Start : QueStart");
        clientServerStartUI = startquestart.GetComponent<ClientServerStartUIConnection>();
        clientServerStartUI.StartOnServer();
        Destroy(this.gameObject, 5f);
    }

}
