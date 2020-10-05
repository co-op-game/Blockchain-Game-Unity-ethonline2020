using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Abilities : NetworkBehaviour
{
    [SyncVar(hook = "OnAddressChange")] public string address = "not_set";
    [SyncVar] public float abilityvalue = 0;

    private void Start()
    {
        address = this.name;
    }
    void OnAddressChange(string address)
    {
        Debug.Log("Debugonclientsideaddress");
        Debug.Log(address);
    }


}
