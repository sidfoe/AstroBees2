﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonBehaviors : MonoBehaviour
{
    public string sceneName;

    public void NextScene()
	{
        SceneManager.LoadScene(sceneName);
	}
}
