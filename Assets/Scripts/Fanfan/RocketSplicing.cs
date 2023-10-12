using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketSplicing : MonoBehaviour
{
    public Image rocketSplicing;
    public Image rocketSplicing1;
    public Image rocketSplicing2;
    public Image rocketSplicing3;
    public Image rocketSplicing4;
    public Image rocketSplicing5;
    public Image rocketSplicing6;
    public Image rocketSplicing7;
    public Image rocketSplicing8;
    public Image rocketSplicing9;
    

    // Update is called once per frame
    void Update()
    {
        if (RocketBase.instance.RocketEnergy1 == 1)
        {
            rocketSplicing1.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy2 == 1)
        {
            rocketSplicing2.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy3 == 1)
        {
            rocketSplicing3.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy4 == 1)
        {
            rocketSplicing4.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy5 == 1)
        {
            rocketSplicing5.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy6 == 1)
        {
            rocketSplicing6.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy7 == 1)
        {
            rocketSplicing7.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy8 == 1)
        {
            rocketSplicing8.enabled = true;
        }
        if (RocketBase.instance.RocketEnergy9 == 1)
        {
            rocketSplicing9.enabled = true;
        }


        if (RocketBase.instance.maxRocket == 9)
        {

            rocketSplicing.enabled = true;
        }
    }
}
