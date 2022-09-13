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
        int checkTot = 0;
        foreach(PlayerControler p in mPlayers)
        {
            checkTot += p.CheckPlayer(indexPLayer);

        }
        if(checkTot == 4)
        {
            indexLevel++;

        }
        else
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
          
           // mReceive.OnReceiveCurrentTime(mCurrentLoopTime);
            p.setCurrentTime(mCurrentLoopTime);
        }




    }

}

