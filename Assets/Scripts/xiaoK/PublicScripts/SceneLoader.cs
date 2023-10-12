using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public static volatile SceneLoader instance = null;
    bool loadTitleCtrl=false;
    bool endGameCtrl=false;
    bool loadGame = false;
    bool loadGameCtrl = false;
    public SceneLoader()
    { }
    public static SceneLoader Instance()
    {
        if (instance == null)
        {
            instance = new SceneLoader();
        }
        return instance;
    }
    public Button NewGameButton;

    public Button ExitGameButton;

    //public Button buttonB;
    public Animator animator;
    // Start is called before the first frame update
    public GameObject eventObj;

    public GameObject TitleSceneButton;
    public GameObject TitleSceneBackground;
    void Start()
    {
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);
        NewGameButton.onClick.AddListener(LoadSceneA);
        
        ExitGameButton.onClick.AddListener(LoadSceneC);
    }

    private void LoadSceneA()
    {
        StartCoroutine(LoadCGScene(2));
    }

    private void LoadSceneB()
    {
        loadGameCtrl = true;
        StartCoroutine(LoadGame(3));
    }
    public void LoadTitleCtrl(bool loadTitleCtrl)
    {
        this.loadTitleCtrl = loadTitleCtrl;
        if (this.loadTitleCtrl)
        {
            LoadSceneD();
            this.loadTitleCtrl = false;
        }
    }


    private void LoadSceneC()
    {
        Application.Quit();
    }

    public void LoadGame(bool loadGame)
    {
        this.loadGame = loadGame;
        if (this.loadGame)
        {
            DataGameManager.instance.LoadGameCtrl(true);
            this.loadGame = false;   
        }
    }

    public void EndGameCtrl(bool endGameCtrl)
    {
        this.endGameCtrl = endGameCtrl;
        if (this.endGameCtrl)
        {
            LoadSceneE();
            this.endGameCtrl=false;
        }
    }
    public void LoadSceneD()
    {
            StartCoroutine(LoadTitle(1));
    }

    public void LoadSceneE()
    {
        StartCoroutine(EndGame(4));
    }

    IEnumerator LoadCGScene(int index)
    {
        animator.SetBool("Fadein",true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoanedScene;
        TitleSceneButton.transform.position = new Vector3(-960, 540, 0);
        TitleSceneBackground.transform.position = new Vector3(-960, 540, 0);
    }

    private void OnLoanedScene(AsyncOperation obj)
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
        
        LoadGameScene();

    }
    private void LoadGameScene()
    {
        StartCoroutine(LoadGameScene(3));
    }

    IEnumerator LoadGameScene(int index)
    {
        yield return new WaitForSeconds(116);

        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoanedGameScene;

    }

    private void OnLoanedGameScene(AsyncOperation obj)
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);


    }









    IEnumerator LoadGame(int index)
    {
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoanedGame;
        TitleSceneButton.transform.position = new Vector3(-960, 540, 0);
        TitleSceneBackground.transform.position = new Vector3(-960, 540, 0);
        yield return new WaitForSeconds(5);
    }

    private void OnLoanedGame(AsyncOperation obj)
    {
        
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);

    }


    IEnumerator LoadTitle(int index)
    {
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadTitle;
        TitleSceneButton.transform.position = new Vector3(-960, 540, 0);
        TitleSceneBackground.transform.position = new Vector3(-960, 540, 0);
    }

    private void OnLoadTitle(AsyncOperation obj)
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);

    }












    IEnumerator EndGame(int index)
    {
        yield return new WaitForSeconds(15);
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnEndGame;
        TitleSceneButton.transform.position = new Vector3(-960, 540, 0);
        TitleSceneBackground.transform.position = new Vector3(-960, 540, 0);
    }

    private void OnEndGame(AsyncOperation obj)
    {
        Debug.Log("运行1");
        animator.SetBool("Fadein", false);
        Debug.Log("运行2");
        animator.SetBool("Fadeout", true);
        Debug.Log("运行3");

        StartCoroutine(LoadTitles(1));
        Debug.Log("运行4");
    }

    IEnumerator LoadTitles(int index)
    {
        Debug.Log("运行5");
        yield return new WaitForSeconds(156);
        Debug.Log("运行6");
        animator.SetBool("Fadein", true);
        Debug.Log("运行7");
        animator.SetBool("Fadeout", false);
        Debug.Log("运行8");

        yield return new WaitForSeconds(1);
        Debug.Log("运行9");

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        Debug.Log("运行10");
        async.completed += OnLoadTitles;
        Debug.Log("运行11");
        TitleSceneButton.transform.position = new Vector3(-960, 540, 0);
        Debug.Log("运行12");
        TitleSceneBackground.transform.position = new Vector3(-960, 540, 0);
        Debug.Log("运行13");
    }

    private void OnLoadTitles(AsyncOperation obj)
    {
        animator.SetBool("Fadein", false);
        Debug.Log("运行14");
        animator.SetBool("Fadeout", true);
        Debug.Log("运行15");

    }
}








