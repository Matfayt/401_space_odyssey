using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class SendOSC : MonoBehaviour
{
    public OSC mOscControler;
    public PlayerControler[] mPlayers;
    public int i=0;

    public void SendMessage(int player, int button)
    {
    

                OscMessage message = new OscMessage();
                message.address = "/Event";
                message.values.Add(player + (i*6));
                message.values.Add(button);
                mOscControler.Send(message);
        

    }
}
