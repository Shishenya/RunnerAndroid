using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuButtons;
    [SerializeField] private GameObject _recordPanel;

    private int _newGameIndex = 1;

    private void Start()
    {
        ShowMainMenu();
    }

    /// <summary>
    /// Начало новой игры
    /// </summary>
    public void NewGameStart()
    {
        SceneManager.LoadScene(_newGameIndex);
    }

    /// <summary>
    /// Показывает панель с рекордами
    /// </summary>
    public void ShowRecordPanel()
    {
        ResetPanels();
        _recordPanel.SetActive(true);
    }

    /// <summary>
    /// Показывает основное меню
    /// </summary>
    public void ShowMainMenu()
    {
        ResetPanels();
        _mainMenuButtons.SetActive(true);
    }

    /// <summary>
    /// Выход
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Отключает все панели
    /// </summary>
    private void ResetPanels()
    {
        _mainMenuButtons.SetActive(false);
        _recordPanel.SetActive(false);
    }
}
