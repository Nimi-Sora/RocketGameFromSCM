using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlotCtrl : MonoBehaviour
{
    public static volatile AnimatorPlotCtrl instance = null;

    public AnimatorPlotCtrl()
    { }
    public static AnimatorPlotCtrl Instance()
    {
        if (instance == null)
        {
            instance = new AnimatorPlotCtrl();
        }
        return instance;
    }
    public Animator Plotin;
    const string PLOTIN = "Plotin";
    public int animatorCtrl = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Plotin = GetComponent<Animator>();
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
            Plotin.Play(PLOTIN);
            animatorCtrl = 0;
        }
        else
        {

        }


    }
}
