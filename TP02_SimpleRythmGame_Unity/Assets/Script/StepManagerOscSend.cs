using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManagerOscSend : MonoBehaviour
{
    public OSC mOscManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void sendPlaySnare()
    {
        OscMessage message = new OscMessage();

        message.address = "/PlaySnare";
        mOscManager.Send(message);
    }

    public void dontsendPlaySnare()
    {
        OscMessage message = new OscMessage();

        message.address = "/dontPlaySnare";
        mOscManager.Send(message);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
