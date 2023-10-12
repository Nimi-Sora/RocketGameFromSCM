using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorRocketCtrl : MonoBehaviour
{
    public static volatile AnimatorRocketCtrl instance = null;

    public AnimatorRocketCtrl()
    { }
    public static AnimatorRocketCtrl Instance()
    {
        if (instance == null)
        {
            instance = new AnimatorRocketCtrl();
        }
        return instance;
    }
    public Animator Rocketin;
    const string ROCKETIN = "Rocketin";
    public int animatorCtrl = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Rocketin = GetComponent<Animator>();
    }
    public void AnimatorCtrl(int animatorCtrl)
    {
        this.animatorCtrl = animatorCtrl;
        AnimationState();
    }

    void AnimationState()
    {
        if (this.animatorCtrl == 0) return;

        else if (this.animatorCtrl == 1)
        {
            Rocketin.Play(ROCKETIN);
            animatorCtrl = 0;
        }
        else
        {

        }


    }

}
