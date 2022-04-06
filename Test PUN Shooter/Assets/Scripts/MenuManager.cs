using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] List<Menu> menus;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;

        SceneManager.sceneLoaded += OnSceneneLoaded;
    }

    private void OnSceneneLoaded(Scene _scene, LoadSceneMode mode)
    {
        menus.Clear();
        if(_scene.buildIndex==0)
        {
            GameObject[] _menus = GameObject.FindGameObjectsWithTag("Menus");
            foreach (GameObject item in _menus)
            {
                menus.Add(item.GetComponent<Menu>());
            }
        }
    }

    public void OpenMenu(string menuName)
    {
        foreach (Menu item in menus)
        {
            if (item.menuName == menuName)
            {
                item.Open();
            }
            else if (item.open)
            {
                CloseMenu(item);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        foreach (Menu item in menus)
        {
            if (item.open)
            {
                item.Close();
            }
        }
        menu.Open();
    }

    public void CloseMenu(string menuName)
    {
        foreach (Menu item in menus)
        {
            if (item.menuName == menuName)
            {
                item.Close();
            }
            else if (item.open)
            {
                CloseMenu(item);
            }
        }
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
