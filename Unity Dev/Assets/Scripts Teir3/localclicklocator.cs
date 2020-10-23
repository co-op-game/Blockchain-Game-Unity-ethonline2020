using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localclicklocator : MonoBehaviour
{
    GameObject localid;
    clientclick clientclick;
  public void Iclick()
    {
        localid = GameObject.Find("Local");
        clientclick = localid.GetComponent<clientclick>();
        clientclick.ClientClisks();
    }
}
