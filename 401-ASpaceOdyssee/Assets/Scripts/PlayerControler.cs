using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public TextAsset[] mMidiEventsLevel;
    public SendOSC Send;
    public BuzzerActionControler Buzzer1;
    public BuzzerActionControler Buzzer2;
    public int mIndexPlayer;
    public float tolerance = 5.0f;

    List<Target> mTargetsList = new List<Target>();
    float mCurrentLoopTime;
    int indexLevel;
    
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

            }

        mIsActive =! mIsActive;
        if (mIsActive)
            {
                Buzzer1.BuzzerPressed(true);
                Send.SendMessage(mIndexPlayer, 0);
                Buzzer1.BuzzerPressed(false);
            }
            else
            {
                
            }
            
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
            }

            mIsActive = !mIsActive;
            if (mIsActive)
            {
                Buzzer2.BuzzerPressed(true);
                Send.SendMessage(mIndexPlayer, 1);
                Buzzer2.BuzzerPressed(false);
            }
            else
            {
                
            }

        }
    }

    public int CheckPlayer(int mIndexPlayer)
    {
        int check = 0;
        if(v == nbTarget)
        {

            check = 1;
        }
        else
        {
            check = 0;
        }
        return check;
    }

    public void InitializeLevel(int indexLevel) //Pour tout level
    {
        if (indexLevel < mMidiEventsLevel.Length)
        {
            fillTargets(mMidiEventsLevel[indexLevel]);
        }

        v = 0;
    }

    

    void fillTargets(TextAsset textAsset)
    {

        mTargetsList.Clear();
        string[] lines = textAsset.text.Split(";\n");
        nbTarget = lines.Length / 2;

        // Parse the text file to get targets info
        for (int i = 0; i< nbTarget; i+=2)
        {
            // get note on / note off infos
            string[] noteOnInfo = lines[i].Split(" ");
            //string[] noteOffInfo = lines[i+1].Split(" ");

            // create a new target
            Target target = new Target();

            // fill information about target
            target.mStartTime = float.Parse(noteOnInfo[0]) - tolerance;
            target.mEndTime = float.Parse(noteOnInfo[0]) + tolerance;
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

    public void setCurrentLevel(int level)
    {
        indexLevel = level;
    }

}
