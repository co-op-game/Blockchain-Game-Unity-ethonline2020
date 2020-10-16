using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class AbilityUiControl : NetworkBehaviour
{

    [SyncVar] decimal prizepool;
    public Text prizepoolvalueUI;


    public Text prevgamewinner;
    public Text prevgameAmount;

    [SyncVar]string prevwinner = "xxxxxxxxxxxxxxxx";
    [SyncVar]string prevpool ="0";


    public void AbilityFundPool(decimal abilityfunds)
    {
        prizepool = abilityfunds;

    }
    void OnChangesprizepool(decimal prizepool)
    {
        prizepoolvalueUI.text = prizepool.ToString();
    }

    public void updateprizepool()
    {
        RpcUIvarUpdate(prizepool.ToString());
    }

   // [ClientRpc]
    public void RpcUIvarUpdate(string prizepool)
    {
        GameObject cc = GameObject.Find("ClientCall");
        ClientCall clientcall = cc.GetComponent<ClientCall>();
        clientcall.przepoolui(prizepool);
    }


    /// ////////////////////////////////////////////////////////////// 


  //  [Command] //this call tree is always happening on server only since gamescenecontrol.cs.
    public void PreviousGamewinnerUiUpdate(string winner, string amount)
    {
        prevwinner = winner; //called on server 
        prevpool = amount;
        RpcPreviousGamewinnerUiUpdate(prevwinner, prevpool);
    }

    [ClientRpc]
    public void RpcPreviousGamewinnerUiUpdate(string winner, string amount)
    {
        prevgamewinner.text = winner;
        prevgameAmount.text = amount;
    }
}
