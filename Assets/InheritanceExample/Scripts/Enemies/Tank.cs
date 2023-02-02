using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] protected float _pauseDuration = 1;
    private float _currentMovespeed = 0;
    protected IEnumerator _coroutine;
    protected bool _isHit = false;

    private void Start()
    {
        _currentMovespeed = MoveSpeed;   
    }

    private void Update()
    {
        
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void OnHit()
    { 
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);            
        }

        _coroutine = PauseMovement(_pauseDuration);
        _isHit = true;
        _coroutine = PauseMovement(_pauseDuration);
        StartCoroutine(_coroutine);
                
        
    }    
    

    private IEnumerator PauseMovement(float duration)
    {
        MoveSpeed = 0;
        yield return new WaitForSeconds(duration);
        MoveSpeed = _currentMovespeed;
        _isHit = false;

    }
}
