using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ARステージ用のターゲットを
///管理するスクリプト
/// </summary>
public class TragetDown : MonoBehaviour
{
    /// <summary>敵ターゲットをを表示するテキスト</summary>
    [SerializeField] Text m_tragetText;
    /// <summary>民間人ターゲットをを表示するテキスト</summary>
    [SerializeField] Text m_noTragetText;
    /// <summary>倒した敵の数</summary>
    private int m_tragetDown = 0;
    /// <summary>敵の総数</summary>
    private int m_tragetTotal = 30;
    /// <summary>民間人の総数</summary>
    private int m_noTragetTotal = 15;
    /// <summary>倒した民間人の数</summary>
    private int m_noTragetDown = 0;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_tragetText.text = "Target: " + m_tragetDown + "/" + m_tragetTotal;　//敵のターゲットをテキストに表示する
        m_noTragetText.text = "Citizen: " + m_noTragetDown + "/" + m_noTragetTotal;　//民間人のターゲットをテキストに表示する
    }

    /// <summary>倒した敵ターゲットの数を増やす</summary>
    public void AddTragetDown()
    {
        m_tragetDown++;
    }

    /// <summary>倒した民間人ターゲットの数を増やす</summary>
    public void AddNoTragetDown()
    {
        m_noTragetDown++;
    }
}
