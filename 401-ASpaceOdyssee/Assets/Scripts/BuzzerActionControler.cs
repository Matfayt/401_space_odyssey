using UnityEngine;
using UnityEngine.InputSystem;

public class BuzzerActionControler : MonoBehaviour
{
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    bool mIsActive = false;

    public void BuzzerPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            mIsActive = !mIsActive;
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
}



