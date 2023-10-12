using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Rocket1 : MonoBehaviour
{
    public static volatile Rocket1 instance = null;
                                                   
    public Rocket1()
    { }
    public static Rocket1 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket1();
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
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "一号助推器";
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
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n一号助推器";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "这东西和他们居住的地方一样笔直\n没想到居然这么容易就能拿到这东西\n应该很有用吧";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(1);
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


