using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Bridge : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);
#endif

    public InputField TextInput;
    public Text DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToJS() {
        string MessageToSend = TextInput.text;
        Debug.Log("Sending message to JavaScript: " + MessageToSend);
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowMessage(MessageToSend);
#endif
    }

    public void SendToUnity(string message)
    {
        DisplayText.text = message;
    }

}
