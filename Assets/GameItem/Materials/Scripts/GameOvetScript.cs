using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SRステージでビルから落ちた時にゲームオーバー
/// を出すスクリプト
/// </summary>
public class GameOvetScript : MonoBehaviour
{
    [SerializeField] Text m_gameOverText;
    [SerializeField] Button m_reStartButton;
    [SerializeField] Button m_titleBackButton;
    [SerializeField] SniperRay m_snierRayScript;
    // Start is called before the first frame update
    void Start()
    {
        m_gameOverText.enabled = false;
        m_reStartButton.gameObject.SetActive(false);
        m_titleBackButton.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_gameOverText.enabled = true;
            m_snierRayScript.enabled = false;
            m_reStartButton.gameObject.SetActive(true);
            m_titleBackButton.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
