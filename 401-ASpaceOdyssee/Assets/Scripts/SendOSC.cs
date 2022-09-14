using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class SendOSC : MonoBehaviour
{
    public OSC mOscControler;
    public PlayerControler[] mPlayers;
    

    public void SendMessageEvent(int player, int button, int i)
    {

        int track = player + (i * 6);
        Debug.Log("Track = " + track);
        OscMessage message = new OscMessage();
        message.address = "/Event";
        message.values.Add(track);
        message.values.Add(button);
        mOscControler.Send(message);
        

    }

    public void SendMessageExemple(int i, int j)
    {
        OscMessage message = new OscMessage();
        message.address = "/Exemple";
        message.values.Add(i);
        message.values.Add(j);
        mOscControler.Send(message);

    }

    public void SendMessageLoop(int i, int j)
    {
        OscMessage message = new OscMessage();
        message.address = "/Loop";
        message.values.Add(i + 6);
        message.values.Add(j - 1);
        mOscControler.Send(message);
    }

    public void SendMessageStop(int x, int y)
    {
        OscMessage message = new OscMessage();
        message.address = "/Stop";
        message.values.Add(x);
        message.values.Add(y);
        mOscControler.Send(message);
    }

    public void SendMessageStopAll()
    {
        OscMessage message = new OscMessage();
        message.address = "/StopAll";
        message.values.Add(0);
        mOscControler.Send(message);
    }
}
