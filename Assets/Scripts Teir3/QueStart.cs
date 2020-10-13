using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class QueStart : MonoBehaviour
{
    //Rinkeby testnet ETHERSCAN.IO 

    string WEB_URL_TIME;
    public int BlocksBwQueStartandEnd = 0;
    public string EtherscanAPIKey = "WJTWK63X8WZ95D67JSGJ6NPP5ISZZKNM84";
    public string serveracc;
    public QueUIControl queUIControl;
    public GetTxDetails gettxdetails;


    public void Que(string QStartBlockstring)
    {
        //defining time from eth block number now to QEnd start match. 
        int QStartBlock = int.Parse(QStartBlockstring);
        int QEndBlock = 0;
        QEndBlock = QStartBlock + BlocksBwQueStartandEnd;
        Debug.Log(QStartBlock); Debug.Log("endblock:"); Debug.Log(QEndBlock);

        GetEstimatedTimetillQEndBlock(QStartBlock, QEndBlock);

    }


    string QStartBlockString;
    string QEndBlockString;

    public void GetEstimatedTimetillQEndBlock(int Qstart, int Qend)
    {
        QStartBlockString = Qstart.ToString();
        QEndBlockString = Qend.ToString();

        WEB_URL_TIME = "https://api-rinkeby.etherscan.io/api?module=block&action=getblockcountdown&blockno=" + QEndBlockString + "&apikey=" + EtherscanAPIKey;
        StartCoroutine(ApiFetchTime());
    }


    IEnumerator ApiFetchTime()
    {
        ESAPI_timeblock datablocktime = null;
        StartCoroutine(CallAPIProcessBlockTimeEst(outcome => datablocktime = outcome));
        //Wait until data has landed before proceeding.
        while (datablocktime == null)
            yield return null;
        Debug.Log(datablocktime.EstimateTimeInSec);

        //wait till Que end block estimate(+2 seconds) then continue.
        float timetillQEndBlockinSeconds = float.Parse(datablocktime.EstimateTimeInSec) + 2f;
        Debug.Log(timetillQEndBlockinSeconds);
        StartCoroutine(WaitAcctotime(timetillQEndBlockinSeconds));


    }


    public IEnumerator CallAPIProcessBlockTimeEst(Action<ESAPI_timeblock> outcome)
    {

        UnityWebRequest rq = UnityWebRequest.Get(WEB_URL_TIME);
        {
            yield return rq.SendWebRequest();

            string jsonResult = System.Text.Encoding.UTF8.GetString(rq.downloadHandler.data);
            Debug.Log(jsonResult);
            ESAPIReplyBlockTimeModel datablocktime = JsonUtility.FromJson<ESAPIReplyBlockTimeModel>(jsonResult);
            if (datablocktime == null)
            {
                Debug.LogError($"Null data. Response code: {rq.responseCode}.");
                yield return new WaitForSeconds(2);
                // consol.text = "INVALID API REPLY, RETRYING..";

                StartCoroutine(CallAPIProcessBlockTimeEst(outcome));
                yield break;
            }
            outcome?.Invoke(datablocktime.result);

        }
    }



    IEnumerator WaitAcctotime(float timetillQEndBlock)
    {
        Debug.Log("Starting Q wait");
        Debug.Log(timetillQEndBlock);
        queUIControl.QueUIStart(timetillQEndBlock, QStartBlockString, QEndBlockString);
        yield return new WaitForSeconds(timetillQEndBlock);
        Debug.Log("Wait over");
        DoublecheckIfQEndBlockPassed();

    }

    public void DoublecheckIfQEndBlockPassed()
    {
        //Placeholder function.>check if current block is greater than ewual to QendBlock.
        //  Gettxdetailsbetweenblocks(QStartBlockString, QEndBlockString);
        queUIControl.RpcDisableEnableAfterQue();
        gettxdetails.Gettxdetailsbetweenblocks(QStartBlockString, QEndBlockString);

    }



    /*  
      IEnumerator Start()
      {
          yield return new WaitForSeconds(0);
          Debug.Log("Trying Etherscan API:Get Block Tx Info");

              StartCoroutine(ApiFetch());
              yield return new WaitForSeconds(2);    
      }
   */




}


