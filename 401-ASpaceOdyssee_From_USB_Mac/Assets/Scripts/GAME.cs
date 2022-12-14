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
    public GameObject mOrdi;
    public float mCurrentLoopTime = 0;
    float mPreviousCurrentTime = 10000.0f;
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
        mSend.SendMessageStartGame();
       // mAnimator = GetComponent<Animator>();
    }



    void Update()
    {
        mCurrentLoopTime = mReceive.GetCurrentTime();
        timeMs = mReceive.GetMs();
        mCurrentTicks = mReceive.GetCurrentTick();
        float timeNiv = timeMs % 19200;
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            check = true;
        }

        foreach (PlayerControler p in mPlayers)
        {
            p.setCurrentLevel(indexLevel, indexSBlevel, etat);
        }
        foreach (PlayerControler p in mPlayers)
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


        if (etat == 0)
        {
            
            if (timeMs > 96000.0f)
            {
              // mAnimator.Play("OdiDimController");
                etat = 1;
            }

        }

        else if (etat == 1)
        {
            //if (mPreviousCurrentTime != -1 && 0 <= mCurrentLoopTime && mPreviousCurrentTime >=0 )
            if(mCurrentLoopTime < mPreviousCurrentTime )
            {
                mSend.SendMessageExemple(indexLevel, indexSBlevel);

                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4));
                }

                Debug.Log("PreviousTime = ");
                Debug.Log("CurrentTime = "+mCurrentLoopTime);
                
                Debug.Log("Go");
                
            }

            

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
                    
                    Debug.Log("Bien Jou??");

                }

                foreach (PlayerControler p in mPlayers)
                {
                    p.InitializeLevel(indexSBlevel + (indexLevel * 4)); //Increment in the Text assets list for all players
                }

                //mSend.SendMessageExemple(indexLevel, indexSBlevel);

               
                etat = 1;
            }
            
        }
        else if (etat == 3)
        {
            
        
         mSend.SendMessageEndGame();

            etat = 4;

            
        }
        
        mPreviousCurrentTime = mCurrentLoopTime;








    }

}

