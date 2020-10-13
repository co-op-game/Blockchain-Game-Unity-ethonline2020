using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueSpawn : MonoBehaviour
{
    public void QSpawn()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        float waitTime = 0f;

        //find all connected gameid's and call their javascript hook which checks connected wallet and spawns.
        foreach (GameObject go in GamerIDs)
        {
            JavascriptHook javascriptHook = go.GetComponent<JavascriptHook>();
            yield return new WaitForSeconds(waitTime);
            javascriptHook.RpcGameStartSpawn();
        }

    } 
}
