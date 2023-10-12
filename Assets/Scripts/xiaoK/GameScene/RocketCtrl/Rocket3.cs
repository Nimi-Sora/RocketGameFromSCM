using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket3 : MonoBehaviour
{

    public static volatile Rocket3 instance = null;

    public Rocket3()
    { }
    public static Rocket3 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket3();
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
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "火箭子一级";
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
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n火箭子一级";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "他们走之后\n天上掉下来很多和这些一模一样的东西\n应该是什么重要的部件吧";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(3);
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