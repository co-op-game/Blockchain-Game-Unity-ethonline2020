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
<<<<<<< HEAD
    public GameObject EndGameCanvas2;
=======
>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
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

<<<<<<< HEAD

    [ClientRpc]
    public void RpcZeroPlayers()
    {
        EndGameCanvas2.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

=======
>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
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
