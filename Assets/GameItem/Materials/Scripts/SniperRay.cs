using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スナイパー用
/// Rayを飛ばし当たり判定を実装する為のスクリプト
/// </summary>
public class SniperRay : MonoBehaviour
{
    /// <summary>Reticleの取得</summary>
    [SerializeField] Image m_reticleUI;
    /// <summary>MuzzleFlashを取得</summary>
    //[SerializeField] GameObject m_muzzleFlash;
    /// <summary>AIM時Reticleの取得 </summary>
    /// <summary> MuzzleFlashを消すため時間</summary>
    private float m_time = 0f;
    /// <summary> コッキングしている時間</summary>
    private float m_cockingTime = 0f;
    /// <summary> コッキングしているかどうか</summary>
    private bool m_cockingFlag = false;
    /// <summary>弾数管理スクリプト</summary>
    SniperBulletCount m_sniperBulletCountScript;
    /// <summary>音を出すリソース</summary>
    private AudioSource Audio;
    public AudioClip Shooting_Sound; //発砲音
    public AudioClip m_cocking; //コッキング音
    /// <summary>Aimを管理するスクリプトを取得</summary>
    [SerializeField] SniperAim m_sniperAimScript;
    /// <summary>Rayが当たったオブジェクトのレイヤーを取得 今回はEnemy</summary>
    [SerializeField] LayerMask m_mask;

    // Start is called before the first frame update
    void Start()
    {
        m_sniperBulletCountScript = this.gameObject.GetComponent<SniperBulletCount>();//銃弾を減らす為にBulletCountスクリプトを取得
        Audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        Fire();

        if (Input.GetKeyDown(KeyCode.Escape)) //カーソルを表示させる
        {
            Cursor.visible = true;
        }
    }

    /// <summary>Rayを飛ばして当たり判定を行う関数</summary>
    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_reticleUI.rectTransform.position + m_sniperAimScript.m_vector); //カメラからRayを飛ばす
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.red, 5);
        if (Input.GetMouseButtonDown(0) && m_sniperBulletCountScript.m_count != 0 && !m_sniperBulletCountScript.m_reloadFlag && !m_cockingFlag) //左クリックしたら発砲する
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.red, 5);
            Audio.PlayOneShot(Shooting_Sound); //発砲音
           // m_muzzleFlash.SetActive(true);
            m_cockingFlag = true;

            if (Physics.Raycast(ray, out hit, 1000.0f, m_mask)) //当たり判定の処理を行う
            {
                var h = hit.collider.gameObject.GetComponent<target>();
                if (h)
                {
                    h.Hit();
                    FindObjectOfType<SRTragetDown>().AddTragetDown();
                }
            }
            m_sniperBulletCountScript.m_count--;
        }

        if (m_cockingFlag == true)　//時間の計測を始める
        {
            m_cockingTime += Time.deltaTime;
            m_time += Time.deltaTime;
        }

        if (m_cockingTime > 2.5f) //コッキング完了
        {
            m_cockingFlag = false;
            Audio.PlayOneShot(m_cocking);
            m_cockingTime = 0;
        }

        if (m_time > 1f) //マズルフラッシュを非表示
        {
           // m_muzzleFlash.SetActive(false);
        }
    }
}