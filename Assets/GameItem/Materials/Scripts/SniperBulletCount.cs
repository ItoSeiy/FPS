using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 弾数やリロードを管理する為のスクリプト
/// </summary>
public class SniperBulletCount : MonoBehaviour
{
    /// <summary>弾数を表示するTextを取得 </summary>
    [SerializeField] Text m_countText;

    public int m_count = 8; //弾数
    float m_reloadtime = 0f; //リロード時間
    bool m_timeFlag = false; //リロード時間を計測してるかどうか
    public bool m_reloadFlag = false; //リロードをしているかどうか

    private AudioSource Audio;
    public AudioClip sound01; //リロード音

    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_countText.text = "Bullet " + m_count + "/8"; //弾数をテキストとして表示させる
        Reload();
    }

    /// <summary>Rを押されたときと弾数がゼロだったら自動的に実行される</summary>
    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || m_count == 0) //Rを押されたかどうか、弾数がゼロかどうか判断する
        {
            m_timeFlag = true;
            m_reloadFlag = true;

        }

        if (m_timeFlag == true)　//時間の計測を始める
        {
            m_reloadtime += Time.deltaTime;
        }

        if (m_reloadtime > 2f)　//2秒たったら実行 弾数を最大にする
        {
            m_count = 8;
            m_reloadtime = 0; //時間を0にする
            m_timeFlag = false;
            m_reloadFlag = false;
            Audio.PlayOneShot(sound01);
        }
    }
}

