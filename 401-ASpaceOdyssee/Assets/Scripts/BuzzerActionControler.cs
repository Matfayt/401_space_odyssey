using UnityEngine;
using UnityEngine.InputSystem;

public class BuzzerActionControler : MonoBehaviour
{
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    bool mIsActive = false;

    public void BuzzerPressed(bool a)
    {
        
            mIsActive = a;
            if (mIsActive)
            {
                GetComponent<MeshRenderer>().material = mActiveMaterial;
            }
            else
            {
                GetComponent<MeshRenderer>().material = mInactiveMaterial;
            }
        
    }

}

