using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHalth = 3;

    public float invincibleLenght = 2f;
    float invincCounter;
    //public Sprite[] healthImages;
    public GameObject _heart1;
    public GameObject _heart2;
    public GameObject _heart3;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHalth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;

            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if (Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }


                if(invincCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
        }
        UpdateUI();
    }

    public void Hurt()
    {
        if (invincCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                PlayerController.instance.KnockBack();
                invincCounter = invincibleLenght;

                for (int i =0; i < PlayerController.instance.playerPieces.Length; i++)
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHalth;
    }

    public void IncrementHealth()
    {
        
            currentHealth++;
        if (currentHealth > maxHalth)
        {
            currentHealth = maxHalth;
            Debug.Log("mac health");
        }
    }

    public void UpdateUI()
    {
        UIControlller.instance.healthText.text = currentHealth.ToString();

        if (currentHealth == 3)
        {
            _heart1.SetActive(true);
            _heart2.SetActive(true);
            _heart3.SetActive(true);
        }

        if (currentHealth == 2)
        {
            _heart1.SetActive(false);
            _heart2.SetActive(true);
            _heart3.SetActive(true);
        }

        if (currentHealth == 1)
        {
            _heart1.SetActive(false);
            _heart2.SetActive(false);
            _heart3.SetActive(true);
        }

        //switch (currentHealth)
        //{
        //    //case 5:
        //    //    UIControlller.instance.healthImage.sprite = healthImages[4];
        //    //    break;
        //    //case 4:
        //    //    UIControlller.instance.healthImage.sprite = healthImages[3];
        //    //    break;
        //    case 3:
        //        UIControlller.instance.healthImage.sprite = healthImages[2];
        //        break;
        //    case 2:
        //        UIControlller.instance.healthImage.sprite = healthImages[1];
        //        break;
        //    case 1:
        //        UIControlller.instance.healthImage.sprite = healthImages[0];
        //        break;
        //}
    }

    public void PlayerDeath()
    {
        Debug.Log("Bye!");
    }
}
