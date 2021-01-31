using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject qualityMenu;
    public GameObject mainSettings;



    // Start is called before the first frame update
    void Start()
    {
        mainSettings.SetActive(true);
        qualityMenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterQuality()
    {
        mainSettings.SetActive(false);
        qualityMenu.SetActive(true);
        
    }
}
