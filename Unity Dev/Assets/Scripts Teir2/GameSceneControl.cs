using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GameSceneControl : NetworkBehaviour
{
    public ClientCall clientcall;
    bool gamended;
    public CustomNetworkManager netowkrlobbym;
    private void Start()
    {
        if (!isServer)
        {
            return;
        }
        gamended = false;
        
        GameObject srvrmanager = GameObject.Find("ServerManager");
        netowkrlobbym = srvrmanager.GetComponent<CustomNetworkManager>();
    }

    public void RunCheckPlayer()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        yield return new WaitForSeconds(7);
        SpawnedPlayers();
        StartCoroutine(Run());
    }

    private void SpawnedPlayers()
    {
        Debug.Log("gameon");
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player"); //find all players currently in scene

        if (Players.Length == 1) //gameend
        {
            clientcall.RpcOnlyOnePlayer(Players[0].name.ToString());
            SendPrizePool(Players[0].name.ToString());
            gameendcourotunerun();
        }

        if (Players.Length == 0) //gameend
        {
            clientcall.RpcZeroPlayers();
            gameendcourotunerun();
        }

        Players = null;
    }

    public void SendPrizePool(string winnername)
    {
        GameObject ability = GameObject.Find("Ability");
        PrizeMaster prizemaster = ability.GetComponent<PrizeMaster>();
        prizemaster.CmdSendAbiltyFunds(winnername);
    }


    public void gameendcourotunerun()
    {
        StartCoroutine(endwait());
    }

    IEnumerator endwait()
    {
        if (gamended == false)
        {
            yield return new WaitForSeconds(12);
            gamended = true;
            netowkrlobbym.ServerChangeScene("Lobby");
       
            // clientcall.Cmdlobbyreturn();
        }
    }


}
