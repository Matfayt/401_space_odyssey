using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GAME : MonoBehaviour

{
    public PlayerControler[] mPlayers;
    public SendOSC mSend;
    public ReceiveOSC mReceive;
    public OSC mOscChannel;
    public float mCurrentLoopTime;
    //float mLoopLenghtTime = 56.443f;// lenght of the loop
    int indexLevel;


    public void CheckErrorByPlayer(int indexPLayer)
    {
        foreach(PlayerControler p in mPlayers)
        {
         
        }
    }

    void Start()
    {
        foreach(PlayerControler p in mPlayers)
        {
            p.setCurrentLevel(indexLevel);
        }
    }

    public void ReceiveCurrentTime(float timing)
    {
        mCurrentLoopTime = timing;
        
    }


    void Update()
    {
       
    foreach(PlayerControler p in mPlayers)
        {
          mCurrentLoopTime ==  mReceive.OnReceiveCurrentTime();

           // mReceive.OnReceiveCurrentTime(mCurrentLoopTime);
            p.setCurrentTime(mCurrentLoopTime);
        }




    }

}

