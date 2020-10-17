using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;

public class Lobby : MonoBehaviour
=======
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lobby : NetworkBehaviour
>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
{
    void Awake()
    {
        GameObject startque;
        startque = GameObject.Find("Start : QueStart");
        QueUIControl quicntrl = startque.GetComponent<QueUIControl>();
        quicntrl.Lobby();

        ClientServerStartUIConnection clientsrvrui = startque.GetComponent<ClientServerStartUIConnection>();
        clientsrvrui.questarted = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /*
    public void Update()
    {
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        foreach (GameObject gamer in GamerIDs)
        {
            JavascriptHook javascriptHook = gamer.GetComponent<JavascriptHook>();
            if (javascriptHook.address != null)
            {
                PlayerListUi.text = PlayerListUi.text + javascriptHook.address;
            }
            TotalPlayersinlooby.text = GamerIDs.Length.ToString();
        }
    }*/
}