using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AbilityMaster : NetworkBehaviour
{   
    public void SetPlayerAbilityInit(Block_DataModel matchedtxdata)
    {
        StartCoroutine(Run(matchedtxdata));
    }

    private IEnumerator Run(Block_DataModel matchedtxdata)
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player"); //find all players currently spawned in server
        float waitTime = 0f;

        foreach (GameObject player in Players) 
        {
            if(matchedtxdata.from.Equals(player.name, StringComparison.InvariantCultureIgnoreCase)) //if player name(address) is equal to from value in  matched txdata.
            {
                Debug.Log("uwu");
                Player_Abilities player_abilities = player.GetComponent<Player_Abilities>(); //get player properties script of this player.
                SetAbilityAcctotx(matchedtxdata, player_abilities); //transfer matched tx + its specific player ability script to combine.
            }
            yield return new WaitForSeconds(waitTime);
        }
    }


    void SetAbilityAcctotx(Block_DataModel matchedtxdata, Player_Abilities player_abilities)
    {
        //DEBUG : enable ability for this player /////////// DEBUG
        Debug.Log("Debug_PlayerAbility with Tx:");
        Debug.Log(matchedtxdata.from);
        ////////////////////////////////////////////////////////



        player_abilities.address = matchedtxdata.from;

        // todo here: link matchedtxdata.value (convert from string to float) to player_abilities.abilityvalue
        //float abilityvalue = 

    }
}
