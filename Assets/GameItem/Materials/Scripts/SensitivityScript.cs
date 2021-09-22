using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 感度設定をするスクリプト
/// 感度設定シーンで使っている
/// </summary>
public class SensitivityScript : MonoBehaviour
{
    /// <summary>カメラを取得</summary>
    [SerializeField] CinemachineVirtualCamera m_camera;
    /// <summary> 現在の感度を表示するテキスト</summary>
    [SerializeField] Text m_sensitivityText;
    /// <summary>どこからでも取得出来るようにしてるこの値がMaxSpeedに代入される</summary>
    public static float m_sensitivity = 70;
    /// <summary> 現在の感度</summary>
    private static int m_number = 3;

    private CinemachinePOV m_pov;
    // Start is called before the first frame update
    void Start()
    {
        m_pov = m_camera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();
        m_sensitivityText.text = "今の感度は" + m_number;
    }

    // Update is called once per frame
    void Update()
    {
        //感度設定シーンにあるボタンによって感度が切り替わる
        switch (m_number)
        {
            case 1:
                m_sensitivity = 50;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 2:
                m_sensitivity = 60;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 3:
                m_sensitivity = 70;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 4:
                m_sensitivity = 80;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 5:
                m_sensitivity = 100;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 6:
                m_sensitivity = 200;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 7:
                m_sensitivity = 300;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 8:
                m_sensitivity = 400;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 9:
                m_sensitivity = 500;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
            case 10:
                m_sensitivity = 600;
                m_sensitivityText.text = "今の感度は" + m_number;
                break;
               
        }

        //感度設定シーンにあるカメラのMaxSpeedに代入
        m_pov.m_HorizontalAxis.m_MaxSpeed = m_sensitivity;
        m_pov.m_VerticalAxis.m_MaxSpeed = m_sensitivity;
    }

    //ボタンが押された時に現在の感度が変わる
    public void SetSensitivity(int number)
    {
        m_number = number;
    }
}
