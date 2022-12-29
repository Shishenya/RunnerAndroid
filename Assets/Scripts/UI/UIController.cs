using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject _gamePausedPanel;

    private int _mainMenuSceneIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _gamePausedPanel.SetActive(false);
        scoreText.text = "";
    }

    /// <summary>
    /// ���������� ������ ���������� �����
    /// </summary>
    public void UpdateCoinText(int amount)
    {
        _coinsText.text = "������� �����: " + amount.ToString();
    }

    /// <summary>
    /// ����� ���������� ������ ��������� ����
    /// </summary>
    public void ShowGameOverPanel(int score)
    {
        _gameOverPanel.SetActive(true);
        ShowScore(score);
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// �����
    /// </summary>
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    /// <summary>
    /// ���������� ���������� �����
    /// </summary>
    /// <param name="score"></param>
    public void ShowScore(int score)
    {
        scoreText.text = "��� ����: \n" + score.ToString() + " �����";
    }

    /// <summary>
    /// ���������� ���� �����
    /// </summary>
    public void ShowGamePausedMenu()
    {
        Time.timeScale = 0;
        _gamePausedPanel.SetActive(true);
    }

    /// <summary>
    /// ������ �������� � ����
    /// </summary>
    public void ReturnGame()
    {
        Time.timeScale = 1;
        _gamePausedPanel.SetActive(false);
    }

    /// <summary>
    /// ����� � ���� ����
    /// </summary>
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }
}
