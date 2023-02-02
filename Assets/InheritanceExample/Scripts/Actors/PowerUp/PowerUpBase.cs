using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] protected float PowerUpDuration = 2;
    [SerializeField] private GameObject _visualToDisable = null;
    [SerializeField] private AudioClip _collectSFX = null;

    protected abstract void PowerUp(float duration);
    protected abstract void PowerDown();   

    private IEnumerator _coroutine;
       
    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();

        if(projectile != null)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            _visualToDisable.SetActive(false);
            AudioHelper.PlayClip2D(_collectSFX, 1, 01f);

            OnHit();
        }
    }

    private void OnHit()
    {
        _coroutine = StartPowerUp(PowerUpDuration);
        StartCoroutine(_coroutine);        
    }

    private IEnumerator StartPowerUp(float duration)
    {
        PowerUp(PowerUpDuration);
        yield return new WaitForSeconds(duration);
        PowerDown();
        Destroy(gameObject);
    }
}
