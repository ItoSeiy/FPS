using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// ARStageの開始の処理をしてくれるスクリプト
/// </summary>
public class ARGameManager : MonoBehaviour
{
    /// <summary>説明用のゲームオブジェクトを取得</summary>
    [SerializeField] GameObject m_staratExplanation;
    /// <summary>ARを取得</summary>
    [SerializeField] GameObject m_akm;
    /// <summary>タイマースクリプトを取得</summary>
    [SerializeField] TimeScript m_timeScript;
    /// <summary>playerの移動スクリプトを取得</summary>
    [SerializeField] RigidbodyPlayerController m_playerController;
    /// <summary>腰うち時のレティクルを取得</summary>
    [SerializeField] Image m_aimReticle;
    /// <summary>エイム時のレティクルを取得</summary>
    [SerializeField] Image m_center;
    /// <summary>カメラを取得</summary>
    [SerializeField] CinemachineVirtualCamera m_camera;
    /// <summary>スタートボタンを押した時に始まるカウントダウンを表示するテキスト</summary>
    [SerializeField] Text m_countDownText;
    /// <summary>説明用の敵のイメージを取得</summary>
    [SerializeField] Image m_enemy; 　　
    /// <summary>説明用の民間人のイメージを取得</summary>
    [SerializeField] Image m_Civilian;　
   
    private float m_count = 5f;　//カウントダウン
    private bool m_countFlag = false;　//カウントダウン開始
   
    void Start()
    {
        Set(false);　//playerの動きや発砲ができないようにするカメラを固定する

        //下記はCinemachineのMaxSpeed（感度）部分を取得して感度の値を代入する
        var pov = m_camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_MaxSpeed = SensitivityScript.m_sensitivity;
        pov.m_VerticalAxis.m_MaxSpeed = SensitivityScript.m_sensitivity;
        Debug.Log("MaxSpeed" + pov.m_HorizontalAxis.m_MaxSpeed);
        Debug.Log("MaxSpeed" + pov.m_HorizontalAxis.m_MaxSpeed);
    }

    void Update()
    {
        if (m_countFlag)　//trueになったらカウントダウン開始
        {
            m_count -= Time.deltaTime;
            m_countDownText.text = m_count.ToString("F0"); //カウントをテキストに表示
        }

        if (m_count <=  0)
        {
            m_countFlag = false;
            m_countDownText.enabled = false;
            GameStart();
        }
    }

    /// <summary>開始ボタンを押したらカウントダウンを始める関数</summary>
    public void CountDown()
    {
        Set(true);
        m_countFlag = true;
    }

    /// <summary>playerが動けるようになる関数</summary>
    public void GameStart()
    {
        m_timeScript.enabled = true;
        m_playerController.enabled = true;
        m_center.enabled = true;
        m_camera.enabled = true;
        m_akm.SetActive(true);
        m_aimReticle.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>modeがtrueだったら最初の説明を消すfalseだったらゲームに必要なものを動けないようにする</summary>
    /// <param name="mode"></param>
    public void Set(bool mode)
    {
        if (mode)
        {
            m_staratExplanation.SetActive(false);
            m_enemy.enabled = false;
            m_Civilian.enabled = false;
        }
        else if (!mode)
        {
            m_timeScript.enabled = false;
            m_playerController.enabled = false;
            m_akm.SetActive(false);
            m_aimReticle.enabled = false;
            m_center.enabled = false;
            m_camera.enabled = false;
        }
    }
}
