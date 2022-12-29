using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController : MonoBehaviour
{
    public static JsonController Instance;
    public Score score;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Записывает результат
    /// </summary>
    public void SaveScore(Score score)
    {
        File.WriteAllText(Application.streamingAssetsPath + "/score.json", JsonUtility.ToJson(score));
    }

    /// <summary>
    /// Загружает данные из файла с результатами
    /// </summary>
    public Score LoadScore()
    {
        score = JsonUtility.FromJson<Score>(File.ReadAllText(Application.streamingAssetsPath + "/score.json"));
        return score;
    }
}
