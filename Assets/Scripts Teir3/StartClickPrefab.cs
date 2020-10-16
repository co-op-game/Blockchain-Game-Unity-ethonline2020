using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartClickPrefab : NetworkBehaviour
{
    GameObject startquestart;
    ClientServerStartUIConnection clientServerStartUI;

    void Start() //this is spawned on server if any client clicks start, then on server only all tx processing /ability setup happens
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
