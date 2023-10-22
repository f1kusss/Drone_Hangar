using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorldBorder : MonoBehaviour
{
    [SerializeField] private GameObject _spawnpoint;
    [SerializeField] private GameObject _fade;
    [SerializeField] private float _fadeDuration = 1.5f;
    [SerializeField] private GameObject _player;
    private Image _fadeImg;

    void Start()
    {
        Debug.Log("123");
        _fadeImg = _fade.GetComponent<Image>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("test");
            ChangeState();
            _fadeImg.color += new Color(0f, 0f, 0f, 1f);
            //_fadeImg.DOFade(1, 0.01f);
            TeleportPlayer();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        _fadeImg.DOFade(0, _fadeDuration).SetEase(Ease.InQuint).OnComplete(() => { ChangeState(); });
    }

    private void ChangeState()
    {
        if (_fade.activeSelf == true) _fade.SetActive(false);
        else _fade.SetActive(true);
    }

    private void TeleportPlayer()
    {
        _player.transform.position = _spawnpoint.transform.position;

    }

}
