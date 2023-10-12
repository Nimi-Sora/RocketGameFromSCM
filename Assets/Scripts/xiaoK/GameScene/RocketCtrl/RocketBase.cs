using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RocketBase : MonoBehaviour
{
    public static volatile RocketBase instance = null;

    public RocketBase()
    { }
    public static RocketBase Instance()
    {
        if (instance == null)
        {
            instance = new RocketBase();
        }
        return instance;
    }
    bool loadGameCtrl = false;
    bool saveGameCtrl = false;
    int RocketEnergyCtrl = 0;
    public int RocketEnergy1 = 0;
    public int RocketEnergy2 = 0;
    public int RocketEnergy3 = 0;
    public int RocketEnergy4 = 0;
    public int RocketEnergy5 = 0;
    public int RocketEnergy6 = 0;
    public int RocketEnergy7 = 0;
    public int RocketEnergy8 = 0;
    public int RocketEnergy9 = 0;
    public int maxRocket = 0;

    public void LoadGameCtrl(bool loadGameCtrl)
    {
        this.loadGameCtrl=loadGameCtrl;
        if (this.loadGameCtrl)
        {
            LoadGameRocket();
            this.loadGameCtrl = false;
        }
    }
    public void SaveGameCtrl(bool saveGameCtrl)
    {
        this.saveGameCtrl = saveGameCtrl;
        if (this.saveGameCtrl)
        {
            SaveGameData();
            this.saveGameCtrl = false;
        }
    }
    public void LoadGameRocket()
    {
        RocketEnergy1 = PlayerPrefs.GetInt("Rocket1", 0);
        RocketEnergy2 = PlayerPrefs.GetInt("Rocket2", 0);
        RocketEnergy3 = PlayerPrefs.GetInt("Rocket3", 0);
        RocketEnergy4 = PlayerPrefs.GetInt("Rocket4", 0);
        RocketEnergy5 = PlayerPrefs.GetInt("Rocket5", 0);
        RocketEnergy6 = PlayerPrefs.GetInt("Rocket6", 0);
        RocketEnergy7 = PlayerPrefs.GetInt("Rocket7", 0);
        RocketEnergy8 = PlayerPrefs.GetInt("Rocket8", 0);
        RocketEnergy9 = PlayerPrefs.GetInt("Rocket9", 0);
    }
    public void SaveGameData()
    {
        PlayerPrefs.SetInt("Rocket1", RocketEnergy1);
        PlayerPrefs.SetInt("Rocket2", RocketEnergy2);
        PlayerPrefs.SetInt("Rocket3", RocketEnergy3);
        PlayerPrefs.SetInt("Rocket4", RocketEnergy4);
        PlayerPrefs.SetInt("Rocket5", RocketEnergy5);
        PlayerPrefs.SetInt("Rocket6", RocketEnergy6);
        PlayerPrefs.SetInt("Rocket7", RocketEnergy7);
        PlayerPrefs.SetInt("Rocket8", RocketEnergy8);
        PlayerPrefs.SetInt("Rocket9", RocketEnergy9);
        PlayerPrefs.Save();
    }
    void Start()
    {
        instance = this;
    }

    public void RocketEnergy(int RocketEnergyCtrl)
    {
        this.RocketEnergyCtrl = RocketEnergyCtrl;
        RocketDispose();
    }

    // Update is called once per frame
    void RocketDispose()
    {
        if (this.RocketEnergyCtrl == 1)
        {
            RocketEnergy1 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
            //Debug.Log("dangqiannengliang==" + RocketEnergy1);
        }
        else if (this.RocketEnergyCtrl == 2)
        {
            RocketEnergy2 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 3)
        {
            RocketEnergy3 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 4)
        {
            RocketEnergy4 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 5)
        {
            RocketEnergy5 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 6)
        {
            RocketEnergy6 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 7)
        {
            RocketEnergy7 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 8)
        {
            RocketEnergy8 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        else if (this.RocketEnergyCtrl == 9)
        {
            RocketEnergy9 += 1;
            maxRocket += 1;
            this.RocketEnergyCtrl = 0;
        }
        if (maxRocket<9)
        {
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "Tips:继续收集剩余火箭部件\n剩余部件:" + (9 - maxRocket)+"个";
            AnimatorManager.instance.AnimatorCtrl(1);

        }
        else
        {
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需部件已收集完毕";
            AnimatorManager.instance.AnimatorCtrl(2);
            GameSceneBase.instance.RocketMaxCtrl(1);
        }

    }

}
