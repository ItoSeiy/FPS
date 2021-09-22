using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptRoot : MonoBehaviour
{
    [SerializeField]
    List<OptMember> Members    = null; 

    int             sno = -1;

    /// <summary>
    /// start
    /// </summary>
    void Start()
    {
        StartCoroutine(loop_optionMenu());
    }

    /// <summary>
    /// onenable
    /// </summary>
    void OnEnable()
    {
        for (int i = 0; i < Members.Count; i++)
        {
            Members[i].Initialize(i);
            Members[i].FetchValue();
        }
    }

    /// <summary>
    /// update
    /// </summary>
    IEnumerator loop_optionMenu()
    {
        Focus(0, false);

        while(true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                int no = sno;
                if (--no < 0)
                {
                    no = 0;
                }
                Focus(no, true);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            {
                int no = sno;
                if (++no >= Members.Count)
                {
                    no = Members.Count-1;
                }
                Focus(no, true);
            }

            yield return null;
        }
    }

    /// <summary>
    /// 選択
    /// </summary>
    /// <param name="sound">true..サウンドを鳴らす</param>
    public void Focus(int no, bool sound)
    {
        if (sno == no)
        {
            return;
        }

        for (int i = 0; i < Members.Count; i++)
        {
            if (i == no)
            {
                Members[i].Focused();
            }
            else
            {
                Members[i].UnFocused();
            }
        }
        
        if (sound == true)
        {
            // sound
            SoundPlay.Play();
        }

        sno = no;
    }

    /// <summary>
    /// Inspector - OnChange
    /// </summary>
    public void ChangeFullScreen(int no)
    {
        Screen.SetResolution(Screen.width, Screen.height, no == 0 ? true : false);
    }

    /// <summary>
    /// Inspector - OnFetch
    /// </summary>
    public void FetchFullScreen(OptMember.FetchArgs args)
    {
        args.No = SaveData.FullScreen == true ? 0 : 1;
    }

    public void FetchSound(OptMember.FetchArgs args)
    {
        if (SaveData.SoundVolume == 0)
        {
            args.No = 2;
        }
        else
        if (SaveData.SoundVolume == 50)
        {
            args.No = 1;
        }
        else
        {
            args.No = 0;
        }
    }

    /// <summary>
    /// Inspector - OnUpdate
    /// </summary>
    public void UpdateFullScreen(int no)
    {
        SaveData.FullScreen = no == 0 ? true : false;
    }

    public void UpdateSound(int no)
    {
        if (no == 0)
        {
            SaveData.SoundVolume = 1;
        }
        else
        if (no == 1)
        {
            SaveData.SoundVolume = 0.5f;
        }
        else
        if (no == 2)
        {
            SaveData.SoundVolume = 0;
        }
    }
}
