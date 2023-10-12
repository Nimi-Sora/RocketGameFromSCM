using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneBase : MonoBehaviour
{
    public static volatile GameSceneBase instance = null;

    public GameSceneBase()
    { }
    public static GameSceneBase Instance()
    {
        if (instance == null)
        {
            instance = new GameSceneBase();
        }
        return instance;
    }

    int oreMaxCtrl = 0;
    int rocketMaxCtrl = 0;
    int finallyCtrl = 0;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    public void OreMaxCtrl(int oreMaxCtrl)
    {
        this.oreMaxCtrl = oreMaxCtrl;
        FinallyCtrl();
    }
    public void RocketMaxCtrl(int rocketMaxCtrl)
    {
        this.rocketMaxCtrl = rocketMaxCtrl;
        FinallyCtrl();
    }
    // Update is called once per frame

    public void FinallyCtrl()
    {
        if (oreMaxCtrl==1 && rocketMaxCtrl==0)
        {
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需能量已收集完毕";
            AnimatorManager.instance.AnimatorCtrl(3);
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余火箭部件";
            AnimatorManager.instance.AnimatorCtrl(1);
        }
        else if (oreMaxCtrl == 0 && rocketMaxCtrl == 1)
        {
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭起飞所需部件已收集完毕";
            AnimatorManager.instance.AnimatorCtrl(3);
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "tips:继续收集\n剩余矿石能量";
            AnimatorManager.instance.AnimatorCtrl(1);
        }
        else 
        {
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "火箭已准备就绪";
            AnimatorManager.instance.AnimatorCtrl(3);
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "Tag:请返回火箭发射架";
            AnimatorManager.instance.AnimatorCtrl(1);
            GameObject.FindGameObjectWithTag("Finally2").GetComponent<ParticleSystem>().Play();
        }

    }
    public void FinallyCtrl(int finallyCtrl)
    {
        this.finallyCtrl = finallyCtrl;
        Finally();
    }
    public void Finally()
    {
        if (this.finallyCtrl==1&& oreMaxCtrl == 1 && rocketMaxCtrl == 1)
        {
            GameObject.FindGameObjectWithTag("TagText").GetComponent<Text>().text = "成功";
            AnimatorManager.instance.AnimatorCtrl(1);
            Destroy(GameObject.FindGameObjectWithTag("Finally2"));
            GameObject.FindGameObjectWithTag("Finally1").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("Finally3").GetComponent<ParticleSystem>().Play();
            GameObject.FindGameObjectWithTag("PlotText").GetComponent<Text>().text = "终于收集完成了,一共收集了多少部件呢\n忘了它吧\n你会记得你至今吃过多少块面包吗? ";
            AnimatorManager.instance.AnimatorCtrl(2);
            AnimatorManager.instance.AnimatorCtrl(4);
            SceneLoader.instance.EndGameCtrl(true);
        }
    }
}
