﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * Scene controls component to navigate in the game (resume, restart, go to home, quit).
 */
public class SceneControls : MonoBehaviour
{
    // Scene name that will be used as home scene.
    public string homeScene = "SimulationRoom";
    // all audio sources in scene, so they are paused when Canvas is displayed.
    public AudioSource[] audioSources;

    // restarts the current scene.
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (VoiceImageCanvasSync.SceneTransitionParam.Equals("class2"))
        {
            SceneManager.LoadScene("Street");
        }
        //VoiceImageCanvasSync.SceneTransitionParam = "";
        Time.timeScale = 1;
    }

    // navigate to home.
    public void goToHome()
    {
        VoiceImageCanvasSync.SceneTransitionParam = "";
        foreach (AudioSource audio in audioSources)
            audio.UnPause();
        if (homeScene != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene("LoadingScene");
            TransitionManager.pendingLoadingSceneName = homeScene;
        }
        Time.timeScale = 1;
    }

    // hides canvas and resumes audios.
    public void resume()
    {
        Time.timeScale = 1;
        foreach (AudioSource audio in audioSources)
            audio.UnPause();
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    // closes the app.
    public void quit()
    {
        Application.Quit();
    }

}
