using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 4個目のゲートの処理
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Clear6 : MonoBehaviour
{
    /// <summary>ゲートのアニメーター</summary>
    Animator m_anim;
    /// <summary>ゲートのオーディオソース</summary>
    private AudioSource m_audioSource;
    /// <summary>1個目のゲートのスクリプト</summary>
    [SerializeField] Clear m_enemyCount;
    /// <summary>5個目のゲートのスクリプト</summary>
    [SerializeField] Clear5 m_enemySum;
    /// <summary>第六区画内の倒すべき敵の総数</summary>
    [SerializeField] private int enemyNum;
    [SerializeField] private TextMeshProUGUI m_enemyCountText6;
    private int textNum;
    [SerializeField] private TextMeshProUGUI m_goToTheGoalText;
    /// <summary>クリアエフェクト</summary>
    [SerializeField] GameObject m_clearEffect;
    


    /// <summary>
    /// 6個目のゲートを開ける処理
    /// </summary>
    public void Gate6()
    {
        textNum--;

        if (m_enemyCount.Enemy == this.EnemySum /*m_enemyNum + m_enemySum.EnemySum/*倒すべき敵の総数*/)
        {
            m_anim.Play("Open6");
            m_audioSource.Play();
            m_enemyCountText6.gameObject.SetActive(false);
            m_goToTheGoalText.gameObject.SetActive(true);
            m_clearEffect.SetActive(true);
            Invoke("DelayMethod", 3.5f);
        }
    }
    void DelayMethod()
    {
        Destroy(this.gameObject);
    }
    /// <summary>第一、第二、第三、第四、第五、第六区画の倒すべき敵の総数</summary>
    private int enemyNum6;
    /// <summary>
    /// 第一、第二、第三、第四、第五、第六区画の倒すべき敵の総数
    /// </summary>
    public int EnemySum
    {
        get
        {
            enemyNum6 = enemyNum + m_enemySum.EnemySum;
            return enemyNum6;
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
        m_enemyCountText6.text = textNum.ToString() + " Enemies";
    }

}