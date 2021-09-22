using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    [SerializeField] GameObject m_slideParts;
    BulletCount m_bulletCounScript;
    private float m_time = 0f; //反動が戻るまでの時間
    private bool m_timeflag = false; //時間を測り始める為のflag
    
    // Start is called before the first frame update
    void Start()
    {
        m_bulletCounScript = this.gameObject.GetComponent<BulletCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_timeflag == true) //時間を測る
        {
            m_time += Time.deltaTime;
        }
        Move();
    }

    /// <summary>反動をつくるメソッド</summary>
    private void Move()
    {
        if (m_bulletCounScript.m_count > 0) //弾数をがゼロかゼロより大きかったら実行
        {
            if (Input.GetMouseButtonDown(0)) //左クリックされたら実行
            {
                this.gameObject.transform.Rotate(8f, 0f, 0f);
                m_slideParts.transform.Translate(0f, 0f, 0.02f);
                m_timeflag = true; //時間計測を開始
            }

            if (m_time > 0.1f) //0.1fより時間が大きくなったら反動をもどす
            {
                //this.gameObject.transform.Rotate(-8f, 0f, 0f);
                //this.gameObject.transform.rotation = this.transform.TransformDirection(Quaternion.identity);
                this.gameObject.transform.localRotation = Quaternion.Euler(0,180,0);
                m_slideParts.transform.Translate(0f, 0f, -0.02f);
                m_timeflag = false;
                m_time = 0f;
            }
        }
    }
}
