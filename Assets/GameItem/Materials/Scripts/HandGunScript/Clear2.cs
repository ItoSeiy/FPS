using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 二個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Clear2 : MonoBehaviour
{
    /// <summary>ゲートのアニメーター</summary>
    Animator m_anim;
    /// <summary>ゲートのオーディオソース</summary>
    private AudioSource m_audioSource;
    /// <summary>1個目のゲートのスクリプト</summary>
    [SerializeField]Clear m_enemyCount;
    /// <summary>3個目のゲートのスクリプト</summary>
    [SerializeField] Clear3 m_gate3;
    /// <summary>第二区画内の倒すべき敵の総数</summary>
    [SerializeField] private int enemyNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText2;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText3;
    /// <summary>
    /// 2個目のゲートを開けるための処理
    /// </summary>
    public void Gate2()
    {
        textNum--;

        if (m_enemyCount.Enemy ==  this.EnemySum /*m_enemyNum + m_enemyCount.EnemySum /*倒すべき敵の総数*/)
        {
            m_anim.Play("Open2");
            m_audioSource.Play();
            m_enemyCountText2.gameObject.SetActive(false);
            m_enemyCountText3.gameObject.SetActive(true);
            m_gate3.enabled = (true);
        }
    }
    void Update()
    {
        m_enemyCountText2.text = textNum.ToString() + " Enemise";
    }
    /// <summary>第一、第二区画の倒すべき敵の総数</summary>
    private int enemyNum2;
    /// <summary>
    /// 第一、第二区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {
        get 
        {
            enemyNum2 = enemyNum + m_enemyCount.EnemySum;
            return enemyNum2;
        }
    }
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        textNum = enemyNum;
    }
    
    
}
