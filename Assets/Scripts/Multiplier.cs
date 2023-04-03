using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _newScoreText;
    [SerializeField] private int _multipler;
    private AudioSource _lastAudio;

    private bool _triggeredAlready = false;

    private void Start()
    {
        _lastAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConst.knife) && !_triggeredAlready) 
        {
            _triggeredAlready = true;
            _lastAudio.Play();
            GameManager.multiplier = _multipler;
            _newScoreText.text = "$" + (GameManager.multiplier * GameManager.score).ToString();
            _winPanel.SetActive(true);
        }
    }
}
