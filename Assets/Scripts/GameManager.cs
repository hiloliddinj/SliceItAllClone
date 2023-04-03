using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _settingsPanel, _winPanel;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _newScoreText;

    public static int score = 0;
    public static int multiplier = 1;


    private void Start()
    {
        _settingsPanel.SetActive(false);
        _winPanel.SetActive(false);
        _scoreText.text = "$123";
    }

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }


    
}
