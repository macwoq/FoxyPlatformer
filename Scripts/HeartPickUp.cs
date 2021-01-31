using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    public GameObject helyhPickUp;
    public int healAmmount;
    public bool isFullHeal;

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Heart");
            SoundManager.instance.HeartS();
            HealthManager.instance.IncrementHealth();
            Destroy(gameObject);
            Instantiate(helyhPickUp, transform.position, transform.rotation);
        }
    }
}
