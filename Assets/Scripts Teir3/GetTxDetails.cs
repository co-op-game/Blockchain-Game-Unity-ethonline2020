using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using System;

public class GetTxDetails : MonoBehaviour
{
    public Mirror.NetworkLobbyManager networkmanager;
    public string gamescenename;
    public Degen degen;

    string WEB_URL;
    public string EtherscanAPIKey = "WJTWK63X8WZ95D67JSGJ6NPP5ISZZKNM84";
    public string serveracc;



    public void Gettxdetailsbetweenblocks(string QStartBlockString, string QEndBlockString)
    {

        WEB_URL = "http://api-rinkeby.etherscan.io/api?module=account&action=txlist&address=" + serveracc + "&startblock=" + QStartBlockString + "&endblock=" + QEndBlockString + "&sort=asc&apikey=" + EtherscanAPIKey;
        Block_DataModel[] data = null;
        StartCoroutine(ApiFetchTXs(data));
    }

    IEnumerator ApiFetchTXs(Block_DataModel[] data)
    {
        StartCoroutine(CallAPIProcessTxDetail(outcome => data = outcome));

        //Wait until data has landed before proceeding.
        while (data == null)
            yield return null;
        degen.TxDetails(data); ///send tx details ///called after checking tx bw blocks, data is tx details/////////
        networkmanager.ServerChangeScene(gamescenename);
    }

    public IEnumerator CallAPIProcessTxDetail(Action<Block_DataModel[]> outcome)
    {

        UnityWebRequest rq = UnityWebRequest.Get(WEB_URL);
        {
            yield return rq.SendWebRequest();

            string jsonResult = System.Text.Encoding.UTF8.GetString(rq.downloadHandler.data);
            Debug.Log(jsonResult);

            EtherScanAPIReply_Model data = JsonUtility.FromJson<EtherScanAPIReply_Model>(jsonResult);
            if (data == null)
            {
                Debug.LogError($"Null data. Response code: {rq.responseCode}.");
                yield return new WaitForSeconds(2);
                // consol.text = "INVALID API REPLY, RETRYING..";

                StartCoroutine(CallAPIProcessTxDetail(outcome));
                yield break;
            }
            outcome?.Invoke(data.result);
        }
    }
}
