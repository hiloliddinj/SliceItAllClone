using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Cutable : MonoBehaviour
{
    [SerializeField] private Rigidbody _leftRb, _rightRb;
    [SerializeField] private float force;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _text;

    private BoxCollider _bC;

    private void Start()
    {
        _bC = GetComponent<BoxCollider>();
        _text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.knife))
        {
            if (_particleSystem != null)
            {
                _particleSystem.Play();
            }

            if (_text != null)
            {
                _text.SetActive(true);
                _text.transform.DOMoveY(_text.transform.position.y + 1, 0.2f);
                DOVirtual.DelayedCall(0.5f, (() =>
                {
                    _text.SetActive(false);
                }));
            }
            
            _leftRb.isKinematic = false;
            _rightRb.isKinematic = false;

            _leftRb.AddForce(force * Time.deltaTime * new Vector3(-1, 0.1f, 0), ForceMode.Impulse);

            _rightRb.AddForce(force * Time.deltaTime * new Vector3(1, 0.1f, 0), ForceMode.Impulse);
        }
    }
}
