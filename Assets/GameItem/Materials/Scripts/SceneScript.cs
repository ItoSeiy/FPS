using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移ボタンを押した時に実行
/// される関数がまとめてあるスクリプト
/// </summary>
public class SceneScript : MonoBehaviour
{
    public void TitleBack()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ARReStrat()
    {
        SceneManager.LoadScene("ARStage");
    }

    public void HandGunReStrat()
    {
        SceneManager.LoadScene("HandGunStage");
    }

    public void SniperReStarat()
    {
        SceneManager.LoadScene("SniperStage");
    }

    public void Sensitivity()
    {
        SceneManager.LoadScene("SetSensitivity");
    }
}
