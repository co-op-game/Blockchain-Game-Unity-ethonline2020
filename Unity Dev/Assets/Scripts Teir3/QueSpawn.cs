using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QueSpawn : MonoBehaviour
{
    public GameSceneControl gamescnecontrol;
    private void Start()
    {
        QSpawn();
    }
    public void QSpawn()
    {
        StartCoroutine(Run());

    }

    private IEnumerator Run()
    {
        GameObject[] GamerIDs = GameObject.FindGameObjectsWithTag("GamerID");
        float waitTime = 7f;
        yield return new WaitForSeconds(waitTime);
        //find all connected gameid's and call their javascript hook which checks connected wallet and spawns.
        foreach (GameObject go in GamerIDs)
        {
            if(go != null)
            {
                JavascriptHook javascriptHook = go.GetComponent<JavascriptHook>();
                javascriptHook.RpcGameStartSpawn();
            }

        }
        gamescnecontrol.RunCheckPlayer();
    }
}
