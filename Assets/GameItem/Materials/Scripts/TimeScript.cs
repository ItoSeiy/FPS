using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間制限やクリアまでにかかった時間を
/// 計測するスクリプト
/// </summary>
public class TimeScript : MonoBehaviour
{
    /// <summary>Timerを表示するテキストを取得</summary>
    Text m_timerText;
    /// <summary>時間制限を設定したり、かかった時間を代入する変数</summary>
    [Tooltip("タイム計測モードのときはtimeを0にするのがおすすめ")]
    [SerializeField] private float m_time = 90f;
    /// <summary>0.時間制限　１.かかった時間 </summary>
    [Tooltip("0が時間制限モード　１がタイム計測モード")]
    [SerializeField] private int m_mode = 0;
    /// <summary>クリアしたかどうか</summary>
    public bool m_clearFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        m_timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_clearFlag && m_mode == 0) //時間制限モード
        {
            m_time -= Time.deltaTime;
            m_timerText.text = m_time.ToString("F2");
        }
        else if (!m_clearFlag && m_mode == 1) //タイム計測モード
        {
            m_time += Time.deltaTime;
            m_timerText.text = m_time.ToString("F2");
        }
    }
        
}
