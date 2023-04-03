using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnifeController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Tween _knifeTween;

    private bool _isFirstFlip = true;
    private bool _touching = false;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.platform) && !_touching)
        {
            _touching = true;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
            _rigidBody.isKinematic = true;
            Debug.Log("KnifeController, PLATFORM!");
        }
        else if (other.CompareTag(TagConst.ground) && !_touching)
        {
            _touching = true;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
            _rigidBody.isKinematic = true;
            Debug.Log("KnifeController, you loose!");
        }
    }

    public void FlipKnife()
    {
        if (_touching)
        {
            DOVirtual.DelayedCall(0.2f, (() =>
            {
                _touching = false;
            }));
        }
        _rigidBody.isKinematic = false;
        int rotationAngle = 360;
        if (_isFirstFlip)
        {
            _isFirstFlip = false;
            rotationAngle = 270;
        }
        RotateKnife(rotationAngle);
        JumpKnife();

    }

    private void RotateKnife(int angle)
    {
        _knifeTween.Kill();
        _knifeTween = transform.DORotate(
            new Vector3(angle, 0, 0),
            1.5f,
            RotateMode.LocalAxisAdd)
            .SetEase(Ease.OutExpo);
        
    }

    private void JumpKnife()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(new Vector3(0, 5, 3), ForceMode.Impulse);
    }

}