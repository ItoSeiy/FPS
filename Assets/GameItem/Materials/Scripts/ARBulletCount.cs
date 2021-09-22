using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ARの弾数やリロードを管理する為のスクリプト
/// </summary>
public class ARBulletCount : MonoBehaviour
{
    /// <summary>弾数を表示するTextを取得 </summary>
    [SerializeField] Text m_countText;
    /// <summary> ARの弾数 </summary>
    public int m_count = 30;
    /// <summary>リロード時間</summary>
    float m_reloadtime = 0f;
    /// <summary>リロード時間を計測してるかどうか</summary>
    bool m_timeFlag = false;
    /// <summary>リロードをしているかどうか</summary>
    public bool m_reloadFlag = false; 
    private AudioSource Audio;
    public AudioClip sound01; //リロード音

    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.AddComponent<AudioSource>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_countText.text = "Bullet " + m_count.ToString(); //弾数をテキストとして表示させる
        Reload();
    }

    /// <summary>Rを押されたときと弾数がゼロだったら自動的に実行される</summary>
    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || m_count == 0) //Rを押されたかどうか、弾数がゼロかどうか判断する
        {
            m_timeFlag = true;
            m_reloadFlag = true;
            m_anim.Play("ReLoadAnimation");
        }

        if (m_timeFlag == true)　//時間の計測を始める
        {
            m_reloadtime += Time.deltaTime;
        }

        if (m_reloadtime > 2f)　//2秒たったら実行 弾数を最大にする
        {
            m_count = 30;
            m_reloadtime = 0; //時間を0にする
            m_timeFlag = false;
            m_reloadFlag = false;
            Audio.PlayOneShot(sound01);
        }
    }

    public void SetIsAim()
    {
        m_anim.Play("IsAim");
    }
}

