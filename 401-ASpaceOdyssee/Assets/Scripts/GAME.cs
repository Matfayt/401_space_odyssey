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
    public float mPreviousCurrentTime = -1;
    public float timeMs = 0;
    public float mCurrentTicks;

    //float mLoopLenghtTime = 56.443f;// lenght of the loop
    public int indexLevel = 0;
    public int indexSBlevel= 0;
    public int etat = 0;
    bool check = false;
    


    public bool CheckErrorByPlayer()
    { bool incr = false;
        int checkTot = 0;
        
        foreach(PlayerControler p in mPlayers)
        {
                if (p.CheckPlayer() == true)
            {
                checkTot ++;
            }
        }
        if (checkTot == 4 || check ==true)
        {
            incr = true;
            check = false;
        }
       
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

        mSend.SendMessageStartGame(); //start the Ableton session through OSC

    }



    void Update()
    {
        mCurrentLoopTime = mReceive.GetCurrentTime();
        timeMs = mReceive.GetMs();
        mCurrentTicks = mReceive.GetCurrentTick();
        float timeNiv = timeMs % 19200;

        if(Input.GetKeyDown(KeyCode.Space)) //Short-cut to win a sublevel without using the controllers
        {
            check = true;
        }

        foreach (PlayerControler p in mPlayers) //Shares the information about the game level with all the player objects
        {
            p.setCurrentLevel(indexLevel, indexSBlevel, etat);
        }
        foreach (PlayerControler p in mPlayers) //Shares the time sync infos with all the player objects
        {
            p.setCurrentTime(mCurrentLoopTime, mCurrentTicks);
        }

        if(indexSBlevel == 4) //condition to pass a level
        {
            indexLevel++;
            indexSBlevel = 0;
        }
        if (indexLevel == 2 && indexSBlevel == 2) //Condition to end game
        {
            etat = 3;
        }


        if (etat == 0)  //state 0 is the introduction sample, max deals alone with the introduction sequence triggered in the tsart loop
        {
            
            if (timeMs > 96000.0f)
            {
                etat = 1;
            }

        }

        else if (etat == 1)  //timeline and condition during the presentation of an exemple
        {
            mPreviousCurrentTime = mCurrentLoopTime;
            
            if(mPreviousCurrentTime > mCurrentLoopTime && mPreviousCurrentTime != -1)
            {
                mSend.SendMessageExemple(indexLevel, indexSBlevel); //Trigger th right ablton exemple clip

                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4));
                }

                
                Debug.Log("Go! current time ="+mCurrentLoopTime+"Previous Time ="+mPreviousCurrentTime);
            }
            

            foreach (PlayerControler p in mPlayers) //Display the sequence on the User interface
                    {
                        p.Exemple();
                    }
                
         
            if (timeNiv >= 9550.0f && timeNiv <= 9600.0f) //At the end of the exemple, turn to gama mode
            {
                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4));
                }
                etat = 2;
            }
    
        }
        else if (etat == 2) //timeline in game mode
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
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4)); //Increment in the Text assets list for all players
                }
               
                etat = 1;
            }
            
        }
        else if (etat == 3) //conclusion is triggered if level = 2 and SBlevel = 3
        {
            mSend.SendMessageEndGame();

        }

    }

}

