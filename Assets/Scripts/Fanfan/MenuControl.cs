using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    static MenuControl instance;
    public static MenuControl Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuControl>();
            }
            return instance;
        }
    }


    Animation menuAnimation;
    Image image;
    Button button;

    public bool isShowMenu = false;
    string showMenu = "ShowMenu";
    string closeMenu = "CloseMenu";

    void Start()
    {
        menuAnimation = GetComponent<Animation>();
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        OpenOrCloseMenu();
    }

    void OpenOrCloseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShowMenu = !isShowMenu;
            if (isShowMenu)
            {
                if (menuAnimation.isPlaying)
                {
                    menuAnimation.Stop();
                }
                menuAnimation.Play(showMenu);
                image.enabled = true;
                button.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                if (menuAnimation.isPlaying)
                {
                    menuAnimation.Stop();
                }
                menuAnimation.Play(closeMenu);
                image.enabled = false;
                button.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void CloseMenu()
    {
        isShowMenu = false;
        if (menuAnimation.isPlaying)
        {
            menuAnimation.Stop();
        }
        menuAnimation.Play(closeMenu);
        image.enabled = false;
        button.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
