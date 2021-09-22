using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 一個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Gate1 : MonoBehaviour
{
    
    Animator m_anim;   
    private AudioSource m_audioSource;
    /// <summary>倒した敵の総数</summary>
    private int enemyCount;
    /// <summary>第一区画で倒すべき敵の総数</summary>
    [SerializeField]private int enemyNum;
    /// <summary>2個目のゲートのスクリプト</summary>
    [SerializeField]Clear2 m_gate2;
    /// <summary>3個目のゲートのスクリプト</summary>
    [SerializeField]Clear3 m_gate3;
    /// <summary>4個目のゲートのスクリプト</summary>
    [SerializeField] Clear4 m_gate4;
    /// <summary>5個目のゲートのスクリプト</summary>
    [SerializeField] Clear5 m_gate5;
    /// <summary>6個目のゲートのスクリプト</summary>
    [SerializeField] Clear6 m_gate6;
    /// <summary>表示する残りの敵数のテキスト</summary>
    [SerializeField] private TextMeshProUGUI m_enemyCountText;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountTect2;
    /// <summary>
    /// 倒した敵のカウント
    /// 1個目のゲートを開ける処理
    /// その他のゲートを開ける処理の関数の呼び出し
    /// </summary>
    public int Enemy
    {
        set
        { 
            enemyCount = value;
            if (this.Enemy == this.EnemySum /*m_enemyNum*/)
            {
                m_anim.Play("Open");
                m_audioSource.Play();
                m_enemyCountText.gameObject.SetActive(false);
                m_enemyCountTect2.gameObject.SetActive(true);
                m_gate2.enabled = true;
            }
            m_gate2.Gate2();
            m_gate3.Gate3();
            m_gate4.Gate4();
            m_gate5.Gate5();
            m_gate6.Gate6();
            textNum--; 
        }

        get{return enemyCount; }
    }
    void Update()
    {
        m_enemyCountText.text = textNum.ToString() + " Enemies";
        
    }
    /// <summary>
    /// 第一区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {
        get
        {
            return enemyNum; 
        }
    }
    void Start()
    {
        
        this.Enemy = 0;
        m_anim = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        m_enemyCountText.GetComponent<TextMeshProUGUI>();
        textNum = enemyNum;
    }
    
}
