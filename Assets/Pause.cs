using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : HandGunGameManager
{
    private bool pause;
    public static bool s_isPaused;
    [SerializeField]GameObject m_pauseUI;
    [SerializeField] AimScript m_aimScript;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && !pause)
        {
            m_pauseUI.gameObject.SetActive(true);
            Set(false);
            m_aimScript.enabled = false;
            pause = true;
            s_isPaused = true;
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && pause)
        {
            m_pauseUI.gameObject.SetActive(false);
            Set(true);
            m_aimScript.enabled = true;
            pause = false;
            s_isPaused = false;
        }

    }
}
