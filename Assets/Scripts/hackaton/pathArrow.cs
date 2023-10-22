using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pathArrow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] private float _origScale = 0.6f;
    [SerializeField] private float _changeScale = 0.8f;
    [SerializeField] private pointsControle checkpointController;
    private Transform targetCP;

    private void Start()
    {

        _target = checkpointController.transform;


		DOTween.Sequence()
            .Append(transform.DOScale(_changeScale, 1.5f)) //.SetEase(Ease.InOutExpo)
            .Append(transform.DOScale(_origScale, 1.5f)) //.SetEase(Ease.InOutExpo)
            .SetLoops(-1);


    }
    private void Update()
    {
        targetCP = _target.GetChild(checkpointController.currentCheckpointIndex) as Transform;
        transform.LookAt(targetCP);
            //, Vector3.right);
    }

}
