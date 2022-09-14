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
    int indexSBlevel;


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
        
    }

    public void ReceiveCurrentTime(float timing)
    {
       // mReceive.OnReceiveCurrentTime(timing);
        mCurrentLoopTime = timing;
        
    }


    void Update()
    {
        mReceive.GetCurrentTime();
        Debug.Log("GAME_CurrentLoopTime " + mCurrentLoopTime);

        foreach (PlayerControler p in mPlayers)
        {
            p.setCurrentLevel(indexLevel);
        }
        foreach (PlayerControler p in mPlayers)
        {
            p.setCurrentTime(mCurrentLoopTime);
        }

        while (indexLevel < 2)
        {
            while(indexSBlevel <= 4)
            {
                
                foreach(PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexLevel);
                }
            }
        }

    }

}

