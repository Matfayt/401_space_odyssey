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
    public int indexLevel;
    public int indexSBlevel;
    int checkTot = 0;


    public void CheckErrorByPlayer()
    {
        
        foreach(PlayerControler p in mPlayers)
        {
            if (p.CheckPlayer() == true)

                checkTot++;

            

        }
        Debug.Log("GAME_checkTot =" + checkTot);
    }


    public void ReceiveCurrentTime(float timing)
    {
        // mReceive.OnReceiveCurrentTime(timing);
        mCurrentLoopTime = timing;

    }




    void Start()
    {
        foreach (PlayerControler p in mPlayers)
        {
            p.InitializeLevel(indexLevel);
        }

        checkTot = 0;
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

        CheckErrorByPlayer();

      /* while (indexLevel <= 1)
        {
            while(indexSBlevel <= 3)
            {
                
                    

                    while(mCurrentLoopTime < 9600)
                {
                    CheckErrorByPlayer();
                    if (checkTot == 4)
                    {
                        indexSBlevel++;
                    }
                }







            }
        }*/

    }

}

