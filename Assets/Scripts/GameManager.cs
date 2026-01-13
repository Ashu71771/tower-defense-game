using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;private set;}
    public static event Action<int> OnLivesChanged;
    public static event Action<int> OnResourcesChanged;
    [SerializeField] private TMP_FontAsset globalFont;

    private int _lives = 20;
    public int Lives => _lives;
    private int _resources = 175;
    public int Resources => _resources;

    private float _gameSpeed = 1f;
    public float GameSpeed => _gameSpeed;

    private void Awake()
    {
        if(Instance != null && Instance == this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ApplyGlobalFont();
        }
    }

    private void OnEnable()
    {
        Enemy.onEnemyReachedEnd +=HandleEnemyReachedEnd;
        Enemy.OnEnemyDestroyed +=HandleEnemyDestroyed;
        SceneManager.sceneLoaded +=OnSceneLoaded;
    }

    private void OnDisable()
    {
        Enemy.onEnemyReachedEnd -=HandleEnemyReachedEnd;
        Enemy.OnEnemyDestroyed -=HandleEnemyDestroyed;
        SceneManager.sceneLoaded -=OnSceneLoaded;
    }

    private void Start()
    {
        OnLivesChanged?.Invoke(_lives);
        OnResourcesChanged?.Invoke(_resources);
    }


    private void HandleEnemyReachedEnd(EnemyData data)
    {
        _lives = Mathf.Max(0 , _lives -data.damage);
        OnLivesChanged?.Invoke(_lives);
    }

    private void HandleEnemyDestroyed(Enemy enemy)
    {
        AddResources(Mathf.RoundToInt(enemy.Data.resourceReward));
    }

    private void AddResources(int amount)
    {
        _resources += amount;
        OnResourcesChanged?.Invoke(_resources);
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void SetGameSpeed(float newSpeed)
    {
        _gameSpeed = newSpeed;
        SetTimeScale(_gameSpeed);
    }

    public void SpendResources(int amount)
    {
        if(_resources >= amount)
        {
            _resources -=amount;
            OnResourcesChanged?.Invoke(_resources);
        }
    }

    public void ResetGameState()
    {
        _lives = LevelManager.Instance.currentLevel.startingLives;
        OnLivesChanged?.Invoke(_lives);
        _resources = LevelManager.Instance.currentLevel.startingResources;
        OnResourcesChanged?.Invoke(_resources);

        SetGameSpeed(1f);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "MainMenu") 
        {
            AudioManager.Instance.PlayMusic(AudioManager.Instance.mainMenuMusic);
        }
        else if(LevelManager.Instance !=null && LevelManager.Instance.currentLevel !=null)
        {
            ResetGameState();
            AudioManager.Instance.PlayMusic(AudioManager.Instance.gameplayMusic);
        }
    }

    private void ApplyGlobalFont()
    {
        foreach(var tmp in UnityEngine.Object.FindObjectsByType<TextMeshProUGUI>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            tmp.font = globalFont;
        }
        // foreach(var tmp in UnityEngine.Object.FindObjectsByType<TextMeshPro>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        // {
        //     tmp.font = globalFont;
        // }
    }
}
