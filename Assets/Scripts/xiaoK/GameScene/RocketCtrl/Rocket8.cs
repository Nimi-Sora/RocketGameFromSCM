using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket8 : MonoBehaviour
{
    public static volatile Rocket8 instance = null;

    public Rocket8()
    { }
    public static Rocket8 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket8();
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
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "火箭子三级发动机";
            GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.F))
            {
                FDown.Instance.FDownTrue();
                transform.Find("Particle").GetComponent<ParticleSystem>().Play();
                

                if (transform.localScale.x >= 0.5f)
                {

                    transform.localScale += new Vector3(-0.002f, 0, 0);
                }

                else
                {
                    Destroy(Tip);
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n火箭子三级发动机";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "这东西长得像他们以前用的杯子\n但是我的记忆模块告诉我,我的主人曾经参与过这东西的研究\n在他的心中，这是很重要的东西";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(8);
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