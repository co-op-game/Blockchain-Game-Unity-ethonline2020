using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnableIfLocal : NetworkBehaviour
{
    public GameObject[] toenable;
    void Start()
    {
        for (int i = 0; i < toenable.Length; i++)
        {
            toenable[i].SetActive(false);
            if (isLocalPlayer || hasAuthority)
            {
                toenable[i].SetActive(true);
            }
        }

   
    }

}
