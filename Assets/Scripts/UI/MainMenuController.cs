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
    /// ������ ����� ����
    /// </summary>
    public void NewGameStart()
    {
        SceneManager.LoadScene(_newGameIndex);
    }

    /// <summary>
    /// ���������� ������ � ���������
    /// </summary>
    public void ShowRecordPanel()
    {
        ResetPanels();
        _recordPanel.SetActive(true);
    }

    /// <summary>
    /// ���������� �������� ����
    /// </summary>
    public void ShowMainMenu()
    {
        ResetPanels();
        _mainMenuButtons.SetActive(true);
    }

    /// <summary>
    /// �����
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// ��������� ��� ������
    /// </summary>
    private void ResetPanels()
    {
        _mainMenuButtons.SetActive(false);
        _recordPanel.SetActive(false);
    }
}
