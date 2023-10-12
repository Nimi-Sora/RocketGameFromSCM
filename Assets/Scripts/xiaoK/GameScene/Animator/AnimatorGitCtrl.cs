using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGitCtrl : MonoBehaviour
{
    public static volatile AnimatorGitCtrl instance = null;

    public AnimatorGitCtrl()
    { }
    public static AnimatorGitCtrl Instance()
    {
        if (instance == null)
        {
            instance = new AnimatorGitCtrl();
        }
        return instance;
    }
    public Animator Gitin;
    const string GITIN = "Gitin";
    public int animatorCtrl = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Gitin = GetComponent<Animator>();
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
            Gitin.Play(GITIN);
            animatorCtrl = 0;
        }
        else 
        {
   
        }


    }

}
