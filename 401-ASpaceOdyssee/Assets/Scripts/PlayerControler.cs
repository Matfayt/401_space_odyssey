using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public TextAsset[] mMidiEventsLevel;
    public GAME gameControler;
    public SendOSC Send;
    List<Target> mTargetsList = new List<Target>();
    float mCurrentLoopTime;
    int indexLevel;
    
    public int mIndexPlayer;
    int v =0;
    int nbTarget;
    bool mIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsActionValid(int indexButton)
    {
        bool isValid = false;

        foreach(Target t in mTargetsList)
        {
            if(mCurrentLoopTime >= t.mStartTime && mCurrentLoopTime <= t.mEndTime && t.mIndexButton == indexButton)
            {
                isValid = true;
            }
        }
        return isValid;
    }

    public void BuzzerButton1_Pressed(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            // check if user action is good !!!
            if (IsActionValid(0))
            {
                v ++; 
                gameControler.CheckErrorByPlayer(mIndexPlayer);

            }

        mIsActive =! mIsActive;
        if (mIsActive)
        {
            Send.SendMessage(mIndexPlayer, 0);
        }
            
        }
    }

    public void CheckPlayer(int mIndexPlayer)
    {
        
        if(v == nbTarget)
        {
            gameControler.CheckErrorByPlayer(mIndexPlayer);
        }
    }

    public void BuzzerButton2_Pressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // check if user action is good !!!
            if (IsActionValid(0))
            {
                v++;
                gameControler.CheckErrorByPlayer(mIndexPlayer);
            }

        mIsActive =! mIsActive;
        if (mIsActive)
        {

            Send.SendMessage(mIndexPlayer, 1);
        }

        }
    }


    public void InitializeLevel(int indexLevel)
    {
        if (indexLevel < mMidiEventsLevel.Length)
        {
            v = 0;

            fillTargets(mMidiEventsLevel[indexLevel]);
        }
    }

    

    void fillTargets(TextAsset textAsset)
    {

        mTargetsList.Clear();
        string[] lines = textAsset.text.Split(";\n");
        nbTarget = lines.Length / 2;

        // Parse the text file to get targets info
        for (int i = 0; i< nbTarget; i++)
        {
            // get note on / note off infos
            string[] noteOnInfo = lines[i].Split(" ");
            string[] noteOffInfo = lines[i+1].Split(" ");

            // create a new target
            Target target = new Target();

            // fill information about target
            target.mStartTime = float.Parse(noteOnInfo[0]) - 0.01f;
            target.mEndTime = float.Parse(noteOnInfo[0]) + 0.01f;
            if (int.Parse(noteOnInfo[3]) == 1 || int.Parse(noteOnInfo[3]) == 50 || int.Parse(noteOnInfo[3]) == 100 || int.Parse(noteOnInfo[3]) == 126)
                target.mIndexButton = 0;
            else
                target.mIndexButton = 1;

            // Add target to the list
            mTargetsList.Add(target);
        }

    }

    public void setCurrentTime(float time)
    {
        mCurrentLoopTime = time;
    }

    public void getCurrentLevel(int level)
    {
        indexLevel = level;
    }

}
