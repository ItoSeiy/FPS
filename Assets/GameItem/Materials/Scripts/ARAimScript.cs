using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// AR用 Aimする為のスクリプト
/// アニメーションを使いAimを再現した
/// </summary>
public class ARAimScript : MonoBehaviour
{
    /// <summary>Reticleを取得</summary>
    [SerializeField] Image m_ReticleUI;
    /// <summary>スコープ用Reticleを取得</summary>
    [SerializeField] Image m_scopeReticleUI;
    /// <summary>腰うち時のRayをばらけさせる為の変数</summary>
    public Vector3 vector;
    /// <summary>Aimアニメーション</summary>
    Animator m_anim;
    [SerializeField] CinemachineVirtualCamera m_defaultCam = default;
    [SerializeField] float m_defaultFOV = 60;
    [SerializeField] float m_aimFOV = 15;
    [SerializeField] float m_aimSpeed = 10;
    [SerializeField] float m_FOVmergin = 5;
    float m_targetFOV;
    // Start is called before the first frame update
    void Start()
    {
        m_targetFOV = m_defaultFOV;
        m_anim = GetComponent<Animator>();
        m_anim.SetBool("IsAim", false);
        m_scopeReticleUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")) //右クリックでエイム
        {
            vector = Vector3.zero;
            m_anim.SetBool("IsAim", true);
            m_ReticleUI.gameObject.SetActive(false); //Reticleを消す
            m_targetFOV = m_aimFOV;
        }
        else
        {
            //腰うち時Rayがばらける処理を追加
            vector = new Vector3(Random.RandomRange(0, m_ReticleUI.rectTransform.sizeDelta.x), Random.RandomRange(0, m_ReticleUI.rectTransform.sizeDelta.y), 0) * 50; 
            m_ReticleUI.gameObject.SetActive(true); //Reticleを表示させる
            m_scopeReticleUI.gameObject.SetActive(false);//スコープ用Reticleを消す
            m_anim.SetBool("IsAim", false);
            m_targetFOV = m_defaultFOV;
        }
        if (m_defaultCam.m_Lens.FieldOfView > m_targetFOV + m_FOVmergin)
        {
            m_defaultCam.m_Lens.FieldOfView -= Time.deltaTime * m_aimSpeed;
        }
        else if (m_defaultCam.m_Lens.FieldOfView < m_targetFOV - m_FOVmergin)
        {
            m_defaultCam.m_Lens.FieldOfView += Time.deltaTime * m_aimSpeed;
        }

    }

    public void SetScopeReticle()
    {
        m_scopeReticleUI.gameObject.SetActive(true);
    }
}

//float present_Location = (Time.deltaTime * m_Speed) / m_distanceTwo; //Lerpで使う自身の位置を求める
//transform.position = Vector3.Lerp(this.gameObject.transform.position, m_AimPos.position, present_Location); Lerpを使い銃を滑らかに動かす

