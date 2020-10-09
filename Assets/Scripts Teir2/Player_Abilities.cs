using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Abilities : NetworkBehaviour
{
    [SyncVar(hook = "OnAddressChange")] public string address = "not_set";
    [SyncVar(hook = "Onvaluechange")] public float abilityvalue = 0;

    private void Start()
    {
        address = this.name;
    }
    void OnAddressChange(string address)
    {
        Debug.Log("Debugonclientsideaddress");
        Debug.Log(address);
    }

    void Onvaluechange(float abilityvalue)
    {
        Debug.Log(abilityvalue);
    }

}
