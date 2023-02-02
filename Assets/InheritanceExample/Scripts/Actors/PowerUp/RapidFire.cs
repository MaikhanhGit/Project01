using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    [SerializeField] private float _rotationSpeed = .5f;    

    private float _coolDownDuration = 0;
    
    TurretController _turretController;

    private void Awake()
    {
         _turretController = FindObjectOfType<TurretController>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.right * _rotationSpeed, Space.Self);
    }

    protected override void PowerDown()
    {
        if(_turretController != null)
        {
            _turretController.FireCooldown *= 2;            
        }
    }

    protected override void PowerUp(float duration)
    {
        if(_turretController != null)
        {
            _turretController.FireCooldown /= 2;                     
        }
    }
}
