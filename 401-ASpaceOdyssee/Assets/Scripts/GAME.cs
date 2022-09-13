using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GAME : MonoBehaviour

{
    public PlayerControler[] mPlayers;
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
        
        mOscChannel.SetAddressHandler("/CurrentTime", OnReceiveCurrentTime);
        foreach(PlayerControler p in mPlayers)
        {
            p.getCurrentLevel(indexLevel);
        }
    }

    void OnReceiveCurrentTime(OscMessage message)
    {
        mCurrentLoopTime = message.GetFloat(0);
        Debug.Log("Current Time = " + mCurrentLoopTime);
        foreach(PlayerControler p in mPlayers)
        {
            p.setCurrentTime(mCurrentLoopTime);
        }
    }

    void Update()
    {
       





    }

 /*   void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            // Do Something with the input. 
        }

        inp_stm.Close();
    }*/
}

