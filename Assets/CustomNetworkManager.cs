
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine;
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

