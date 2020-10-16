using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;

public class QueUIControl : NetworkBehaviour
{
    public Text QStartBlock;
    public Text QEndBlock;
    public Text countdownDisplay;
    public GameObject StartLobbycanvas;
    public GameObject Gamecanvas;
    public ClientServerStartUIConnection clientsrvrui;
    public AbilityUiControl abilityuicntrl;

    // server vars
    [SyncVar(hook = "OnChangescountdowntime")] float scountdownTime;
    [SyncVar(hook = "OnChangeqstartblock")] string s_qstartBlock = null;
    [SyncVar(hook = "OnChangeqEndBlock")] string s_qEndBlock = null;

    public void QueUIStart(float countdownTime, string qstartBlock, string qEndBlock)
    {
        if (!isServer)
        {
            return;
        }

        scountdownTime = countdownTime;
        StartCoroutine(CountdownToStart(scountdownTime));
        s_qstartBlock = qstartBlock;
        s_qEndBlock = qEndBlock;

    }


    IEnumerator CountdownToStart(float icountdownTime)
    {
        while(icountdownTime > 0)
        {
            countdownDisplay.text = icountdownTime.ToString();

            yield return new WaitForSeconds(1f);
            icountdownTime--;
            scountdownTime = icountdownTime;
            s_qstartBlock = QStartBlock.text;
            s_qEndBlock = QEndBlock.text;
        }
        if (icountdownTime < 0)
        {
            RpcDisableEnableAfterQue();
        }
    }

    public void Lobby()
    {
        StartLobbycanvas.SetActive(true);
        Gamecanvas.SetActive(false);
        countdownDisplay.text = "";
        QStartBlock.text = "000000000";
        QEndBlock.text = "000000000";
        clientsrvrui.questarted = false;
    }

    [ClientRpc]
    public void RpcDisableEnableAfterQue()
    {
        StartLobbycanvas.SetActive(false);
        Gamecanvas.SetActive(true);
    }

    void OnChangescountdowntime(float oldscountdownTime, float scountdownTime)
    {
        countdownDisplay.text = scountdownTime.ToString();
    }

    void OnChangeqstartblock(string olds_qstartBlock, string s_qstartBlock) {

        QStartBlock.text = s_qstartBlock;
    }

    void OnChangeqEndBlock(string olds_qEndBlock, string s_qEndBlock)
    {
        QEndBlock.text = s_qEndBlock;
    }


}
