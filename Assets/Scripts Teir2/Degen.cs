using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Degen : MonoBehaviour
{
    public AbilityMaster abilitymaster;
    public PrizeMaster prizemaster;
    Block_DataModel[] txdata;
    int matchedtx;

    /// <summary>
    /// checks tx between blocks and compares with connected wallet adress. [on server only] 
    /// </summary>

    public void TxDetails(Block_DataModel[] data) //called from QueStart
    {
        Debug.Log("tx details recieved");
        if (data.Length == 0)
        {
            Debug.Log("No transactions during Que");
        }

        txdata = data; //to be used further in callfromplayerspawntochecktx() below.



        ///////// debug log all transactions from and value. /////////// DEBUG
        for (int i = 0; i < data.Length; i++)
        {
            Debug.Log(data[i].from);
            Debug.Log(data[i].value);
        }
        Debug.Log(data.Length);
        ////////////////////////////////////////////////////////
        
    }

    public void callfromplayerspawntochecktx(string connectedaddress) //called from Player_Ability attached to each player.
    {
        if (txdata != null) 
        {
            for (int i = 0; i < txdata.Length; i++) //txdata fetched above in TxDetails() from QueStart
            {
                if (txdata[i].from.Equals(connectedaddress, StringComparison.InvariantCultureIgnoreCase)) //if connected wallet did tx during Que
                {

                    matchedtx = i;
                    abilitymaster.SetPlayerAbilityInit(txdata[matchedtx]); //set player ability acc to funds value.
                    prizemaster.AbilityFunds(decimal.Parse(txdata[matchedtx].value)); //send funds to prizepool.

                }
            }
        }
    }

}
