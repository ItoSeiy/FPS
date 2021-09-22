using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 見せかけの銃弾に力を加える為のスクリプト
/// </summary>
public class BulletAddForse : MonoBehaviour
{
    /// <summary>Rayと見せかけの銃弾の始点</summary>
    GameObject m_Bullet_Spwan;
    
    Rigidbody m_Bullet_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_Bullet_Spwan = GameObject.Find("BulletSpwan");
        m_Bullet_rb = this.gameObject.GetComponent<Rigidbody>();  
        m_Bullet_rb.AddForce(m_Bullet_Spwan.transform.forward * 10000f); //見せかけの銃弾を飛ばす
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1f); //見せかけの銃弾を削除する
    }
}
