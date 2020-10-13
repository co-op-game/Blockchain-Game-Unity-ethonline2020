using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PrizeMaster : NetworkBehaviour
{

    public AbilityUiControl abiltyuicontrol;
    public EtherTransferCoroutinesUnityWebRequest ethtransfer;

    public Text prevgamewinner;
    public Text prevgameAmount;

    public decimal prizepool; //This Rounds total Ability Funds.
    string winner;
    void Start()
    {
        prizepool = 0;
    }


    public void AbilityFunds(decimal txvalue)
    {   
        txvalue = txvalue / 1000000000000000000; // Wei to ether
        prizepool = prizepool + txvalue;
        abiltyuicontrol.AbilityFundPool(prizepool);
        Debug.Log(prizepool);
       //debug SendAbiltyFunds("0x025ababef744c64a679f9b29d9c3a94f3e53d4e6");
    }

    [Command]
    public void CmdSendAbiltyFunds(string winnername)
    {
        if (!isServer)
        {
            return;
        }

        winner = winnername;

        if (prizepool > 0)
        {
            ethtransfer.TransferRequest(prizepool, winnername);
        }
        RpcPreviousGamewinnerUiUpdate(winner, prizepool.ToString());
    }

    [ClientRpc]
    public void RpcPreviousGamewinnerUiUpdate(string winner, string amount)
    {
        prevgamewinner.text = winner;
        prevgameAmount.text = amount;
    }



}
