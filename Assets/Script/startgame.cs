﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startgame : MonoBehaviour {

	public void StartButton()
    {
        SceneManager.LoadScene("ThisIsMyFinalForm", LoadSceneMode.Single);
    }
}
