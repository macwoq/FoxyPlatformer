using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public GameObject enemy;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hit!");
            SoundManager.instance.skalatonS();
            GameManager.instance.EnemyDeath();
            PlayerController.instance.Bounce();
            Destroy(enemy);
        }
    }
}
