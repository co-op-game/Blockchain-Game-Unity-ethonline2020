using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiListUpdate : MonoBehaviour
{
    PlayerListUi playerlistui;
    void Start()
    {
        GameObject questart = GameObject.Find("Start : QueStart");
        playerlistui = questart.GetComponent<PlayerListUi>();
        playerlistui.AddPlayer();
    }

    void OnDestroy()
    {
        playerlistui.RemovePlayer();
    }

 
}
