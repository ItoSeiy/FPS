using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 4個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Clear5 : MonoBehaviour
{
    /// <summary>ゲートのアニメーター</summary>
    Animator m_anim;
    /// <summary>ゲートのオーディオソース</summary>
    private AudioSource m_audioSource;
    /// <summary>1個目のゲートのスクリプト</summary>
    [SerializeField] Clear m_enemyCount;
    /// <summary>4個目のゲートのスクリプト</summary>
    [SerializeField] Clear4 m_enemySum;
    /// <summary>6個目のゲートのスクリプト</summary>
    [SerializeField] Clear6 m_gate6;
    /// <summary>第五区画内の倒すべき敵の総数</summary>
    [SerializeField] private int enemyNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText5;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText6;

    

    /// <summary>
    /// 5個目のゲートを開ける処理
    /// </summary>
    public void Gate5()
    {
        textNum--;

        if (m_enemyCount.Enemy == this.EnemySum /*m_enemyNum + m_enemySum.EnemySum/*倒すべき敵の総数*/)
        {
            m_anim.Play("Open5");
            m_audioSource.Play();
            m_enemyCountText5.gameObject.SetActive(false);
            m_enemyCountText6.gameObject.SetActive(true);
            m_gate6.enabled = (true);
        }
    }
    /// <summary>第一、第二、第三、第四、第五区画の倒すべき敵の総数</summary>
    private int enemyNum5;
    /// <summary>
    /// 第一、第二、第三、第四、第五区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {
        get
        {       
            enemyNum5 = enemyNum + m_enemySum.EnemySum;
            return enemyNum5;
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
        m_enemyCountText5.text = textNum.ToString() + " Enemies";
    }

}