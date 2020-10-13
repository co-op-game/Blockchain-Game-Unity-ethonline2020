using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeMaster : MonoBehaviour
{

    public AbilityUiControl abiltyuicontrol;
    public EtherTransferCoroutinesUnityWebRequest ethtransfer;

    decimal prizepool; //This Rounds total Ability Funds.

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


    public void SendAbiltyFunds(string winnername)
    {   
        if(prizepool > 0)
        {
            ethtransfer.TransferRequest(prizepool, winnername);
        }


    }


}
