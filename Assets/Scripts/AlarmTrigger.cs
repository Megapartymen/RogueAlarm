using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeDuration;

    //private void Update()
    //{
    //    if (_audioSource.volume <= 0)
    //    {
    //        _audioSource.Stop();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool("InRestrictedArea", true);
            _audioSource.volume = 0f;
            _audioSource.Play();            
            _audioSource.DOFade(1f, _volumeDuration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _animator.SetBool("InRestrictedArea", false);
            _audioSource.DOFade(0f, _volumeDuration);
        }
    }
}
