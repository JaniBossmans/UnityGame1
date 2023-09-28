using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    
    public void PlayGame()
    {
        // SceneManager.LoadSceneAsync(1) laadt een nieuwe scene met de index 1, als je dus op de play button duwt ga je naar ge gamescene.
     
        SceneManager.LoadSceneAsync(1);
    }
}