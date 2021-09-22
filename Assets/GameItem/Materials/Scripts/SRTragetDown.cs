using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SRステージのターゲット数を
/// 管理するスクリプト
/// </summary>
public class SRTragetDown : MonoBehaviour
{
    /// <summary>ターゲット数を表示するテキスト</summary>
    Text m_tragerText;
    /// <summary>ターゲット数を表示するテキスト</summary>
    private int m_tragetDown = 0;
    /// <summary>設置したターゲットの総数</summary>
    [SerializeField] int m_tragetTotal = 0;
    /// <summary>ゴールに行くための道（はしご）</summary>
    [SerializeField] GameObject m_ladder;

    void Start()
    {
        m_tragerText = GetComponent<Text>();
        m_ladder.SetActive(false);//ゴールへの道を消す
    }

    void Update()
    {
        //テキストを表示するテキスト
        m_tragerText.text = "Traget " + m_tragetDown + "/" + m_tragetTotal;
        //全てのターゲットを倒したらゴールに行く為の道を表示する
        if (m_tragetDown == m_tragetTotal)
        {
            m_ladder.SetActive(true);
        }

    }

    /// <summary>ターゲットを倒した時に呼ばれる倒したターゲット数を増やす</summary>
    public void AddTragetDown()
    {
        m_tragetDown++;
    }
}
