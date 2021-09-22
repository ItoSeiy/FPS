using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 弾数やリロードを管理する為のスクリプト
/// </summary>
public class HandGunBulletCount : MonoBehaviour
{
    /// <summary>弾数を表示するTextを取得 </summary>
    [SerializeField] Text m_countText;
    Animator m_anim;
    [SerializeField] float m_reloadTime; //リロード時間
    public int m_count = 16; //弾数
    float m_timer = 0f; //リロード時間の計測
    bool m_timeFlag = false; //リロード時間を計測してるかどうか
    public bool m_reloadFlag = false; //リロードをしているかどうか
    private AudioSource Audio;
    public AudioClip sound01; //リロード

    [SerializeField] HandGunRay m_fireCount;
    [SerializeField] HandGunGameManager m_gameManager;

    void Start()
    {
        Audio = gameObject.AddComponent<AudioSource>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.s_isPaused) return;

        m_countText.text = m_count.ToString() + "/" + "16"; //弾数をテキストとして表示させる
        if (m_gameManager.m_startFlag)
        {
            Reload();
        }
    }

    /// <summary>Rを押されたときと弾数がゼロだったら自動的に実行される</summary>
    void Reload()
    {
        if (Input.GetMouseButtonDown(0) && m_count != 0 && !m_reloadFlag && m_fireCount.FireTimeCount >= m_fireCount.FireTime)
        {
            m_anim.Play("Recoil");
        }
        if (Input.GetKeyDown(KeyCode.R) && m_count <= 15 || m_count == 0) //Rを押されたかどうか、弾数がゼロかどうか判断する
        {
            Debug.Log("リロード");
            m_anim.Play("Reload");
            m_timeFlag = true;
            m_reloadFlag = true;
        }

        if (m_timeFlag == true)　//時間の計測を始める
        {
            m_timer += Time.deltaTime;
        }

        if (m_timer > m_reloadTime)　//2秒たったら実行 弾数を最大にする
        {
            m_count = 16;
            m_timer = 0; //時間を0にする
            m_timeFlag = false;
            m_reloadFlag = false;
            Audio.PlayOneShot(sound01);
        }
    }
}