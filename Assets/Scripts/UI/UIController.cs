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
    /// Обновление текста количества монет
    /// </summary>
    public void UpdateCoinText(int amount)
    {
        _coinsText.text = "Собрано монет: " + amount.ToString();
    }

    /// <summary>
    /// Метод показывает панель окончания игры
    /// </summary>
    public void ShowGameOverPanel(int score)
    {
        _gameOverPanel.SetActive(true);
        ShowScore(score);
    }

    /// <summary>
    /// Рестарт игры
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Выход
    /// </summary>
    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    /// <summary>
    /// Показывает количество очков
    /// </summary>
    /// <param name="score"></param>
    public void ShowScore(int score)
    {
        scoreText.text = "Ваш счет: \n" + score.ToString() + " очков";
    }

    /// <summary>
    /// показывает меню паузы
    /// </summary>
    public void ShowGamePausedMenu()
    {
        Time.timeScale = 0;
        _gamePausedPanel.SetActive(true);
    }

    /// <summary>
    /// Кнопка возврата в игру
    /// </summary>
    public void ReturnGame()
    {
        Time.timeScale = 1;
        _gamePausedPanel.SetActive(false);
    }

    /// <summary>
    /// Выход в меню игры
    /// </summary>
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }
}
