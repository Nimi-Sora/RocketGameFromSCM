using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotHP : MonoBehaviour
{
    public static volatile RobotHP instance = null;//保证instance在所有线程中同步
                                                   //private防止类在外部被实例化
    public RobotHP()
    { }
    public static RobotHP Instance()
    {
        if (instance == null)
        {
            instance = new RobotHP();
        }
        return instance;
    }
    public int robotHp = 540000;
    bool loadGameCtrl=false;
    bool saveGameCtrl = false;
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
        robotHp = PlayerPrefs.GetInt("robotHp", 540000);
    }
    public void SaveGameData()//保存按钮关联------------------------------------------------------------------
    {
        PlayerPrefs.SetInt("robotHp", robotHp);
        PlayerPrefs.Save();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        robotHp -= 1;
        if (robotHp==0)
        {
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "游戏失败";
            AnimatorManager.instance.AnimatorCtrl(1);
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "游戏失败\n不是吧,这你都能输?\n这里建议亲Remake呢";
            AnimatorManager.instance.AnimatorCtrl(2);
        }
        if (robotHp==-500)
        {
            SceneLoader.instance.LoadTitleCtrl(true);
        }
    }
}
