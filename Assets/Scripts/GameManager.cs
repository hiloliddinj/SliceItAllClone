using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _settingsPanel;

    private void Start()
    {
        _settingsPanel.SetActive(false);
    }

    public static int score = 0;
    public static int multiplier = 1;

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }


    
}
