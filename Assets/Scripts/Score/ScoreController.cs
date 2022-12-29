using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    private int _maxCountScore = 5;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Записывает результат в рекорды
    /// </summary>
    public void NewScoreWrire(int amount)
    {
        // Достаем старые значения
        Score scoreNow = JsonController.Instance.LoadScore();
        List<int> beforeScoresList = new List<int>();
        if (scoreNow != null)
        {
            beforeScoresList = scoreNow.amountList;
        }

        // Добавляем элемент
        beforeScoresList.Add(amount);

        // Соритруем
        beforeScoresList.Sort((x, y) => y.CompareTo(x));

        Score score = new Score();
        List<int> listWrite = new List<int>();
        // если длина превышает максимальное количество
        if (beforeScoresList.Count > _maxCountScore)
        {
            listWrite = beforeScoresList.GetRange(0, _maxCountScore);
        }
        else
        {
            listWrite = beforeScoresList;
        }

        // Записываем
        score.amountList = listWrite;
        JsonController.Instance.SaveScore(score);

    }
}
