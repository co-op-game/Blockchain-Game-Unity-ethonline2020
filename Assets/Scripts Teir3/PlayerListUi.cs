using UnityEngine;
using System.Collections.Generic;
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
using System.Collections;

public class PlayerListUi : MonoBehaviour
{
    // static ExamplePlayerListGUI s_instance;
    //List<JavascriptHook> m_players = new List<JavascriptHook>();

    public PlayerListUIClientcall listclientcall;
    int totalgamers = 0;
    int i;
    string connectedwallets;

    void Start()
    {
       // if (!isServer) return;
       // StartCoroutine(Run());
        Debug.Log("0");
    } 

    
    public void AddPlayer()
    {
       // if (!isServer) return;
<<<<<<< HEAD
=======
=======
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerListUi : NetworkBehaviour
{
   // static ExamplePlayerListGUI s_instance;
    //List<JavascriptHook> m_players = new List<JavascriptHook>();

    public Text PlayerList;
    public Text TotalPlayersinlooby;
    public Text Connectedwallets;
    int totalgamers = 0;
  /*  static public ExamplePlayerListGUI GetInstance()
    {
        return s_instance;
    }

    void Awake()
    {
        if (s_instance != null)
        {
            Debug.LogError("there should only be one oneListGUI");
        }
        s_instance = this;
    } */

    public void AddPlayer()
    {
>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
        totalgamers = totalgamers + 1;
        Cmdupdateui();
    }

    public void RemovePlayer()
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
       // if (!isServer) return;
        totalgamers = totalgamers - 1;
        Cmdupdateui();
    }
    
    /*
    private IEnumerator Run()
    {
        while (true)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(30);
            Cdupdateui();
            Debug.Log("2");
            StartCoroutine(Run());
        }
        
    }
    */

   // [Command]
    public void Cmdupdateui()
    {
        listclientcall.RpcUpdateUi(totalgamers, i);
    }


<<<<<<< HEAD
=======
=======
        totalgamers = totalgamers - 1;
        Cmdupdateui();
    }

  //  [Command]
    void Cmdupdateui()
    {
        RpcUpdateUi();
    }

  // [ClientRpc]
    public void RpcUpdateUi()
    {
        TotalPlayersinlooby.text = totalgamers.ToString();
        PlayerList.text = null;
        int i = 0;
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        foreach (GameObject gamer in GamerIDs)
        {
            JavascriptHook javascriptHook = gamer.GetComponent<JavascriptHook>();
            if (javascriptHook.address != null)
            {
                i = i + 1;
                PlayerList.text = PlayerList.text + "   ;   " + javascriptHook.address;
            }
        }

        Connectedwallets.text = i.ToString();
    }
>>>>>>> 8fde4476ec600ded30429aa4ba985868b0f593ff
>>>>>>> 1050d734d376411650fc1e5e674e59e685b65807
}

