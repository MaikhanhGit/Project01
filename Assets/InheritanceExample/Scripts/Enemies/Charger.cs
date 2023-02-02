using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] protected GameObject _lootItem = null;

    protected override void OnHit()
    {
        // increase speed when hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        if (_lootItem)
        {
            Instantiate(_lootItem, gameObject.transform.position, Quaternion.identity);
        }        
        base.Kill();
    }
}
