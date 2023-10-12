using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTagCtrl : MonoBehaviour
{
    public static volatile AnimatorTagCtrl instance = null;

    public AnimatorTagCtrl()
    { }
    public static AnimatorTagCtrl Instance()
    {
        if (instance == null)
        {
            instance = new AnimatorTagCtrl();
        }
        return instance;
    }
    public Animator Tagin;
    const string TAGIN = "Tagin";
    public int animatorCtrl = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Tagin = GetComponent<Animator>();
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
            Tagin.Play(TAGIN);
            animatorCtrl = 0;
        }
        else
        {

        }


    }
}
