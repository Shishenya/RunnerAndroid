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
    /// ���������� ��������� � �������
    /// </summary>
    public void NewScoreWrire(int amount)
    {
        // ������� ������ ��������
        Score scoreNow = JsonController.Instance.LoadScore();
        List<int> beforeScoresList = new List<int>();
        if (scoreNow != null)
        {
            beforeScoresList = scoreNow.amountList;
        }

        // ��������� �������
        beforeScoresList.Add(amount);

        // ���������
        beforeScoresList.Sort((x, y) => y.CompareTo(x));

        Score score = new Score();
        List<int> listWrite = new List<int>();
        // ���� ����� ��������� ������������ ����������
        if (beforeScoresList.Count > _maxCountScore)
        {
            listWrite = beforeScoresList.GetRange(0, _maxCountScore);
        }
        else
        {
            listWrite = beforeScoresList;
        }

        // ����������
        score.amountList = listWrite;
        JsonController.Instance.SaveScore(score);

    }
}
