using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;


public class GameClear : MonoBehaviour
{
    //Inspectorでキャラクターとゴールオブジェクトの指定を出来る様にします。
    [SerializeField] GameObject m_plyaer;
    [SerializeField] TextMeshProUGUI m_clearText;
    [SerializeField] TimerScript m_clearTime;
    [SerializeField] Image m_reticle;
    [SerializeField] Text m_bulletCount;
    [SerializeField] TextMeshProUGUI m_goToTheGoal;
    [SerializeField] bool m_flag = false;
    private AudioSource m_audioSource;

    [SerializeField] CinemachineBrain m_camera;
    [SerializeField] GameObject m_rePlay;
    [SerializeField] GameObject m_titleBack;
    [SerializeField] GameObject m_gun;
    [SerializeField] HandGunGameManager m_gameManager;

    private void OnTriggerEnter(Collider other)
    {
        
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.gameObject.tag == "Player")
        {
            m_clearText.gameObject.SetActive(true);
            m_plyaer.SetActive(false);
            m_reticle.gameObject.SetActive(false);
            m_bulletCount.gameObject.SetActive(false);
            m_goToTheGoal.gameObject.SetActive(false);
            m_audioSource.Play();
            m_clearTime.ClearTime();

            m_gameManager.m_clearFlag = true;
            m_rePlay.SetActive(true);
            m_titleBack.SetActive(true);
            m_gun.SetActive(false);
            m_camera.enabled = false;
        }
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    /*private void ClearTime()
    {
        Vector2 pos = new Vector2(Screen.width / 2, Screen.height / 2);
        m_clearText.transform.position = pos;
        //m_clearTime.transform.localScale = 
    }*/
}