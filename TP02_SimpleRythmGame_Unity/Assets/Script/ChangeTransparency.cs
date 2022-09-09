using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public bool mIsTransparent = true;
    Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<MeshRenderer>().material.color;
    }

    public void setTransparent(bool isTransparent)
    {
        mIsTransparent = isTransparent;
        if (isTransparent)
        {
            GetComponent<MeshRenderer>().material.color = OriginalColor;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = new Color(OriginalColor.r, OriginalColor.g, OriginalColor.b, 1f);
        }
    }

}
