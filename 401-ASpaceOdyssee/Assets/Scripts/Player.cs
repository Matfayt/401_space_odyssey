﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    bool mIsActive = false;
    public OSC mOscControler;
    public int player, button;
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    int mBar, mBeat, mRawTick, mTempo = 120, mAbletonUnit, mAbletonMidiTick, mMs;
    int loopBar = 4;
    public int i=0;
    public ArrayList sequence = new ArrayList();


    // Transport Receive
    private void Start()
    {
        mOscControler.SetAddressHandler("/Bar", OnReceiveBar);
        mOscControler.SetAddressHandler("/Tempo", OnReceiveTempo);
        mOscControler.SetAddressHandler("/Beat", OnReceiveBeat);
        mOscControler.SetAddressHandler("/AbletonUnit", OnReceiveAbletonUnit);
        mOscControler.SetAddressHandler("/AbletonMidiTick", OnReceiveAbletonMidiTick);
        mOscControler.SetAddressHandler("/Ms", OnReceiveMs);
        

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
    void OnReceiveBeat(OscMessage message)
    {
        mBeat = message.GetInt(0);
        Debug.Log("Beat = " + mBeat);
    }
    void OnReceiveAbletonUnit(OscMessage message)
    {
        mAbletonUnit = message.GetInt(0);
        Debug.Log("AbletonUnit = " + mAbletonUnit);
    }
    void OnReceiveAbletonMidiTick(OscMessage message)
    {
        mAbletonMidiTick = message.GetInt(0);
        Debug.Log("AbletonMidiTick = " + mAbletonMidiTick);
    }
    void OnReceiveMs(OscMessage message)
    {
        mMs = message.GetInt(0);
        Debug.Log("Ms = " + mMs);
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

                Task.Delay(2000);
                
                int mTime = (mBar % loopBar) / (mTempo / 60);

                int[] temp = new int[] { mTime, player*10+button} ;

                sequence.Add(temp);

                

            }
            else
            {
                GetComponent<MeshRenderer>().material = mInactiveMaterial;
            }

        }
        

    }
}