using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AR用
/// Rayを飛ばし当たり判定を実装する為のスクリプト
/// </summary>
public class ARRay : MonoBehaviour
{
    [SerializeField] GameObject m_muzzleFlash;
    /// <summary>  Reticleの取得 </summary>
    [SerializeField] Image m_ReticleUI;
    /// <summary> MuzzleFlashと発泡間隔用の時間</summary>
    private float m_time = 0f;
    /// <summary>弾数管理Scriptを取得 </summary>
    ARBulletCount m_arbulletCountScript;
    /// <summary>発砲音を出すリソース</summary>
    private AudioSource Audio;
    public AudioClip Shooting_Sound; //発砲音
    /// <summary>Rayが当たったオブジェクトのレイヤーを取得 今回はEnemy</summary>
    [SerializeField] LayerMask m_enemyMask;

    [SerializeField] LayerMask m_civilianMask;
    /// <summary>Aimを管理するスクリプトを取得</summary>
    [SerializeField] ARAimScript m_arAimScript;

    // Start is called before the first frame update
    void Start()
    {
        m_arbulletCountScript = this.gameObject.GetComponent<ARBulletCount>();
        Audio = gameObject.AddComponent<AudioSource>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
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
        Ray ray = Camera.main.ScreenPointToRay(m_ReticleUI.rectTransform.position + m_arAimScript.vector); //カメラからRayを飛ばす
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 150.0f, Color.red, 5);
        if (Input.GetMouseButton(0)&& m_arbulletCountScript.m_count != 0 && !m_arbulletCountScript.m_reloadFlag) //左クリックしたら発砲する
        {
            //発砲間隔をあける
            if (m_time > 0.1f)
            {
                Audio.PlayOneShot(Shooting_Sound); //発砲音
                m_arbulletCountScript.m_count--;　//弾数を減らす
                m_time = 0f;
            }

            m_muzzleFlash.SetActive(true);
            if (Physics.Raycast(ray, out hit, 150.0f, m_enemyMask)) //当たり判定の処理を行う
            {
                var h = hit.collider.gameObject.GetComponent<target>(); //targetの情報をhに代入
                h.Hit(); //targetが持っているHit関数を呼び出す
                h.GetComponent<BoxCollider>().enabled = false;
                FindObjectOfType<ScoreScript>().AddScore(200);
                FindObjectOfType<TragetDown>().AddTragetDown();
            }
            else if (Physics.Raycast(ray, out hit, 150.0f, m_civilianMask))
            {
                var h = hit.collider.gameObject.GetComponent<target>(); //targetの情報をhに代入
                h.Hit(); //targetが持っているHit関数を呼び出す
                h.GetComponent<BoxCollider>().enabled = false;
                FindObjectOfType<ScoreScript>().PullScore(500);
                FindObjectOfType<TragetDown>().AddNoTragetDown();
            }
        }
     
        if (m_time > 0.1f) // MuzzleFlashを見えなくする
        {
            m_muzzleFlash.SetActive(false);
            m_time = 0f;
        }
    }
}
