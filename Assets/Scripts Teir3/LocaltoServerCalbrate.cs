using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocaltoServerCalbrate : NetworkBehaviour
{
    JoinedLateUpdatemyUiBlz joinedLateUpdatemeUi;
    GameObject startquestart;
    void Start()
    {
        if (isServer)
        {
            return;
        }

        startquestart = GameObject.Find("Start : QueStart");
        joinedLateUpdatemeUi = startquestart.GetComponent<JoinedLateUpdatemyUiBlz>();
        joinedLateUpdatemeUi.Ser();
    }
}
