using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGameManager : MonoBehaviour
{
    public static volatile DataGameManager instance = null;

    public DataGameManager()
    { }
    public static DataGameManager Instance()
    {
        if (instance == null)
        {
            instance = new DataGameManager();
        }
        return instance;
    }
    bool loadGameCtrl = false;
    public void Awake()
    {
        instance=this;
    }
    public void LoadGameCtrl(bool loadGameCtrl)
    {
        this.loadGameCtrl = loadGameCtrl;
        if (this.loadGameCtrl)
        {
            LoadGame();
            this.loadGameCtrl=false;
        }
    }

    public void LoadGame()
    {
        OreBase.instance.LoadGameCtrl(true);
        RobotHP.instance.LoadGameCtrl(true);
        RocketBase.instance.LoadGameCtrl(true);
    }
    public void SaveGame()
    {
        OreBase.instance.SaveGameCtrl(true);
        RobotHP.instance.SaveGameCtrl(true);
        RocketBase.instance.SaveGameCtrl(true);
    }
}
