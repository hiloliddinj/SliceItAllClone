using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutable : MonoBehaviour
{
    [SerializeField] private Rigidbody _leftRb, _rightRb;

    [SerializeField] private float force;

    private BoxCollider _bC;

    private void Start()
    {
        _bC = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.knife))
        {
            _leftRb.isKinematic = false;
            _rightRb.isKinematic = false;

            _leftRb.AddForce(force * Time.deltaTime * new Vector3(-1, 0.1f, 0), ForceMode.Impulse);

            _rightRb.AddForce(force * Time.deltaTime * new Vector3(1, 0.1f, 0), ForceMode.Impulse);
        }
    }
}
