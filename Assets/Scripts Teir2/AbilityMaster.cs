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
        Debug.Log("uwu1");
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

        decimal abilityvalue = decimal.Parse(matchedtxdata.value);
        abilityvalue = abilityvalue / 1000000000000000000; // Wei to ether

        float f_abilityvalue = (float)abilityvalue; //changing decimal to float : optimatize
        if (f_abilityvalue > 1) { f_abilityvalue = 1; } //Max 1 Ether only ability, efn Whale Proof!
        f_abilityvalue *= 100; //1ether = 100 ability
       // if (f_abilityvalue > 1) { f_abilityvalue = 1; } //Max 1 Ether only ability, efn Whale Proof!
        player_abilities.abilityvalue = f_abilityvalue; //ablityvalue acc to tx value.

    }
}
