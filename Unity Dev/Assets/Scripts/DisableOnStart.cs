using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }
 
}
