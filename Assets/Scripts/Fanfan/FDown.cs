using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FDown : MonoBehaviour
{
    static FDown instance;
    public static FDown Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FDown>();
            }
            return instance;
        }
    }

    RawImage fDown;

    void Awake()
    {
        fDown = GetComponent<RawImage>();
    }

    public void FDownTrue()
    {
        fDown.enabled = true;
    }

    public void FDownFalse()
    {
        fDown.enabled=false;
    }
}
