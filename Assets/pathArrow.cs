using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pathArrow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] private float _origScale = 0.6f;
    [SerializeField] private float _changeScale = 0.8f;

    private void Start()
    {
        
        DOTween.Sequence()
            .Append(transform.DOScale(_changeScale, 1.5f)) //.SetEase(Ease.InOutExpo)
            .Append(transform.DOScale(_origScale, 1.5f)) //.SetEase(Ease.InOutExpo)
            .SetLoops(-1);


    }
    private void Update()
    {
        transform.LookAt(_target);
            //, Vector3.right);
    }

}
