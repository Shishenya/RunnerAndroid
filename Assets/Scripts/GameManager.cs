using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action pickUpCoinEvent;
    public event Action gameOverEvent;

    [SerializeField] private Transform _player;
    private int _coinsAmount = 0;

    private void OnEnable()
    {
        pickUpCoinEvent += IcrementCoin;
        gameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        pickUpCoinEvent -= IcrementCoin;
        gameOverEvent -= GameOver;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIController.Instance.UpdateCoinText(_coinsAmount);
    }

    public void CallPickUpCoin()
    {
        pickUpCoinEvent?.Invoke();
    }

    public void CallGameOverEvent()
    {
        gameOverEvent?.Invoke();
    }

    /// <summary>
    /// Увеличение количества монет
    /// </summary>
    public void IcrementCoin()
    {
        _coinsAmount++;
        UIController.Instance.UpdateCoinText(_coinsAmount);
    }

    /// <summary>
    /// Конец игры
    /// </summary>
    private void GameOver()
    {        
        Time.timeScale = 0;
        int scoreAmount = _coinsAmount * (int)_player.position.z / 10;
        UIController.Instance.ShowGameOverPanel(scoreAmount);

        ScoreController.Instance.NewScoreWrire(scoreAmount);
    }
}
