using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Player : MonoBehaviour
{
    bool mIsActive = false;
    public OSC mOscControler;
    public int playerButton;
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    int mBar, mBeat, mRawTick;


    public void BuzzerPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            mIsActive = !mIsActive;
            if (mIsActive)
            {
                GetComponent<MeshRenderer>().material = mActiveMaterial;
                OscMessage message = new OscMessage();
                message.address = "/ButtonActive";
                message.values.Add(playerButton);
                mOscControler.Send(message);
                Task.Delay(500);
                GetComponent<MeshRenderer>().material = mInactiveMaterial;

            
          
        }
    }
    

    private void Start()
    {
        mOscControler.SetAddressHandler("/Bar", OnReceiveBar);

    }
    void OnReceiveBar(OscMessage message)
    {
        mBar = message.GetInt(0);
        Debug.Log("Bar = " + mBar);
    }
}

