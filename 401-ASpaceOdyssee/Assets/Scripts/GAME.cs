using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour

{
    public TextAsset mMidiFile;
    public Player mPlayer11;
    public OSC mOscChannel;

    void Start()
    {
        string content = mMidiFile.text;
        string[] lines = content.Split("; \n");
        foreach (string line in lines)
        {
            string[] values = line.Split (" ");
            for (int i=0; i< 4;i++)
            {
                //if (i == 3) values[i].Replace(";", "");
               // Debug.Log(int.Parse(Values));
            }
        }
    }

    
    void Update()
    {

    }
}

