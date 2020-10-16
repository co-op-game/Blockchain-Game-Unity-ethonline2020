using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_AbilitySetup : NetworkBehaviour
{

    GameObject ability;
    Degen degen;
    string connectedaddress;

    // Start is called before the first frame update
    void Start()
    {   
        if (!isServer) {
            return;
        }
        /////calls from here happens on server only , ie- check tx details, till assign values according to tx. Then var's are synced
        ///to clients from server using [SyncVar]
        //// As soon as player Spawns, Finds a gameobject called Ability(On Server Only Authority
        //// which has data of tx's and set ability according to returned matched tx..
        /////
        
        ability = GameObject.Find("Ability");
        degen = ability.GetComponent<Degen>();

        connectedaddress = this.name; //name of this object is set to wallet address on spawn from PlayerSpawn script.
        degen.callfromplayerspawntochecktx(connectedaddress); //pass wallet address to be compared in ability section with onchain data.
    }
}
  