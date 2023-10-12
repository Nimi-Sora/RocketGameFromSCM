using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonlike : MonoBehaviour
{
    public void BackButton()
    {
        SceneLoader.instance.LoadTitleCtrl(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
