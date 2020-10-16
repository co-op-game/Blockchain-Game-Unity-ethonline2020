using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class clientclick : NetworkBehaviour
{
    [SerializeField]
    GameObject startclickprefab;

    public void ClientClisks()
    {
        CmdClientClicksStart();
    }

    [Command]
    void CmdClientClicksStart()
    {   
      //  this.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        GameObject startclick = (GameObject)Instantiate(startclickprefab);
        NetworkServer.Spawn(startclick);
    }
}
