using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
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