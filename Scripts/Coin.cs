using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin instance;
    public GameObject coinPick;

    private void Awake()
    {
        instance = this;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            
            Debug.Log("Coin");
            GameManager.instance.AddCoins();
            Destroy(gameObject);
            Instantiate(coinPick, transform.position, transform.rotation);
        }
    }
}
