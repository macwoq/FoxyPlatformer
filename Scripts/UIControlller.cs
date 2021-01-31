using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlller : MonoBehaviour
{
    public static UIControlller instance;

    public Image blackScreen;
    public float fadeSpeeed = 2f;
    public bool fadeIN;
    public bool fadeOUT;
    public bool shadowSwitch;

    public Text healthText;
    public Image healthImage;

    public Text iconText;
    public Image iconImage;
    public GameObject qualitySet;
    public GameObject pausePanel;

    public GameObject options;
    




    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        fade();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIN)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeeed * Time.deltaTime));
        }

        if (blackScreen.color.a == 1)
        {
            fadeIN = false;
        }

        if (fadeOUT)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b,
                Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeeed * Time.deltaTime));
        }

        if (blackScreen.color.a == 0)
        {
            fadeOUT = false;
        }
    }

    public void fade()
    {
        fadeOUT = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameManager.instance.PauseUnpause();
        options.SetActive(false);
    }

    public void OpenOptions()
    {
        Time.timeScale = 0;
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        Time.timeScale = 1;
        options.SetActive(false);
    }

    //public void SetShadow()
    //{
    //    if (switchShadow.isOn)
    //    {
    //        GameManager.instance.CurrentLight.shadows = LightShadows.Soft;                        
    //    }else
    //    {
    //        GameManager.instance.CurrentLight.shadows = LightShadows.None;
    //    }
    //
    //}

    public void setQualityOff()
    {
        qualitySet.SetActive(false);
    }


}
