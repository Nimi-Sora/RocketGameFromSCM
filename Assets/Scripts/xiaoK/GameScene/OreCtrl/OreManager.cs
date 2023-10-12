using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OreManager : MonoBehaviour
{

    public static volatile OreManager instance = null;
                                                  
    public OreManager()
    { }
    public static OreManager Instance()
    {
        if (instance == null)
        {
            instance = new OreManager();
        }
        return instance;
    }
    private new GameObject gameObject;
    string OreCtrl;
    int FCtrl;
    string FText;
    string GitText;
    private int intA;
    private int intB;
    void Start()
    {
        instance = this;
    }

    public void OreManagerCtrl(string OreCtrl)
    {
        Debug.Log("执行2");
        this.OreCtrl = OreCtrl;
        if (this.OreCtrl=="666")
        {

        }
        else
        {
            gameObject = GameObject.FindGameObjectWithTag(this.OreCtrl);
        }
        
        Debug.Log("执行3");

        intA = int.Parse(this.OreCtrl);
        if (0 <= intA && intA < 10)
        {
            FText = "火石";
            GitText = "获得火石能量×1";
            intB = 1;
            this.FCtrl = 1;
        }
        else if (10 <= intA && intA < 20)
        {
            FText = "粉宝石";
            GitText = "获得粉宝石能量×1";
            intB = 2;
            this.FCtrl = 1;
        }
        else if (20 <= intA && intA < 30)
        {
            FText = "蓝宝石";
            GitText = "获得蓝宝石能量×1";
            intB = 3;
            this.FCtrl = 1;
        }
        else if (30 <= intA && intA < 40)
        {
            FText = "黄宝石";
            GitText = "获得黄宝石能量×1";
            intB = 4;
            this.FCtrl = 1;
        }
        else if (40 <= intA && intA < 50)
        {
            FText = "黑曜石";
            GitText = "获得黑曜石能量×1";
            intB = 5;
            this.FCtrl = 1;
        }
        else if (50 <= intA && intA < 60)
        {
            FText = "绿宝石";
            GitText = "获得绿宝石能量×1";
            intB = 6;
            this.FCtrl = 1;
        }
        else
        {
            FText = null;
            this.FCtrl = 0;
        }

    }

    void FixedUpdate()
    {
        if (FCtrl == 1)
        {
            GameObject.FindGameObjectWithTag("FButtonText").GetComponent<Text>().text = FText;
            GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(0, 0, 0);

            if (Input.GetKeyDown(KeyCode.F))
            {
                gameObject.transform.Find("Particle").GetComponent<ParticleSystem>().Play();
            }
            if (Input.GetKey(KeyCode.F))
            {
                FDown.Instance.FDownTrue();

                if (gameObject.transform.localScale.y >= 0.5f)
                {

                    gameObject.transform.localScale += new Vector3(0, -0.01f, 0);
                }

                else
                {
                    GameObject.FindGameObjectWithTag("GitText").GetComponent<Text>().text = GitText;
                    AnimatorManager.instance.AnimatorCtrl(3);

                    OreBase.instance.OreEnergy(intB);
                    GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(500, 0, 0);
                    Destroy(gameObject);
                    this.OreCtrl = null;
                    FCtrl = 0;
                }

            }
            else
            {
                FDown.Instance.FDownFalse();
            }

        }
    }


}
