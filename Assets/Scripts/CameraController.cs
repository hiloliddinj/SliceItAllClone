using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _offset + _target.position,
            _speed * Time.deltaTime
            );
    }
}
