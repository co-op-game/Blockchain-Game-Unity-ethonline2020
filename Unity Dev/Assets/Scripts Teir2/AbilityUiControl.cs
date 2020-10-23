using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AbilityUiControl : NetworkBehaviour
{

    [SyncVar] decimal prizepool;
    public Text prizepoolvalueUI;
    public void AbilityFundPool(decimal abilityfunds)
    {
        prizepool = abilityfunds;
        updateprizepool();

    }
    void OnChangesprizepool(decimal prizepool)
    {
        prizepoolvalueUI.text = prizepool.ToString();
    }

    public void updateprizepool()
    {
        RpcUIvarUpdate(prizepool.ToString());
    }

    [ClientRpc]
    public void RpcUIvarUpdate(string prizepool)
    {
        GameObject cc = GameObject.Find("ClientCall");
        ClientCall clientcall = cc.GetComponent<ClientCall>();
        clientcall.przepoolui(prizepool);
    }
}
