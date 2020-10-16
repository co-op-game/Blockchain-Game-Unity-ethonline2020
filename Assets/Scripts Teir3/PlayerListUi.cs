using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Mirror;

public class PlayerListUi : NetworkBehaviour
{
   // static ExamplePlayerListGUI s_instance;
    //List<JavascriptHook> m_players = new List<JavascriptHook>();

    public Text PlayerList;
    public Text TotalPlayersinlooby;
    public Text Connectedwallets;
    int totalgamers = 0;
  /*  static public ExamplePlayerListGUI GetInstance()
    {
        return s_instance;
    }

    void Awake()
    {
        if (s_instance != null)
        {
            Debug.LogError("there should only be one oneListGUI");
        }
        s_instance = this;
    } */

    public void AddPlayer()
    {
        totalgamers = totalgamers + 1;
        Cmdupdateui();
    }

    public void RemovePlayer()
    {
        totalgamers = totalgamers - 1;
        Cmdupdateui();
    }

  //  [Command]
    void Cmdupdateui()
    {
        RpcUpdateUi();
    }

  // [ClientRpc]
    public void RpcUpdateUi()
    {
        TotalPlayersinlooby.text = totalgamers.ToString();
        PlayerList.text = null;
        int i = 0;
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        foreach (GameObject gamer in GamerIDs)
        {
            JavascriptHook javascriptHook = gamer.GetComponent<JavascriptHook>();
            if (javascriptHook.address != null)
            {
                i = i + 1;
                PlayerList.text = PlayerList.text + "   ;   " + javascriptHook.address;
            }
        }

        Connectedwallets.text = i.ToString();
    }
}

