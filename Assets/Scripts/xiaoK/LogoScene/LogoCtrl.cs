using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogoCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadSceneTitle();
    }

    private void LoadSceneTitle()
    {
        StartCoroutine(LoadScene(1));
    }

    IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(4);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
