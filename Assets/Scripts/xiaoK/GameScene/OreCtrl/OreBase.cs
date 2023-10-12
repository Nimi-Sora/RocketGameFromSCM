using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class OreBase : MonoBehaviour
{

    public static volatile OreBase instance = null;//保证instance在所有线程中同步
                                                          //private防止类在外部被实例化
    public OreBase()
    { }
    public static OreBase Instance()
    {
        if (instance == null)
        {
            instance = new OreBase();
        }
        return instance;
    }

    bool loadGameCtrl = false;
    bool saveGameCtrl = false;

    public GameObject Square1;
    public GameObject Square2;
    public GameObject Square3;
    public GameObject Square4;
    public GameObject Square5;
    public GameObject Square6;

    private string currentState;
    int OreEnergyCtrl = 0;
    public int OreEnergy1 = 0;
    public int OreEnergy2 = 0;
    public int OreEnergy3 = 0;
    public int OreEnergy4 = 0;
    public int OreEnergy5 = 0;
    public int OreEnergy6 = 0;
    public int maxOre = 0;

    bool oreEnd1 = false;
    bool oreEnd2 = false;
    bool oreEnd3 = false;
    bool oreEnd4 = false;
    bool oreEnd5 = false;
    bool oreEnd6 = false;

    public void LoadGameCtrl(bool loadGameCtrl)
    {
        this.loadGameCtrl = loadGameCtrl;
        if (this.loadGameCtrl)
        {
            LoadGameOre();
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

    public void LoadGameOre()
    {
        OreEnergy1 = PlayerPrefs.GetInt("Ore1", 0);
        OreEnergy2 = PlayerPrefs.GetInt("Ore2", 0);
        OreEnergy3 = PlayerPrefs.GetInt("Ore3", 0);
        OreEnergy4 = PlayerPrefs.GetInt("Ore4", 0);
        OreEnergy5 = PlayerPrefs.GetInt("Ore5", 0);
        OreEnergy6 = PlayerPrefs.GetInt("Ore6", 0);
    }
    public void SaveGameData()//保存按钮激活-----------------------------
    {
        PlayerPrefs.SetInt("Ore1", OreEnergy1);
        PlayerPrefs.SetInt("Ore2", OreEnergy2);
        PlayerPrefs.SetInt("Ore3", OreEnergy3);
        PlayerPrefs.SetInt("Ore4", OreEnergy4);
        PlayerPrefs.SetInt("Ore5", OreEnergy5);
        PlayerPrefs.SetInt("Ore6", OreEnergy6);
        PlayerPrefs.Save();
    }


    void Start()
    {
        instance = this;

    }

    public void OreEnergy(int OreEnergyCtrl)
    {
        this.OreEnergyCtrl = OreEnergyCtrl;
        OreDispose();
    }


    // Update is called once per frame
    void OreDispose()
    {
        if (this.OreEnergyCtrl == 1)
        {
            OreEnergy1 += 1;
            maxOre += 1;
            if (OreEnergy1<6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得火石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy1==6)
            {
                oreEnd1 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需火石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }
                
            }
            else if (OreEnergy1 > 6&& OreEnergy1 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n火石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy1 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部火石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);

                }
                Destroy(Square1);
            }
            else
            {

            }

            this.OreEnergyCtrl=0;
            //Debug.Log("dangqiannengliang==" + OreEnergy1);
        }
        else if (this.OreEnergyCtrl == 2)
        {
            maxOre += 1;
            OreEnergy2 += 1;
            if (OreEnergy2 < 6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得粉宝石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy2 == 6)
            {
                oreEnd2 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需粉宝石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }

            }
            else if (OreEnergy2 > 6 && OreEnergy2 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n粉宝石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy2 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部粉宝石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);

                }
                Destroy(Square2);
            }
            else
            {

            }

            this.OreEnergyCtrl = 0;
        }
        else if (this.OreEnergyCtrl == 3)
        {
            OreEnergy3 += 1;
            maxOre += 1;
            if (OreEnergy3 < 6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得蓝宝石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy3 == 6)
            {
                oreEnd3 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需蓝宝石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }

            }
            else if (OreEnergy3 > 6 && OreEnergy3 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n蓝宝石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy3 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部蓝宝石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);

                }
                Destroy(Square3);
            }
            else
            {

            }

            this.OreEnergyCtrl = 0;
        }
        else if (this.OreEnergyCtrl == 4)
        {
            OreEnergy4 += 1;
            maxOre += 1;
            if (OreEnergy4 < 6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得黄宝石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy4 == 6)
            {
                oreEnd4 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需黄宝石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }

            }
            else if (OreEnergy4 > 6 && OreEnergy4 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n黄宝石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy4 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部黄宝石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);

                }
                Destroy(Square4);
            }
            else
            {

            }

            this.OreEnergyCtrl = 0;
        }
        else if (this.OreEnergyCtrl == 5)
        {
            OreEnergy5 += 1;
            maxOre += 1;
            if (OreEnergy5 < 6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得黑曜石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy5 == 6)
            {
                oreEnd5 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需黑曜石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }

            }
            else if (OreEnergy5 > 6 && OreEnergy5 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n黑曜石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy5 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部黑曜石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);

                }
                Destroy(Square5);
            }
            else
            {

            }

            this.OreEnergyCtrl = 0;
        }
        else if (this.OreEnergyCtrl == 6)
        {
            OreEnergy6 += 1;
            maxOre += 1;
            if (OreEnergy6 < 6)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得绿宝石能量\n继续收集剩余矿石";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy6 == 6)
            {
                oreEnd6 = true;
                if (!oreEnd1 || !oreEnd2 || !oreEnd3 || !oreEnd4 || !oreEnd5 || !oreEnd6)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需绿宝石能量已经收集完毕";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    OreFinallyEnd();
                }

            }
            else if (OreEnergy6 > 6 && OreEnergy6 < 10)
            {
                GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得\n绿宝石能量";
                AnimatorManager.instance.AnimatorCtrl(1);

            }
            else if (OreEnergy6 == 10)
            {
                if (maxOre == 60)
                {
                    GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "已收集地图上的所有矿石\n你就是挖矿小子吧\n隐藏成就:Vme60矿,挖矿疯狂星期四";
                    AnimatorManager.instance.AnimatorCtrl(2);
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:获得成就";
                    AnimatorManager.instance.AnimatorCtrl(1);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:已收集\n全部绿宝石能量";
                    AnimatorManager.instance.AnimatorCtrl(1);
                    
                }
                Destroy(Square6);
            }
            else
            {

            }

            this.OreEnergyCtrl = 0;
        }


    }
    public void OreFinallyEnd()
    {
        GameSceneBase.instance.OreMaxCtrl(1);
    }

}
