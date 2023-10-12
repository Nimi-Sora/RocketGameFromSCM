using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterUnder : MonoBehaviour
{
    GameObject waterUnder;
    Image waterUnderImage;
    Transform cameraTransform;
    Vector3 cameraPosition;

    private void Start()
    {
        waterUnder = GameObject.FindWithTag("Water");
        waterUnderImage = waterUnder.GetComponent<Image>();
        cameraTransform = Camera.main.transform;        
    }

    private void Update()
    {
        cameraPosition = cameraTransform.position;
        if (cameraPosition.y < -0.5)
        {
            waterUnderImage.enabled = true;
        }
        else
        {
            waterUnderImage.enabled = false;
        }
    }
}
