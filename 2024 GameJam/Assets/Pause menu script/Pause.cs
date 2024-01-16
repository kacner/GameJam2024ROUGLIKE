using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeFeild] GameObject Pause;'

    public void Pause()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Pause.SetActive(False);
        Time.timeScale = 1f;
    }

    public void home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.Loadscene(SceneID);
    }
}
