using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHost : MonoBehaviour
{
    public CustomNetworkManager networkManager;
    void Start()
    {
        networkManager.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
