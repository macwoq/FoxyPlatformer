using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    public AudioMixer musicMixer;




    public static SoundManager instance;

    public bool m_musicEnabled = true;

    public bool m_fxEnabled = true;

    [Range(0, 1)]
    public float m_musicVolume = 1.0f;

    [Range(0, 1)]
    public float m_fxVolume = 1.0f;

    public Slider musicVolume;
    public Slider soundVolume;

    public AudioSource m_musicSource;
    public AudioSource m_FXSource;



    public AudioClip m_coinSound;

    public AudioClip m_moveSound;

    public AudioClip m_heartSound;

    public AudioClip m_gameOverSound;

    public AudioClip m_hitObstacleSound;

    public AudioClip m_hurtSound;
    public AudioClip m_skeletonSound;

    
    
    public AudioClip m_randomMusicClip;

    public AudioClip m_checkSound;

    public AudioClip[] m_musicClips;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_randomMusicClip = GetRandomClip(m_musicClips);
        PlayBackgroundMusic(m_randomMusicClip);


        musicVolume.value = PlayerPrefs.GetFloat("music");
        
        


    }

    public AudioClip GetRandomClip(AudioClip[] clips)
    {
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        return randomClip;
    }


    void UpdateMusic()
    {
        if (m_musicSource.isPlaying != m_musicEnabled)
        {
            if (m_musicEnabled)
            {

                m_randomMusicClip = GetRandomClip(m_musicClips);
                PlayBackgroundMusic(m_randomMusicClip); 
            }
            else
            {
                m_musicSource.Stop();
            }
        }
    }

    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        // return if music is disabled or if musicSource is null or is musicClip is null
        if (!m_musicEnabled || !musicClip || !m_musicSource)
        {
            return;
        }

        // if music is playing, stop it
        m_musicSource.Stop();

        m_musicSource.clip = musicClip;

        // set the music volume
        m_musicSource.volume = m_musicVolume;

        // music repeats forever
        m_musicSource.loop = true;

        // start playing
        m_musicSource.Play();
    }


    public void ToggleMusic()
    {
        m_musicEnabled = !m_musicEnabled;
        UpdateMusic();
        


    }

    public void ToggleFX()
    {
        m_fxEnabled = !m_fxEnabled;

        //ES3.Save<bool>("fx", m_fxEnabled);

    }

    public void CoinS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_coinSound);
        }
    }

    public void GameOverS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_gameOverSound);
        }
    }

    public void CheckS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_checkSound);
        }
    }

    public void HeartS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_heartSound);
        }
    }

    public void HurtS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_hurtSound);
        }
    }

    public void skalatonS()
    {
        if (m_fxEnabled)
        {
            m_musicSource.PlayOneShot(m_skeletonSound);
        }
    }

    public void setMusicVolume(float music)
    {
        Debug.Log("mm");
        musicMixer.SetFloat("music", music);

        PlayerPrefs.SetFloat("music", music);
    }

    public void setFxVolume(float fx)
    {
        Debug.Log("vol");
        musicMixer.SetFloat("fx", fx);
       
    }
}
