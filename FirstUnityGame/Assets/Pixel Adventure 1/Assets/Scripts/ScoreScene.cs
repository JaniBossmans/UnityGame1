using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScene : MonoBehaviour
{

    public void GoToMain()
    {
        // SceneManager.LoadSceneAsync(0) laadt een nieuwe scene met de index 0, als je dus op de button duwt ga je naar ge IntroScene terug.
        SceneManager.LoadSceneAsync(0);
    }
}