using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationFader : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;
    [SerializeField] private float _speedOfVolumeEncreation;
    private bool _rogueInHouse;

    private void Start()
    {
        _signalization.Play();
    }

    private IEnumerator IncreaseVolume()
    {
        while (_rogueInHouse)
        {
            _signalization.volume += _speedOfVolumeEncreation;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        while (!_rogueInHouse)
        {
            _signalization.volume -= _speedOfVolumeEncreation;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rogue rogue))
        {
            _rogueInHouse = true;
            StartCoroutine(IncreaseVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rogue rogue))
        {
            _rogueInHouse = false;
            StartCoroutine(ReduceVolume());
        }
    }
}
