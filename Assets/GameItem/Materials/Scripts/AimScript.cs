using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// Aimする為のスクリプト
/// アニメーションを使いAimを再現した
/// </summary>
public class AimScript : MonoBehaviour
{
    [SerializeField] Image m_ReticleUI; //Reticleを取得
    [SerializeField] CinemachineVirtualCamera m_defaultCam = default;
    [SerializeField] float m_defaultFOV = 60;
    [SerializeField] float m_aimFOV = 15;
    [SerializeField] float m_aimSpeed = 10;
    [SerializeField] float m_FOVMergin = 5;
    [SerializeField] HandGunGameManager m_gameManager;
    float m_targetFOV;
    /// <summary>腰うち時のRayをばらけさせる為の変数</summary>
    public Vector3 vector;

    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        m_targetFOV = m_defaultFOV;
        m_anim = GetComponent<Animator>();
        m_anim.SetBool("IsAim", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameManager.m_startFlag)
        {
            if (Input.GetMouseButton(1)) //右クリックでエイム
            {
                vector = Vector3.zero;
                m_anim.SetBool("IsAim", true);
                m_ReticleUI.gameObject.SetActive(false); //Reticleを消す
            }
            else //右クリックを離すと腰うちになる
            {
                vector = new Vector3(Random.RandomRange(0, m_ReticleUI.rectTransform.sizeDelta.x), Random.RandomRange(0, m_ReticleUI.rectTransform.sizeDelta.y), 0);
                m_ReticleUI.gameObject.SetActive(true); //Reticleを表示させる
                m_anim.SetBool("IsAim", false);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                m_targetFOV = m_aimFOV;
            }

            if (Input.GetButtonUp("Fire2"))
            {
                m_targetFOV = m_defaultFOV;
            }

            if (m_defaultCam.m_Lens.FieldOfView > m_targetFOV + m_FOVMergin)
            {
                m_defaultCam.m_Lens.FieldOfView -= Time.deltaTime * m_aimSpeed;
            }
            else if (m_defaultCam.m_Lens.FieldOfView < m_targetFOV - m_FOVMergin)
            {
                m_defaultCam.m_Lens.FieldOfView += Time.deltaTime * m_aimSpeed;
            }
        }
        
    }
}
