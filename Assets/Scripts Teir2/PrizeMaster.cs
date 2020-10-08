using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeMaster : MonoBehaviour
{

    public AbilityUiControl abiltyuicontrol;

    float abilityfunds; //This Rounds total Ability Funds.

    void Start()
    {
        abilityfunds = 0;
    }

    public void AbilityFunds(float txvalue)
    {
        abilityfunds = abilityfunds + txvalue;
        abiltyuicontrol.AbilityFundPool(abilityfunds);
    }


    public void SendAbiltyFunds()
    {

    }


}
