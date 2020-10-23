using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DestroyThisIfServer : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.isServer)
        {
            Destroy(this.gameObject);
        }
    }

}
