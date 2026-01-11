using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    public AudioClip buttonClickClip;
    public AudioClip buttonHoverClip;
    public AudioClip towerPlacedClip;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
}
