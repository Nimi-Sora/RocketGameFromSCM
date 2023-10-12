using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket4 : MonoBehaviour
{

    public static volatile Rocket4 instance = null;

    public Rocket4()
    { }
    public static Rocket4 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket4();
        }
        return instance;
    }
    public GameObject gameObject;
    public GameObject Tip;
    int RocketCtrl = 0;

    void Start()
    {
        instance = this;
    }

    public void RocketDestroy(int RocketCtrl)
    {
        this.RocketCtrl = RocketCtrl;
    }

    void FixedUpdate()
    {
        if (RocketCtrl == 1)
        {
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "火箭子一级发动机";
            GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.F))
            {
                FDown.Instance.FDownTrue();
                transform.Find("Particle").GetComponent<ParticleSystem>().Play();
                

                if (transform.localScale.x >= 0.5f)
                {

                    transform.localScale += new Vector3(-0.002f, 0, -0.002f);
                }

                else
                {
                    Destroy(Tip);
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n火箭子一级发动机";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "这东西长得像以前他们用的炉灶\n但是从那件事之后他们再也没用过这东西了";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(4);
                    GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(500, 0, 0);
                    Destroy(gameObject);
                    this.RocketCtrl = 0;
                }

            }
            else
            {
                FDown.Instance.FDownFalse();
            }

        }
    }

}