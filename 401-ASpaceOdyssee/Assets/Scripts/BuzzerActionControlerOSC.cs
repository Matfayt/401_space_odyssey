using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuzzerActionControlerOSC : MonoBehaviour
{
    bool mIsActive = false;
    public OSC mOscControler;
    public Material mActiveMaterial;
    public Material mInactiveMaterial;

  
    public void BuzzerPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            mIsActive = !mIsActive;
            if (mIsActive)
            {
                GetComponent<MeshRenderer>().material = mActiveMaterial;
                OscMessage message = new OscMessage();
                message.address = "/ImageActive";
                message.values.Add(1);
                mOscControler.Send(message);
            }
            else
            {
                GetComponent<MeshRenderer>().material = mInactiveMaterial;
                OscMessage message = new OscMessage();
                message.address = "/ImageActive";
                message.values.Add(0);
                mOscControler.Send(message);
            }
        }
    }
}

