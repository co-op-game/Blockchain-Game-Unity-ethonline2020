using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerListUIClientcall : NetworkBehaviour
{


    public Text PlayerList;
    public Text TotalPlayersinlooby;
    public Text Connectedwallets;

    [ClientRpc]
    public void RpcUpdateUi(int totalgamers, int i)
    {
        string connectedwallets = null;
        i = 0;
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");

      //  totalgamers = GamerIDs.Length;

        foreach (GameObject gamer in GamerIDs)
        {
            JavascriptHook javascriptHook = gamer.GetComponent<JavascriptHook>();
            if (javascriptHook.address != "0x")
            {
                i = i + 1;
                connectedwallets = connectedwallets + "   ;   " + javascriptHook.address;
            }
        }



        PlayerList.text = null;
        Debug.Log("player list update");
        TotalPlayersinlooby.text = totalgamers.ToString();
        Connectedwallets.text = i.ToString();
        PlayerList.text = connectedwallets;
    }
}
