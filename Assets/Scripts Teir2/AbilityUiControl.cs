using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AbilityUiControl : NetworkBehaviour
{

    [SyncVar(hook = "OnChangesprizepool")] float prizepool;
    public Text prizepoolvalueUI;
    public void AbilityFundPool(float abilityfunds)
    {
        prizepool = abilityfunds;
    }

    void OnChangesprizepool(float prizepool)
    {
        prizepoolvalueUI.text = prizepool.ToString();
    }
}
