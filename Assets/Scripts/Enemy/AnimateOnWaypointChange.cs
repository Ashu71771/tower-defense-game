using UnityEngine;

public class AnimateOnWaypointChange : MonoBehaviour
{
    private Animator _animator;
    private Enemy _enemy;
    private Vector3 _lastTarget;
    private bool _initialized;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();

        if (_animator == null || _enemy == null)
        {
            enabled = false;
        }
    }

    void Update()
    {
        if (!_initialized)
        {
            _lastTarget = _enemy.CurrentTargetPosition;
            _initialized = true;
            return;
        }

        Vector3 currentTarget = _enemy.CurrentTargetPosition;
        if (currentTarget != _lastTarget)
        {
            UpdateAnimation(currentTarget);
            _lastTarget = currentTarget;
        }
    }

    private void UpdateAnimation(Vector3 target)
    {
        Vector2 dir = (target - transform.position).normalized;

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            _animator.SetFloat("MoveX", dir.x > 0 ? 1 : -1);
            _animator.SetFloat("MoveY", 0);
        }
        else
        {
            _animator.SetFloat("MoveX", 0);
            _animator.SetFloat("MoveY", dir.y > 0 ? 1 : -1);
        }
    }
}
