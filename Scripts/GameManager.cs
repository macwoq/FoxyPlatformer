using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    PostProcessVolume postVol;
    MotionBlur mBlur;
    DepthOfField dOfF;
    Vignette vign;


    Vector3 respawnPosition;
    Vector3 camspawnPosition;
    public GameObject deathEffect;
    public GameObject enemyDeath;
    public GameObject coinEffect;
    public int currentCoins;
    public Light CurrentLight;


    SoundManager m_soundManager;

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;
        camspawnPosition = CameraController.instance.transform.position;

        currentCoins = 0;

        UIControlller.instance.fadeOUT = true;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseUnpause();
        }
    }

    public void Respawn()
    {
        Debug.Log(" Don`t Fall");

        HealthManager.instance.PlayerDeath();
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        CameraController.instance.cinemaBrain.enabled = false;

        UIControlller.instance.fadeIN = true;

        SoundManager.instance.GameOverS();

        Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

        yield return new WaitForSeconds(2f);

        HealthManager.instance.ResetHealth();

        PlayerController.instance.transform.position = respawnPosition;

        CameraController.instance.cinemaBrain.enabled = true;

        PlayerController.instance.gameObject.SetActive(true);

        UIControlller.instance.fadeOUT = true;
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
        Debug.Log("Spawn set");
    }

    public void AddCoins()
    {
        SoundManager.instance.CoinS();
        currentCoins++;
        UIControlller.instance.iconText.text = currentCoins.ToString();
    }


    public void PauseUnpause()
    {
        if (UIControlller.instance.pausePanel.activeInHierarchy)
        {
            UIControlller.instance.setQualityOff();
            UIControlller.instance.pausePanel.SetActive(false);
            UIControlller.instance.CloseOptions();
            Time.timeScale = 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            UIControlller.instance.CloseOptions();
            UIControlller.instance.pausePanel.SetActive(true);

            Time.timeScale = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void turnOggShadows()
    {
        CurrentLight.shadows = LightShadows.None;
    }

    public void TurnOnShadows()
    {
        CurrentLight.shadows = LightShadows.Soft;
    }

    public void EnemyDeath()
    {
        Instantiate(enemyDeath, EnemyManager.instance.transform.position, EnemyManager.instance.transform.rotation);
    }

    public void PostPro()
    {
        
    }


    public void nextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(currentSceneIndex);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void rCurrentLevel()
    {
        if (Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void rLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void nextLevelDebug()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            print(currentSceneIndex);
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

    }
}

