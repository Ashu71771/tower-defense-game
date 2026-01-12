using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    public EnemyData Data => data;
    public static event Action<EnemyData> onEnemyReachedEnd;
    public static event Action<Enemy> OnEnemyDestroyed;

    private Path _currentPath;

    private Vector3 _targetPosition;
    private int _currentWaypoint;
    private float _lives;
    private float _maxLives;

    [SerializeField] private Transform healthBar;
    private Vector3 _healthOriginalScale;
    private bool _hasBeenCounted = false;

    private void Awake()
    {
        _currentPath = GameObject.Find("Path1").GetComponent<Path>();
        _healthOriginalScale = healthBar.localScale;
    }

    private void OnEnable()
    {
        _currentWaypoint = 0;
        _targetPosition = _currentPath.GetPosition(_currentWaypoint);
    }
    void Update()
    {
        if(_hasBeenCounted) return;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition,data.speed * Time.deltaTime);

        float relativeDistance = (transform.position-_targetPosition).magnitude;
        if(relativeDistance<0.1f)
        {
            if(_currentWaypoint <_currentPath.Waypoints.Length -1)
            {
                _currentWaypoint++;
                _targetPosition = _currentPath.GetPosition(_currentWaypoint);
            }
            else
            {
                _hasBeenCounted = true;
                onEnemyReachedEnd?.Invoke(data);
                gameObject.SetActive(false);
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if(_hasBeenCounted) return;

        _lives -=damage;
        _lives = Math.Max(_lives, 0);
        UpdateHealth();

        if(_lives <= 0)
        {
            AudioManager.Instance.PlayEnemyDestroyed();
            _hasBeenCounted = true;
            OnEnemyDestroyed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private void UpdateHealth()
    {
        float healthPercent = _lives / _maxLives;
        Vector3 scale = _healthOriginalScale;
        scale.x = _healthOriginalScale.x * healthPercent;
        healthBar.localScale = scale;      
    }

    public void Initialize(float healthMultiplier)
    {
        _hasBeenCounted = false;
        _maxLives = data.lives * healthMultiplier;
        _lives =_maxLives;
        UpdateHealth();
    }
}
