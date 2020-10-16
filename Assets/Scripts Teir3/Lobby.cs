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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;





        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        foreach (GameObject go in GamerIDs)
        {
            PlayerSpawn playerspawn = go.GetComponent<PlayerSpawn>();
            playerspawn.InLobby();
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
}