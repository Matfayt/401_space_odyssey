using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDIRead : MonoBehaviour

{
    public TextAsset mMidiFile;
    // Start is called before the first frame update
    void Start()
    {
        string content = mMidiFile.text;
        string[] lines = content.Split("\n");
        foreach (string line in lines)
        {
            string[] values = line.Split (" ");
            for (int i=0; i< 4;i++)
            {
                //if (i == 3) values[i].Replace(";", "");
                Debug.Log(int.Parse(value));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
{
    public TextAsset mMidiFile;

    // Start is called before the first frame update
    void Start()
    {
        string content = mMidiFile.text;
        string lines = content.Split("\n");
        foreach (string line in lines) ;
        
        {
            string ;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/