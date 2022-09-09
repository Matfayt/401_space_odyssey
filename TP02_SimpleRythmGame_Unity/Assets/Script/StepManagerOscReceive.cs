using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManagerOscReceive : MonoBehaviour
{
    public int mUnityPrecision = 8;
    public int mStep = 0;
    int mUnit;
    GameObject[] mStepCubeObject; 
    public OSC mOscManager;
    public int mIndexTarget = 4;

    // Start is called before the first frame update
    void Start()
    {
        mStepCubeObject = new GameObject[transform.childCount];
        for (int i = 0; i< transform.childCount; i++)
        {
            mStepCubeObject[i] = transform.GetChild(i).gameObject;
        }

        mOscManager.SetAddressHandler("/AbletonStep", OnReceiveAbletonStep);
        mOscManager.SetAddressHandler("/AbletonUnit", OnReceiveAbletonUnit);
    }

    void OnReceiveAbletonStep(OscMessage message)
    {
        mStep = message.GetInt(0);
        
    }

    void OnReceiveAbletonUnit(OscMessage message)
    {
        mUnit = message.GetInt(0);
        

    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i< transform.childCount; i++)
        {
            if (i == mStep)
            {
                mStepCubeObject[i].GetComponent<ChangeTransparency>().setTransparent(false);
            }
            else
            {
                mStepCubeObject[i].GetComponent<ChangeTransparency>().setTransparent(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log(mUnit);
            Debug.Log(mStep);
            if ((mStep == mIndexTarget || mStep == mIndexTarget-1) && (mUnit < mUnityPrecision || mUnit > 480 - mUnityPrecision))
            {
                
                Debug.Log("Goooood !!!");
                GetComponent<StepManagerOscSend>().sendPlaySnare();
            }
            else
            {
                Debug.Log("Baaaaad !!!");
                GetComponent<StepManagerOscSend>().dontsendPlaySnare();
            }           
        }
    }
    
}
