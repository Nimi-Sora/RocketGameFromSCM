using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AnimatorManager : MonoBehaviour
{
    public static volatile AnimatorManager instance = null;

    public AnimatorManager()
    { }
    public static AnimatorManager Instance()
    {
        if (instance == null)
        {
            instance = new AnimatorManager();
        }
        return instance;
    }

    private string currentState;
    public int animatorCtrl;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AnimatorCtrl(int animatorCtrl)
    {
        this.animatorCtrl = animatorCtrl;
        AnimationState();
    }

    // Update is called once per frame
    void AnimationState()
    {
        if (this.animatorCtrl == 0) return;

        else if (this.animatorCtrl == 1)
        {
            AnimatorTagCtrl.instance.AnimatorCtrl(1);
        }
        else if (this.animatorCtrl == 2)
        {
            AnimatorPlotCtrl.instance.AnimatorCtrl(1);
        }
        else if (this.animatorCtrl == 3)
        {
            AnimatorGitCtrl.instance.AnimatorCtrl(1);
        }
        else if (this.animatorCtrl == 4)
        {
            AnimatorRocketCtrl.instance.AnimatorCtrl(1);
        }
        else
        {

        }

    }

}
