using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipScale : MonoBehaviour
{
    Transform miniMapCamera;
    Transform tip;


    void Start()
    {
        miniMapCamera = GameObject.FindGameObjectWithTag("MiniMap").transform;
        tip = GetComponent<Transform>();
    }

    void Update()
    {
        if (miniMapCamera.position.y < 300)
        {
            tip.localScale = new Vector3(20, 20, 1);
        }
        else if (miniMapCamera.position.y > 500)
        {
            tip.localScale = new Vector3(60, 60, 3);

        }
        else
        {
            tip.localScale = new Vector3(40, 40, 2);
        }
        
    }
}
