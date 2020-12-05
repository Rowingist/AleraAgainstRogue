using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TheDoor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Animator _animator;

    public void OnPointerClick(PointerEventData eventData)
    {
        _animator.SetTrigger("Open");
    }
}
