using System;
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
    public float mCurrentLoopTime = 0;
    public float timeMs = 0;
    public float mCurrentTicks;

    //float mLoopLenghtTime = 56.443f;// lenght of the loop
    public int indexLevel = 0;
    public int indexSBlevel= 0;
    public int etat = 0;
    


    public bool CheckErrorByPlayer()
    { bool incr = false;
        int checkTot = 0;
        
        foreach(PlayerControler p in mPlayers)
        {
                if (p.CheckPlayer() == true)
            {
                checkTot ++;
            }
            Debug.Log("GAME_checkTot =" + checkTot);
        }
        if (checkTot == 4)
        {
            incr = true;
            Debug.Log("GAME_check = 1");
        }
        else { Debug.Log("GAME_check = 0"); }
        return incr;
        

        
    }


    public void ReceiveCurrentTime(float timing)
    {
        //mReceive.OnReceiveCurrentTime(timing);
        mCurrentLoopTime = timing;

    }




    void Start()
    {
        foreach (PlayerControler p in mPlayers)
        {
            p.InitializeLevel(0);
        }
        mReceive.GetCurrentTime();

    }



    void Update()
    {
        mCurrentLoopTime = mReceive.GetCurrentTime();
        timeMs = mReceive.GetMs();
        mCurrentTicks = mReceive.GetCurrentTick();
        float timeNiv = timeMs % 19200;

        Debug.Log("GAME_CurrentLoopTime " + mCurrentLoopTime);
        Debug.Log("GAME_CurrentLoopTime " + timeMs);
        Debug.Log("GAME_CurrentLoopTime " + timeNiv);

        Debug.Log("GAME_etat =  " + etat);

        foreach (PlayerControler p in mPlayers)
        {
            p.setCurrentLevel(indexLevel, indexSBlevel, etat);
        }
        foreach (PlayerControler p in mPlayers)
        {
            p.setCurrentTime(mCurrentLoopTime, mCurrentTicks);
        }


        if (etat == 0)
        {
            mSend.SendMessageStartGame();
            if (timeMs > 96000.0f)
            {
                mSend.SendMessageExemple(indexLevel, indexSBlevel);
                etat = 1;
            }

        }

        else if (etat == 1)
        {
            
            foreach (PlayerControler p in mPlayers)
                    {
                        p.Exemple();
                    }
                
         
            if (timeNiv >= 9550.0f && timeNiv <= 9600.0f)
            {
                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4));
                }
                etat = 2;
            }
    
        }
        else if (etat == 2)
        {
            
            if (timeNiv >= 19150.0f && timeNiv <= 19200.0f)
            {
                if (CheckErrorByPlayer() == true)
                {
                    mSend.SendMessageLoop(indexLevel, indexSBlevel); //Send the layer corresponding to the successfull sequence
                    indexSBlevel++;
                    
                    Debug.Log("Bien Joué");

                }

                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4));
                }

                mSend.SendMessageExemple(indexLevel, indexSBlevel);
                
                Debug.Log("indexSBLevel = " + indexSBlevel);

               
                etat = 1;
            }
            
        }
        else etat=3;







    }

}

