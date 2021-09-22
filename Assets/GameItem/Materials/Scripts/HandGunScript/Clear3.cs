using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 3個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Clear3 : MonoBehaviour
{
    /// <summary>ゲートのアニメーター</summary>
    Animator m_anim;
    /// <summary>ゲートのオーディオソース</summary>
    private AudioSource m_audioSource;
    /// <summary>1個目のゲートのスクリプト</summary>
    [SerializeField]Clear m_enemyCount;
    /// <summary>2個目のゲートのスクリプト</summary>
    [SerializeField]Clear2 m_enemySum;
    /// <summary>4個目のゲートのスクリプト</summary>
    [SerializeField] Clear4 m_gate4;
    /// <summary>第三区画内の倒すべき敵の総数</summary>
    [SerializeField] private int enemyNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText3;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText4;

    /// <summary>
    /// 3個目のゲートを開ける処理
    /// </summary>
    public void Gate3()
    {
        textNum--;

        if (m_enemyCount.Enemy == this.EnemySum /*m_enemyNum + m_enemySum.EnemySum/*倒すべき敵の総数*/)
        {
            m_anim.Play("Open3");
            m_audioSource.Play();
            m_enemyCountText3.gameObject.SetActive(false);
            m_enemyCountText4.gameObject.SetActive(true);
            m_gate4.enabled = (true);
        }
    }
    /// <summary>第一、第二、第三区画の倒すべき敵の総数</summary>
    private int enemyNum3;
    /// <summary>
    /// 第一、第二、第三区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {

        get 
        {
            enemyNum3 = enemyNum + m_enemySum.EnemySum;
            return enemyNum3; 
        }
    }
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        textNum = enemyNum;
    }     
    void Update()
    {
        m_enemyCountText3.text = textNum.ToString() + " Enemies";
    }
}
