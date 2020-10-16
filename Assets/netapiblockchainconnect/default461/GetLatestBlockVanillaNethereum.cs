using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Nethereum.ABI.FunctionEncoding.Attributes;
using UnityEngine;
using UnityEngine.UI;
using Nethereum.Contracts;
using Nethereum.Web3;
using Mirror;


public class GetLatestBlockVanillaNethereum : NetworkBehaviour {

    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        // all certificates are accepted
        return true;
    }

    public string Url = "https://rinkeby.infura.io/v3/8136c859e3274c1c92ac552da3910156";
   
   // public InputField ResultBlockNumber;
   // public InputField InputUrl;
    public QueStart questart;

    // Use this for initialization
    void Start()
    {
     //   InputUrl.text = Url;
    }

    public async void GetBlockNumber()
	{

        if (!isServer)
        {
            return;
        }

       // Url = InputUrl.text;
        //This is to workaround issue with certificates https://forum.unity.com/threads/how-to-allow-self-signed-certificate.522183/
        //Uncomment if needed
        // ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;
        var web3 = new Web3(Url);
        
        var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
       // ResultBlockNumber.text = blockNumber.Value.ToString();

        questart.Que(blockNumber.Value.ToString());

    }

   
}
