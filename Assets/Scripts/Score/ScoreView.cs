using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _scoreText.text = "";
        Score score = JsonController.Instance.LoadScore();
        if (score != null)
        {
            List<int> scoreList = new List<int>();
            scoreList = score.amountList;
            if (scoreList.Count > 0)
            {
                int i = 1;
                _scoreText.gameObject.SetActive(false);
                foreach (int scoreAmount in scoreList)
                {
                    GameObject scoreText =  Instantiate(_scoreText.gameObject, _scoreText.transform.parent);
                    scoreText.GetComponent<TMP_Text>().text = i.ToString() + " место: " + scoreAmount.ToString();
                    scoreText.SetActive(true);
                    i++;
                }
            }
        }
        else
        {
            _scoreText.text = "нет рекордов!";
        }
    }
}
