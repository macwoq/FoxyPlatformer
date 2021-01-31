using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static Levels instance;

    private void Awake()
    {
        instance = this;
    }


    public void Level1()
    {
        SceneManager.LoadScene(2);

    }

    public void Optoins()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
