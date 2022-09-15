using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControler : MonoBehaviour
{
    public TextAsset[] mMidiEventsLevel;
    public SendOSC Send;
    public BuzzerActionControler Buzzer1;
    public BuzzerActionControler Buzzer2;
    public int mIndexPlayer;
    public float tolerance = 50.0f;

    List<Target> mTargetsList = new List<Target>();
    float mCurrentLoopTime;
    int indexLevel, indexSBLevel, indexEtat;
    
    int v;
    int nbTarget, nbTouch;
    bool mIsActive = false;
    int check;
    int triggerExemple = 0;


    public bool mIsDemo;
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


    public bool CheckPlayer()
    {
        bool checkPlayer = false;

        if (/*nbTouch == nbTarget & */v == nbTarget)
        {
            checkPlayer = true;
        }

        return checkPlayer;

    }


    public void BuzzerButton1_Pressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // check if user action is good !!!
          

            mIsActive =! mIsActive;
            if (indexEtat == 2)
            {
                if (mIsActive)
                {

                    Buzzer1.BuzzerPressed(true);
                    Send.SendMessageEvent(mIndexPlayer, 0, 0);
                    v++;
                    Debug.Log("Player" + mIndexPlayer + "_essais = " + v);
                    bool check;
                    if (check = IsActionValid(0))
                    {
                        nbTouch++;
                    }
                    mIsActive = !mIsActive;

                }
                else
                {
                    Buzzer1.BuzzerPressed(false);
                }
            }
            else
            {
                if (mIsActive)
                {
                    mIsActive = !mIsActive;
                }
            }

        }
    }
    public void BuzzerButton2_Pressed(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            // check if user action is good !!!
            //IsActionValid(1);

            
            mIsActive = !mIsActive;
            if (indexEtat == 2)
            {

                if (mIsActive)
                {
                    Buzzer2.BuzzerPressed(true);
                    Send.SendMessageEvent(mIndexPlayer, 1,0);
                    v++;
                    Debug.Log("Player"+ mIndexPlayer + "_essais = " + v);
                    bool check;
                    if (check = IsActionValid(0))
                    {
                        nbTouch++;
                    }
                    mIsActive = !mIsActive;
                
                
                }
                else
                {
                    Buzzer2.BuzzerPressed(false);
                }
            }
            else
            {
                if (mIsActive)
                {
                    mIsActive = !mIsActive;
                }
            }
        }
    }

    public void Exemple()
    {
        Debug.Log("TriggerExemple = " + triggerExemple);
        if (indexEtat == 1) { 
            foreach (Target t in mTargetsList)
            {   
                if (mCurrentLoopTime >= t.mStartTime && mCurrentLoopTime<=t.mEndTime)
                {
                    triggerExemple++;
                }
                
                    if (t.mIndexButton == 0)
                    {
                        if (triggerExemple == 1)
                        {
                            Buzzer1.DispExemple();
                        }
                    }
                    else
                    {
                        if (triggerExemple == 1)
                        {
                            Buzzer2.DispExemple();
                        }
                    }
                

            }
        }
    }




    public void InitializeLevel(int indexList) //Pour tout level
    {
        if (indexList < mMidiEventsLevel.Length)
        {
            fillTargets(mMidiEventsLevel[indexList]);

        }

        v = 0;
        nbTouch = 0;
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
            Debug.Log("nbTarget_" + mIndexPlayer + "= " + nbTarget);
        }
        foreach (Target t in mTargetsList)
        {
            Debug.Log("Liste_" + mIndexPlayer + "= " + t.mStartTime + " " + t.mEndTime + " " + t.mIndexButton);
           
        }

    }

    public void setCurrentTime(float time)
    {
        mCurrentLoopTime = time;

        if (mIsDemo == true)
        {
            

        }
    }

    public void setCurrentLevel(int level, int subLevel,int etat)
    {
       indexLevel = level;
       indexSBLevel = subLevel;
        indexEtat = etat;
       
    }

}
