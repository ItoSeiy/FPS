using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// ハンドガンステージの開始の処理を
/// してくれるスクリプト
/// </summary>
public class HandGunGameManager : MonoBehaviour
{
    /// <summary>説明用のゲームオブジェクトを取得</summary>
    [SerializeField] GameObject m_startExplanation;
    /// <summary>発砲処理のスクリプト</summary>
    [SerializeField] HandGunRay m_rayScript;
    /// <summary>playerの移動スクリプトを取得</summary>
    [SerializeField] RigidbodyPlayerController m_playerController;
    /// <summary>開始カウントダウンを表示するテキスト</summary>
    [SerializeField] Text m_countDownText;
    /// <summary>タイマー処理のスクリプトを取得</summary>
    [SerializeField] TimerScript m_timeScript;
    /// <summary>カメラを取得</summary>
    [SerializeField] CinemachineVirtualCamera m_camera;
    /// <summary>腰うち時のレティクルを取得</summary>
    [SerializeField] Image m_reticleUI;

    private float m_count = 5f;　//カウントダウン
    private bool m_countFlag = false;　//カウントダウン開始
    public bool m_startFlag = false;　
    public bool m_clearFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        Set(false);

        //下記はCinemachineのMaxSpeed（感度）部分を取得して感度の値を代入する
        var pov = m_camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_MaxSpeed = SensitivityScript.m_sensitivity;
        pov.m_VerticalAxis.m_MaxSpeed = SensitivityScript.m_sensitivity;
        Debug.Log("MaxSpeed" + pov.m_HorizontalAxis.m_MaxSpeed);
        Debug.Log("MaxSpeed" + pov.m_HorizontalAxis.m_MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_countFlag)
        {
            m_count -= Time.deltaTime;
            m_countDownText.text = m_count.ToString("F0");
        }

        if (m_clearFlag)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(m_count < 0)
        {
            GameStart();
            m_countFlag = false;
            m_count = 0;
        }
    }

    /// <summary>開始ボタンを押したらカウントダウンを始める関数</summary>
    public void CountDown()
    {
        m_countFlag = true;
        m_startExplanation.SetActive(false);
    }

    /// <summary>playerが動けるようになる関数</summary>
    public void GameStart()
    {
        m_playerController.enabled = true;
        m_rayScript.enabled = true;
        m_timeScript.enabled = true;
        m_countDownText.enabled = false;
        m_camera.enabled = true;
        m_reticleUI.enabled = true;
        m_startFlag = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>modeがtrueだったら最初の説明を消すfalseだったらゲームに必要なものを動けないようにする</summary>
    /// <param name="mode"></param>
    public void Set(bool mode)
    {
        if (mode)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            m_playerController.enabled = true;
            m_rayScript.enabled = true;
            m_timeScript.enabled = true;
            m_camera.enabled = true;
            m_reticleUI.enabled = true;

        }
        else if (!mode)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            m_playerController.enabled = false;
            m_rayScript.enabled = false;
            m_timeScript.enabled = false;
            m_camera.enabled = false;
            m_reticleUI.enabled = false;
        }
    }
}
