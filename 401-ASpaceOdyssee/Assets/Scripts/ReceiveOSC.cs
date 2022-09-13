using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReceiveOSC : MonoBehaviour
{
    //public GAME mGameControler;
    public OSC mOscControler;
    public int player, button;
    public int i=0;
    public int mBar, mBeat, mRawTick, mTempo = 120, mAbletonUnit, mAbletonMidiTick, mMs, mCurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        mOscControler.SetAddressHandler("/Bar", OnReceiveBar);
        mOscControler.SetAddressHandler("/Tempo", OnReceiveTempo);
        mOscControler.SetAddressHandler("/Beat", OnReceiveBeat);
        mOscControler.SetAddressHandler("/AbletonUnit", OnReceiveAbletonUnit);
        mOscControler.SetAddressHandler("/AbletonMidiTick", OnReceiveAbletonMidiTick);
        mOscControler.SetAddressHandler("/Ms", OnReceiveMs);
        mOscControler.SetAddressHandler("/CurrentTime", OnReceiveCurrentTime);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void OnReceiveCurrentTime(OscMessage message)
    {
        mCurrentTime = message.GetInt(0);
        Debug.Log("CurrentTime = " + mCurrentTime);
    }

    public float SendGlobal(char what)
    { int send = 0;

        if (what == mCurrentTime)
        {
            send = mCurrentTime;
        }
        else{
            send = 0;
        }
            return send;
        
    }
}
