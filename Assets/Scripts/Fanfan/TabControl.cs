using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControl : MonoBehaviour
{
    static TabControl instance;
    public static TabControl Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TabControl>();
            }
            return instance;
        }
    }

    GameObject electric;
    Animation tabAnimation;
    Image image;
    MenuControl menuControl;

    bool isShowMenu;
    bool isShowTab = false;
    string showTab = "ShowTab";
    string closeTab = "CloseTab";

    // Start is called before the first frame update
    void Start()
    {
        electric = GameObject.FindWithTag("Electric");
        tabAnimation = GetComponent<Animation>();
        image = GetComponent<Image>();
        menuControl = MenuControl.Instance;

        image.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        OpenOrCloseTab();
    }

    void OpenOrCloseTab()
    {
        isShowMenu = menuControl.isShowMenu;

        if (!isShowMenu)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isShowTab = !isShowTab;
                if (isShowTab)
                {
                    electric.SetActive(false);
                    if (tabAnimation.isPlaying)
                    {
                        tabAnimation.Stop();
                    }
                    tabAnimation.Play(showTab);
                }
                else
                {
                    electric.SetActive(true);
                    if (tabAnimation.isPlaying)
                    {
                        tabAnimation.Stop();
                    }
                    tabAnimation.Play(closeTab);
                }
            }
        }
    }
}
