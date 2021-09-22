using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 4個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Clear4 : MonoBehaviour
{
    /// <summary>ゲートのアニメーター</summary>
    Animator m_anim;
    /// <summary>ゲートのオーディオソース</summary>
    private AudioSource m_audioSource;
    /// <summary>1個目のゲートのスクリプト</summary>
    [SerializeField] Clear m_enemyCount;
    /// <summary>3個目のゲートのスクリプト</summary>
    [SerializeField] Clear3 m_enemySum;
    ///<summary>5個目のゲートのスクリプト</summary>
    [SerializeField] Clear5 m_gate5;
    /// <summary>第四区画内の倒すべき敵の総数</summary>
    [SerializeField] private int enemyNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText4;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText5;
    

    /// <summary>
    /// 4個目のゲートを開ける処理
    /// </summary>
    public void Gate4()
    {
        textNum--;

        if (m_enemyCount.Enemy == this.EnemySum /*m_enemyNum + m_enemySum.EnemySum/*倒すべき敵の総数*/)
        {
            m_anim.Play("Open4");
            m_audioSource.Play();
            m_enemyCountText4.gameObject.SetActive(false);
            m_enemyCountText5.gameObject.SetActive(true);
            m_gate5.enabled = (true);
        }
    }
    /// <summary>第一、第二、第三、第四区画の倒すべき敵の総数</summary>
    private int enemyNum4;
    /// <summary>
    /// 第一、第二、第三、第四区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {
        get 
        {
            enemyNum4 = enemyNum + m_enemySum.EnemySum;
            return enemyNum4; 
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
        m_enemyCountText4.text = textNum.ToString() + " Enemise";
    }
    
}
