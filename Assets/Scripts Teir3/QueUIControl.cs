using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class QueUIControl : NetworkBehaviour
{
    public Text QStartBlock;
    public Text QEndBlock;
    public Text countdownDisplay;
    public GameObject StartcanvasToDisable;
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
        }
        if (icountdownTime < 0)
        {
           StartcanvasToDisable.SetActive(false);
        }
    }

    void OnChangescountdowntime(float scountdownTime)
    {
        countdownDisplay.text = scountdownTime.ToString();
    }

    void OnChangeqstartblock(string s_qstartBlock) {

        QStartBlock.text = s_qstartBlock;
    }

    void OnChangeqEndBlock(string s_qEndBlock)
    {
        QEndBlock.text = s_qEndBlock;
    }


}
