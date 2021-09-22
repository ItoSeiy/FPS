using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// Sniper用 Aimする為のスクリプト
/// </summary>
public class SniperAim : MonoBehaviour
{
   
    /// <summary>Aimした時に表示するReticle</summary>
    //[SerializeField] GameObject m_aimReticle;
    /// <summary>腰うち時に表示するReticle</summary>
    [SerializeField] Image m_reticleUI;
    /// <summary>エイムしているかどうか</summary>
    public bool m_aim = false;
    /// <summary>腰うち時のRayをばらけさせる為の変数</summary>
    public Vector3 m_vector;
    [SerializeField] CinemachineVirtualCamera m_defaultCam = default;
    [SerializeField] float m_defaultFOV = 60;
    [SerializeField] float m_aimFOV = 15;
    [SerializeField] float m_aimSpeed = 10;
    [SerializeField] float m_FOVmergin = 5;
    float m_targetFOV;

    /// <summary>Aimアニメーション</summary>
    Animator m_anim;
    // Start is called before the sifirst frame update
    void Start()
    {
        //m_aimReticle.SetActive(false);
        m_anim = GetComponent<Animator>();
        m_anim.SetBool("IsAim", false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire2")) //Aimした時
        {
            m_vector = Vector3.zero;
            m_reticleUI.gameObject.SetActive(false);
            m_anim.SetBool("IsAim", true);
            m_aim = true;
           // m_targetFOV = m_aimFOV;
        }
        else //腰うち時
        {
            m_vector = new Vector3(Random.RandomRange(0, m_reticleUI.rectTransform.sizeDelta.x), Random.RandomRange(0, m_reticleUI.rectTransform.sizeDelta.y), 0) * 20f;
            m_aim = false;
           // m_aimReticle.SetActive(false);
            m_reticleUI.gameObject.SetActive(true);
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

    public void SetAimUI()
    {
       // m_aimReticle.SetActive(true);
        m_targetFOV = m_aimFOV;
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

///// <summary>
///// Aimする為のスクリプト
///// アニメーションを使いAimを再現した
///// </summary>
//public class AimScript : MonoBehaviour
//{
//    [SerializeField] Image m_ReticleUI; //Reticleを取得

//    Animator m_anim;
//    // Start is called before the first frame update
//    void Start()
//    {
//        m_targetFOV = m_defaultFOV;
//        m_anim = GetComponent<Animator>();
//        m_anim.SetBool("IsAim", false);
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButton(1)) //右クリックでエイム
//        {
//            //float present_Location = (Time.deltaTime * m_Speed) / m_distanceTwo; //Lerpで使う自身の位置を求める
//            //transform.position = Vector3.Lerp(this.gameObject.transform.position, m_AimPos.position, present_Location); Lerpを使い銃を滑らかに動かす
//            m_anim.SetBool("IsAim", true);
//            m_ReticleUI.gameObject.SetActive(false); //Reticleを消す
//        }
//        if (Input.GetMouseButtonUp(1)) //右クリックを離すと腰うちになる
//        {
//            m_ReticleUI.gameObject.SetActive(true); //Reticleを表示させる
//            m_anim.SetBool("IsAim", false);
//        }
//        if (Input.GetButtonDown("Fire2"))
//        {
//           
//        }
//        if (Input.GetButtonUp("Fire2"))
//        {
//            
//        }
//        
//    }
//}
