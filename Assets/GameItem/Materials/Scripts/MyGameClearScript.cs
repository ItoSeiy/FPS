using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


/// <summary>
/// ARとSRステージで使っているクリア判定をする
/// スクリプト
/// </summary>
public class MyGameClearScript : MonoBehaviour
{
    /// <summary> クリアテキストを取得</summary>
    [SerializeField] Text m_gameClearText;
    /// <summary> リプレイボタンを取得</summary>
    [SerializeField] Button m_reStartButton;
    /// <summary> タイトルに戻るボタンを取得</summary>
    [SerializeField] Button m_titleBackButton;
    /// <summary> AR　発砲処理スクリプトを取得</summary>
    [SerializeField] ARRay m_arRayScript;
    /// <summary> SR　発砲処理スクリプトを取得</summary>
    [SerializeField] SniperRay m_snierRayScript;
    /// <summary>カメラを取得</summary>
    [SerializeField] CinemachineBrain m_camera;
    /// <summary>ARモードとSRモードを切り替える</summary>
    [SerializeField] int m_mode = 0;

    private bool m_clearFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        m_gameClearText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_clearFlag) //カーソルを表示
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            m_gameClearText.enabled = true;
            //playerが持っているRigidbodyPlayerControllerを取得して移動出来ないようにする
            var PlayerController = collision.gameObject.GetComponent<RigidbodyPlayerController>();
            PlayerController.enabled = false;
            m_clearFlag = true;
            m_reStartButton.gameObject.SetActive(true);　//リプレイボタンを表示
            m_titleBackButton.gameObject.SetActive(true);　//タイトルに戻るボタンを表示
            FindObjectOfType<TimeScript>().m_clearFlag = true;
            m_camera.enabled = false;　//カメラを固定する

            //発砲出来ないようにする
            if (m_mode == 0)
            {
                m_arRayScript.enabled = false;
            }
            else if (m_mode == 1)
            {
                m_snierRayScript.enabled = false;
            }
        }
    }
}
