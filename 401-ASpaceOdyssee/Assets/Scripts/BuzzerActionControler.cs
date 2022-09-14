using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BuzzerActionControler : MonoBehaviour
{
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    public float wait = 0.5f;
    bool mIsActive = false;

    IEnumerator ActiveAndWait()
    {
        GetComponent<MeshRenderer>().material = mActiveMaterial;
        yield return new WaitForSeconds(wait);
      
    }

    IEnumerator InactiveAndWait()
    {
        GetComponent<MeshRenderer>().material = mInactiveMaterial;
        yield return new WaitForSeconds(wait);

    }

    public void BuzzerPressed(bool a)
    {
        
            mIsActive = a;
            if (mIsActive)
            {
            StartCoroutine(ActiveAndWait());
            }
            else
            {
            StartCoroutine(InactiveAndWait());
            }
        
    }

}

