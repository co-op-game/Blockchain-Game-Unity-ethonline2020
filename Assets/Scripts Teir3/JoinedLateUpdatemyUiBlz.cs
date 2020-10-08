using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinedLateUpdatemyUiBlz : NetworkBehaviour
{
    public Text qStartBlock;
    public Text qEndBlock;
    // Start is called before the first frame update

    string sStartBlock;
    string sEndBlock;


    private void Start()
    {
        if (isServer) //only run on client .
        {
            return;
        }

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
        qStartBlock.text = sStartBlock;
        qEndBlock.text = sEndBlock;
    }
}
