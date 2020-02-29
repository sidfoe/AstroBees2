using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject howToPlayPanel;
    
    //void OnMouseDown()
    //{
    //    Invoke("NextScene", 0.15f);
    //}

    void NextScene()
	{
        SceneManager.LoadScene("IntroCutscene");
	}

    public void HowToPlayPanelOn()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HowToPlayPanelOff()
    {
        howToPlayPanel.SetActive(false);
    }
}
