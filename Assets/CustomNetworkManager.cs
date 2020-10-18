
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
public class CustomNetworkManager : NetworkManager
{
    public PrizeMaster prizemastertoupdateui;
    public PlayerListUi playerlistui;
    public QueUIControl quicntrl;

    public override void OnClientConnect(NetworkConnection conn)
    {
        if (!clientLoadedScene)
        {
            // Ready/AddPlayer is usually triggered by a scene load completing. if no scene was loaded, then Ready/AddPlayer it here instead.
            ClientScene.Ready(conn);
            //  if (m_AutoCreatePlayer)
            // {
            ClientScene.AddPlayer(0);
            // }
        }

        string loadedSceneName = SceneManager.GetSceneAt(0).name;
        SceneManager.LoadScene(loadedSceneName);

        prizemastertoupdateui.CmdPreviousGamewinnerUiUpdate();
       // playerlistui.Cmdupdateui();

        if (loadedSceneName == "Lobby")
        {
            quicntrl.Lobby();
        }
        else
        {
            quicntrl.LocalDisableEnableAfterQue();
        } 
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        StopClient();
        if (conn.lastError != NetworkError.Ok)
        {
            if (LogFilter.logError) { Debug.LogError("ClientDisconnected due to error: " + conn.lastError); }
        }
    }


    /*   public virtual void OnLobbyClientEnter()
        {
            string loadedSceneName = SceneManager.GetSceneAt(0).name;
            SceneManager.LoadScene(loadedSceneName);
        } */
}

<<<<<<< HEAD
=======
=======
public class CustomNetworkManager : NetworkLobbyManager
{

    public override void OnServerConnect(NetworkConnection conn)
    {
        // numPlayers returns the player count including this one, so ok to be equal
        if (numPlayers > maxPlayers)
        {
           // if (LogFilter.logWarn) { Debug.LogWarning("NetworkLobbyManager can't accept new connection [" + conn + "], too many players connected."); }
            conn.Disconnect();
            return;
        }
        /*
        // cannot join game in progress
        string loadedSceneName = SceneManager.GetSceneAt(0).name;
        if (loadedSceneName != m_LobbyScene)
        {
            if (LogFilter.logWarn) { Debug.LogWarning("NetworkLobbyManager can't accept new connection [" + conn + "], not in lobby and game already in progress."); }
            conn.Disconnect();
            return;
        }

        base.OnServerConnect(conn);

        // when a new client connects, set all old players as dirty so their current ready state is sent out
        for (int i = 0; i < lobbySlots.Length; ++i)
        {
            if (lobbySlots[i])
            {
                lobbySlots[i].SetDirtyBit(1);
            }
        }
        */
        OnLobbyServerConnect(conn);
    }

    public virtual void OnLobbyClientEnter()
    {
        string loadedSceneName = SceneManager.GetSceneAt(0).name;
        SceneManager.LoadScene(loadedSceneName);
    }


    public override void ServerChangeScene(string sceneName)
    {
       // if (sceneName == m_LobbyScene)
        {
            for (int i = 0; i < lobbySlots.Length; i++)
            {
                var lobbyPlayer = lobbySlots[i];
                if (lobbyPlayer == null)
                    continue;

                // find the game-player object for this connection, and destroy it
                var uv = lobbyPlayer.GetComponent<NetworkIdentity>();

               // PlayerController playerController;
              //  if (uv.connectionToClient.GetPlayerController(uv.playerControllerId, out playerController))
               // {
                 //   NetworkServer.Destroy(playerController.gameObject);
               // }

                if (NetworkServer.active)
                {
                    // re-add the lobby object
              //      lobbyPlayer.GetComponent<NetworkLobbyPlayer>().readyToBegin = false;
                //    NetworkServer.ReplacePlayerForConnection(uv.connectionToClient, lobbyPlayer.gameObject, uv.playerControllerId);
                }
            }
        }
        base.ServerChangeScene(sceneName);
    }
}


>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
