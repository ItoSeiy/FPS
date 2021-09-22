using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Rayを飛ばし当たり判定を実装する為のスクリプト
/// </summary>
public class HandGunRay : MonoBehaviour
{
    Animator m_anim = default;
    /// <summary>見せかけの銃弾を飛ばす始点</summary>
    [SerializeField] GameObject m_bulletSpwan;
    [SerializeField] GameObject m_muzzleFlash;
    /// <summary> 見せかけの銃弾 </summary>
    [SerializeField] GameObject m_BulletFake;
    [SerializeField] GameObject m_HandGun;
    /// <summary>  Reticleの取得 </summary>
    [SerializeField] Image m_ReticleUI;
    /// <summary> MuzzleFlashを消すため時間</summary>
    private float m_time = 0f;
    /// <summary> 発砲してから何秒後に撃てるか</summary>
    [SerializeField] private float m_fireTime;
    /// <summary> 発砲してから時間を計測する</summary>
    private float m_fireTimeCount = 99f;
    /// <summary>Scriptを参照する </summary>
    HandGunBulletCount BulletCount;
    /// <summary>発砲音を出すリソース</summary>
    private AudioSource Audio;
    public AudioClip Shooting_Sound;//発砲音

    /// <summary>腰うち時Rayをばらけさせる為に取得</summary>
    [SerializeField] AimScript m_aimScript;

    [SerializeField] LayerMask m_mask; //Rayが当たったオブジェクトのレイヤーを取得 今回はEnemy
    [SerializeField] Clear m_gate1;
    //[SerializeField] Target2 m_target2;
    // Start is called before the first frame update
    void Start()
    {
        BulletCount = m_HandGun.GetComponent<HandGunBulletCount>();//銃弾を減らす為にBulletCountスクリプトを取得
        Audio = gameObject.AddComponent<AudioSource>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        m_fireTimeCount += Time.deltaTime;

        if (!Pause.s_isPaused)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(m_ReticleUI.rectTransform.position + m_aimScript.vector);//カメラからRayを飛ばす
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red, 1); //Scene内でRayをみれるようにする
        
        if (Input.GetMouseButtonDown(0) && BulletCount.m_count != 0 && !BulletCount.m_reloadFlag && m_fireTimeCount >= m_fireTime)//左クリックしたら発砲する
        {
            Audio.PlayOneShot(Shooting_Sound); //発砲音
            m_muzzleFlash.SetActive(true);
            GameObject newBullet = Instantiate(m_BulletFake, this.gameObject.transform.position, this.gameObject.transform.rotation); //見せかけの銃弾をつくる
            newBullet.name = m_BulletFake.name;//見せかけの銃弾の名前を変える
            m_fireTimeCount = 0f;


            if (Physics.Raycast(ray, out hit, 100.0f, m_mask)) //当たり判定の処理を行う
            {
                var h = hit.collider.gameObject.GetComponent<target>();
                if (h)
                {
                    h.Hit();
                    m_gate1.Enemy++;
                    Debug.Log(m_gate1.Enemy);
                }
                Destroy(newBullet, 0.1f);//見せかけの銃弾を削除
            }
            BulletCount.m_count--;

        }

        if (m_time > 0.3f) // MuzzleFlashを見えなくする
        {
            m_muzzleFlash.SetActive(false);
            m_time = 0f;
        }

        if (m_time > 0.3f)
        {
            m_time = 0f;
        }
    }

    /// <summary> 発砲してから何秒後に撃てるか</summary>
    public float FireTime
    {
        get { return m_fireTime; }
    }
    public float FireTimeCount
    {
        get { return m_fireTimeCount; }
    }

}
