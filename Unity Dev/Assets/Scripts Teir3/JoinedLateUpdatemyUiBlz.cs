using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinedLateUpdatemyUiBlz : NetworkBehaviour
{
    public Text qStartBlock;
    public Text qEndBlock;

    string sStartBlock;
    string sEndBlock;

    JoinedLateUpdatemyUiBlz joinedLateUpdatemeUi;
    GameObject startquestart;

    public void Ser()
    {
        CmdHiserver();     //not sure this scripts logic prob works, if join late and current countdown blocks shown cool or to be fixed later. - syncing qstart ,endstart block UI on clients after they join late. 
    }

    [Command]
    void CmdHiserver()
    {
       // startquestart = GameObject.Find("Start : QueStart");
     //   joinedLateUpdatemeUi = startquestart.GetComponent<JoinedLateUpdatemyUiBlz>();

        sStartBlock = qStartBlock.text;
        sEndBlock = qEndBlock.text;
        RpcHereYago(sStartBlock, sEndBlock);


    }
    
    [ClientRpc]
    void RpcHereYago(string sStartBlock, string sEndBlock)
    {

            qStartBlock.text = sStartBlock;
            qEndBlock.text = sEndBlock;

    }
}
