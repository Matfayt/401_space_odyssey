using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BuzzerActionControler : MonoBehaviour
{
    public Material mActiveMaterial;
    public Material mInactiveMaterial;
    public float wait = 1.0f;
    bool mIsActive = false;

    IEnumerator ActiveAndWait()
    {
        GetComponent<MeshRenderer>().material = mActiveMaterial;
        yield return new WaitForSeconds(wait);
        GetComponent<MeshRenderer>().material = mInactiveMaterial;
        


    }

    IEnumerator ActiveAndWaitExemple()
    {
        yield return new WaitForSeconds(wait);
        GetComponent<MeshRenderer>().material = mInactiveMaterial;
        


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
            GetComponent<MeshRenderer>().material = mInactiveMaterial;
            }
        
    }

    public void DispExemple()
    {
        GetComponent<MeshRenderer>().material = mActiveMaterial;
        Debug.Log("");
        StartCoroutine(ActiveAndWaitExemple());
        
    }

}

