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


    public void Ser()
    {
 
        CmdHiserver();
    }

    [Command]
    void CmdHiserver()
    {
        sStartBlock = qStartBlock.text;
        sEndBlock = qEndBlock.text;
        RpcHereYago(sStartBlock, sEndBlock);
    }
    
    [ClientRpc]
    void RpcHereYago(string sStartBlock, string sEndBlock)
    {
        if (isLocalPlayer)
        {
            qStartBlock.text = sStartBlock;
            qEndBlock.text = sEndBlock;
        }

    }
}
