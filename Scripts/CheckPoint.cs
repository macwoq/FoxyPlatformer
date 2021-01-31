using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject cpOn, cpOff, checjEffect;
    //public AudioClip checkClip;
    //public AudioSource checkAudio;

    // Start is called before the first frame update
    void Start()
    {
        cpOn.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform.position);
            SoundManager.instance.CheckS();
            checjEffect.SetActive(true);
            //checkAudio.PlayOneShot(checkClip);
            cpOff.SetActive(false);
            cpOn.SetActive(true);
        }
    }
}
