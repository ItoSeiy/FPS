using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// SRステージの開始の処理を
/// してくれるスクリプト
/// </summary>
public class SRGameManager : MonoBehaviour
{
    /// <summary>カメラの取得</summary>
    [SerializeField] CinemachineVirtualCamera m_camera;
    /// <summary>移動スクリプトを取得</summary>
    [SerializeField] RigidbodyPlayerController m_moveScript;
    /// <summary>タイマー処理スクリプトを取得</summary>
    [SerializeField] TimeScript m_timeScript;
    /// <summary>スナイパーを取得</summary>
    [SerializeField] GameObject m_gun;
    /// <summary>腰うち時のレティクルを取得</summary>
    [SerializeField] Image m_reticle;
    /// <summary>開始前のカウントダウンを表示する</summary>
    [SerializeField] Text m_countDownText;
    /// <summary>開始前の説明</summary>
    [SerializeField] GameObject m_startExplanation;
    /// <summary>開始までカウントダウン</summary>
    private float m_count = 5f;

    private bool m_countFlag = false;

    void Start()
    {
        SetFalse();

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
        if (m_countFlag)//trueになったらカウントダウン開始
        {
            m_count -= Time.deltaTime;
        }

        m_countDownText.text = m_count.ToString("F0");

        if (m_count <= 0)
        {
            GameStrat();
        }
    }

    /// <summary>開始ボタンが押されたら呼ばれる</summary>
    public void CountDown()
    {
        m_countFlag = true;
        m_countDownText.enabled = true;
        m_startExplanation.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    /// <summary>playerが動けるようにする</summary>
    public void GameStrat()
    {
        m_camera.enabled = true;
        m_moveScript.enabled = true;
        m_timeScript.enabled = true;
        m_gun.SetActive(true);
        m_reticle.enabled = true;
        m_countDownText.enabled = false;
    }

    /// <summary>最初に呼ばれてplayerの動きを制限したりカメラを固定したりする</summary>
    public void SetFalse()
    {
        m_camera.enabled = false;
        m_moveScript.enabled = false;
        m_timeScript.enabled = false;
        m_gun.SetActive(false);
        m_reticle.enabled = false;
        m_countDownText.enabled = false;
    }
}
