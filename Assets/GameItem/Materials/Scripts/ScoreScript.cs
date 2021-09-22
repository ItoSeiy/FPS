using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ARステージで使うスコア処理を
/// するスクリプト
/// </summary>
public class ScoreScript : MonoBehaviour
{
    /// <summary>スコアを表示するテキストを取得</summary>
    Text m_scoreText;
    int m_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text = "SCORE:" + m_score;
    }

    /// <summary>敵を倒した時にスコアを増やす関数</summary>
    /// <param name="Add"></param>
    public void AddScore(int Add)
    {
        m_score += Add;
    }

    /// <summary>民間人を倒した時にスコアを引く関数</summary>
    /// <param name="Pull"></param>
    public void PullScore(int Pull)
    {
        m_score -= Pull;
    }
}
