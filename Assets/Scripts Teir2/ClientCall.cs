using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClientCall : NetworkBehaviour
{
    //public CustomNetworkManager netowkrlobbym;
    public GameObject EndGameCanvas;
    public Text winnername;
    public Text prizepool;
    public Text przepoolendgame;


    [ClientRpc]
    public void RpcOnlyOnePlayer(string lastplayername)
    {
        EndGameCanvas.SetActive(true);
        winnername.text = lastplayername;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    [ClientRpc]
    public void Rpclobbyreturn()
    {   
        SceneManager.LoadScene("Lobby");
       // netowkrlobbym.ServerChangeScene("Lobby");

    }
   [Command]
    public void Cmdlobbyreturn()
    {
       // netowkrlobbym.ServerChangeScene("Lobby");
        Rpclobbyreturn();
     //   netowkrlobbym.SendReturnToLobby()
        SceneManager.LoadScene("Lobby");
    }


    private void Start()
    {
        CmdPrizePoolupdate();

    }
    [Command]
    public void CmdPrizePoolupdate()
    {
        GameObject ability = GameObject.Find("Ability");

        AbilityUiControl uicontrol = ability.GetComponent<AbilityUiControl>();
        uicontrol.updateprizepool();
    }

    public void przepoolui(string prizepoolvalue)
    {
        prizepool.text = prizepoolvalue;
        przepoolendgame.text = prizepoolvalue;
    }
}
