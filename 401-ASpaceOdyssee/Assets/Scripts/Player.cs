using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Player : MonoBehaviour
{
    bool mIsActive = false;
    public OSC mOscControler;
    public int player, button;
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    int mBar, mBeat, mRawTick, mTempo, mTime;
    int loopBar = 4;
    int i;

    private void Start()
    {
        mOscControler.SetAddressHandler("/Bar", OnReceiveBar);
        mOscControler.SetAddressHandler("/Tempo", OnReceiveTempo);

    }

    void OnReceiveBar(OscMessage message)
    {
        mBar = message.GetInt(0);
        Debug.Log("Bar = " + mBar);
    }
    void OnReceiveTempo(OscMessage message)
    {
        mTempo = message.GetInt(0);
        Debug.Log("Tempo = " + mTempo);
    }

    

    public void BuzzerPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            mIsActive = !mIsActive;
            if (mIsActive)
            {
                GetComponent<MeshRenderer>().material = mActiveMaterial;
                OscMessage message = new OscMessage();
                message.address = "/Event";
                message.values.Add(player + (i*6));
                message.values.Add(button);
                mOscControler.Send(message);


                


               // mTime = (mBar % loopBar) / (mTempo / 60);

            }
            else
            {
                GetComponent<MeshRenderer>().material = mInactiveMaterial;
            }
            Thread.Sleep(1000);

        }
        



    }
}