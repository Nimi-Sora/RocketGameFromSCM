using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class Rocket7 : MonoBehaviour
{

    public static volatile Rocket7 instance = null;

    public Rocket7()
    { }
    public static Rocket7 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket7();
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
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "火箭子三级";
            GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.F))
            {
                FDown.Instance.FDownTrue();
                transform.Find("Particle").GetComponent<ParticleSystem>().Play();
                

                if (transform.localScale.y >= 0.5f)
                {

                    transform.localScale += new Vector3(0, -0.002f, 0);
                }

                else
                {
                    Destroy(Tip);
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n火箭子三级";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "我曾经见过许多长得像这个东西的家伙\n但是我从未见过他们在天上是什么样子\n但愿它能让我见识一下那是什么场景";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(7);
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