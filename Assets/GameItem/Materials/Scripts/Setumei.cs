using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// タイトルシーンで各ステージの簡単な説明
/// を表示するスクリプト
/// </summary>
public class Setumei : MonoBehaviour
{
    /// <summary>説明を表示するテキストを取得</summary>
    [SerializeField] Text m_setumei;
    
    void Start()
    {
        //最初は非表示にしておく
        m_setumei.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //タイトルシーンEscapeを押すとでアプリケーションを閉じる
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>ハンドガンステージ選択のボタンの上にカーソルがくると呼ばれる</summary>
    public void SetHaundGun()
    {
        Set();
        m_setumei.text = "タイムアタック" + "\n" + "すべてのターゲットを倒しゴールを目指す";
    }

    /// <summary>ARステージ選択のボタンの上にカーソルがくると呼ばれる</summary>
    public void SetARGun()
    {
        Set();
        m_setumei.text = "スコアアタック" + "\n" + "出来るだけ敵を倒しスコアを稼ぎながらゴールを目指す";
    }

    /// <summary>SRステージ選択のボタンの上にカーソルがくると呼ばれる</summary>
    public void SetSniper()
    {
        Set();
        m_setumei.text = "タイムアタック" + "\n" + "すべてのターゲットを見つけ倒しゴールを目指す";
    }

    /// <summary>カーソルがボタンの上から離れたら呼び出される</summary>
    public void End()
    {
        m_setumei.gameObject.SetActive(false);
    }

    /// <summary>説明用テキストを表示する</summary>
    public void Set()
    {
        m_setumei.gameObject.SetActive(true);
    }
}
