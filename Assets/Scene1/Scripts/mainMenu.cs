﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void play(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Health",100f);
        SceneManager.LoadScene(1);
    }

    public void quit(){
        Application.Quit();
    }
}
