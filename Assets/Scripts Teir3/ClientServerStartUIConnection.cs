using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientServerStartUIConnection : NetworkBehaviour
{

    public GetLatestBlockVanillaNethereum getlatestBlockVanillaNethereum;

    bool questarted;

    private void Start()
    {
        questarted = false;
    }

    public void StartOnServer()
    {   
        if(questarted != true)
        {
            getlatestBlockVanillaNethereum.GetBlockNumber();
            RpcDisableClickButton();
            questarted = true;
        }
    }


    public GameObject StartButton;

    [ClientRpc]
    public void RpcDisableClickButton()
    {
        Destroy(StartButton);
    }
}
