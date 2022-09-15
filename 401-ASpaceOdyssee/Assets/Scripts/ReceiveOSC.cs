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
    public int mBar, mBeat, mRawTick, mTempo, mAbletonUnit, mAbletonMidiTick, mMs, mCurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        mOscControler.SetAddressHandler("/Beat", OnReceiveBeat);
        mOscControler.SetAddressHandler("/Ms", OnReceiveMs);
        mOscControler.SetAddressHandler("/CurrentTime", OnReceiveCurrentTime);
        //mOscControler.SetAddressHandler("/AbletonUnit", OnReceiveAbletonUnit);
        //mOscControler.SetAddressHandler("/AbletonMidiTick", OnReceiveAbletonMidiTick);
        //mOscControler.SetAddressHandler("/Bar", OnReceiveBar);
        //mOscControler.SetAddressHandler("/Tempo", OnReceiveTempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnReceiveBeat(OscMessage message)
    {
        mBeat = message.GetInt(0);
        //Debug.Log("Beat = " + mBeat);
    }
    public float GetBeat()
    {
        return mBeat;
    }

    //Raw Ticks translated to milliseconds
    void OnReceiveMs(OscMessage message)
    {
        mMs = message.GetInt(0);
        //Debug.Log("Ms = " + mMs);
    }
    public float GetMs()
    {
        return mMs;
    }

    //Raw Ticks going back to zero at the end of each loop (% 7690) translated to milliseconds (1 loop = 9600ms)
    void OnReceiveCurrentTime(OscMessage message)
    {
        mCurrentTime = message.GetInt(0);
        //Debug.Log("CurrentTime = " + mCurrentTime);
    }

    public float GetCurrentTime()
    {
        return mCurrentTime;
    }

    /*void OnReceiveAbletonUnit(OscMessage message)
    {
        mAbletonUnit = message.GetInt(0);
        Debug.Log("AbletonUnit = " + mAbletonUnit);
    }

    void OnReceiveAbletonMidiTick(OscMessage message)
    {
        mAbletonMidiTick = message.GetInt(0);
        Debug.Log("AbletonMidiTick = " + mAbletonMidiTick);
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
    }*/
}
