using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class Rocket9 : MonoBehaviour
{

    public static volatile Rocket9 instance = null;

    public Rocket9()
    { }
    public static Rocket9 Instance()
    {
        if (instance == null)
        {
            instance = new Rocket9();
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
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = "火箭核心";
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
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = "获得\n火箭核心";
                    AnimatorManager.instance.AnimatorCtrl(3);
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "核心已经损坏,但是里面有一具机器人残骸\n就用它的核心替代吧,希望它还能正常使用";
                    AnimatorManager.instance.AnimatorCtrl(2);

                    RocketBase.instance.RocketEnergy(9);
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