using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AbilityUiControl : NetworkBehaviour
{

    [SyncVar(hook = "OnChangesprizepool")] decimal prizepool;
    public Text prizepoolvalueUI;
    public void AbilityFundPool(decimal abilityfunds)
    {
        prizepool = abilityfunds;

    }
    void OnChangesprizepool(decimal prizepool)
    {
        prizepoolvalueUI.text = prizepool.ToString();
    }
}
