using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class SendOSC : MonoBehaviour
{
    public OSC mOscControler;
    public PlayerControler[] mPlayers;
    

//Fires clips when button is pressed (wich button wich player and +i to locate a track when level up)
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

//Sends message to fire target sounds 
    public void SendMessageExemple(int i, int j)
    {
        OscMessage message = new OscMessage();
        message.address = "/Exemple";
        message.values.Add((i*6));
        message.values.Add(j);
        mOscControler.Send(message);
    }

//Sends message to fire loop sounds
    public void SendMessageLoop(int i, int j)
    {
        OscMessage message = new OscMessage();
        message.address = "/Loop";
        message.values.Add((i*6 )+ 5);
        message.values.Add(j);
        mOscControler.Send(message);
    }

//Stops a clip (x = track & y = clip)
    public void SendMessageStop(int x, int y)
    {
        OscMessage message = new OscMessage();
        message.address = "/Stop";
        message.values.Add(x);
        message.values.Add(y);
        mOscControler.Send(message);
    }

//Stop all clips from all tracks
    public void SendMessageStopAll()
    {
        OscMessage message = new OscMessage();
        message.address = "/StopAll";
        message.values.Add(0);
        mOscControler.Send(message);
    }

//Start all background sounds for all the game (starts ableton project and TRANSPORT)
    public void SendMessageStartGame()
    {
        OscMessage message = new OscMessage();
        message.address = "/StartGame";
        message.values.Add(1);
        mOscControler.Send(message);
    }

//Start ending storyline loops (end of game after Loop 3 Lvl3)
    public void SendMessageEndGame()
    {  
        OscMessage message = new OscMessage();
        message.address = "/EndGame";
        message.values.Add(1);
        mOscControler.Send(message);
    }
}
