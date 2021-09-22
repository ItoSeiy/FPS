using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class OptMember : MonoBehaviour
{
    /// <summary>
    /// OnFetch の戻り値用
    /// </summary>
    public class FetchArgs : EventArgs
    {
        public int No;
    }

    /// <summary>
    /// 引数のあるイベントを Inspector 上に表示させるための定義
    /// </summary>
    [Serializable]
    public class OnFetchEvent  : UnityEvent<FetchArgs> {}
    [Serializable]
    public class OnUpdateEvent : UnityEvent<int> {}
    [Serializable]
    public class OnChangeEvent : UnityEvent<int> {}

    public delegate void OnFocusEvent(int no, bool sound);

    [SerializeField]
    TextMeshProUGUI    Name     = null;
    [SerializeField]
    List<GameButton>   Buttons  = null;
    [SerializeField]
    OnFetchEvent       OnFetch  = null;
    [SerializeField]
    OnUpdateEvent      OnUpdate = null;
    [SerializeField]
    OnFocusEvent       OnFocus  = null;
    [SerializeField]
    OnChangeEvent      OnChange = null;

    bool focused;
    int  focusNo = 0;
    int  sno = -1;

    /// <summary>
    /// awake
    /// </summary>
    void Awake()
    {
        OptRoot root = GetComponentInParent<OptRoot>();
        OnFocus = root.Focus;
    }

    /// <summary>
    /// start
    /// </summary>
    void Start()
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].SetClickEvent(click, i);
        }
    }

    /// <summary>
    /// update
    /// </summary>
    void Update()
    {
        if (focused == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            int no = sno;
            if (--no < 0)
            {
                no = 0;
            }
            Select(no, true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            int no = sno;
            if (++no >= Buttons.Count)
            {
                no = Buttons.Count-1;
            }
            Select(no, true);
        }
    }

    /// <summary>
    /// フォーカス番号（上から何番目の項目か）を設定する
    /// </summary>
    public void Initialize(int no)
    {
        focusNo = no;
        sno     = -1;
    }

    /// <summary>
    /// focus on
    /// </summary>
    public void Focused()
    {
        focused = true;
        Name.color = new Color(0,0,0,1);
    }

    /// <summary>
    /// focus off
    /// </summary>
    public void UnFocused()
    {
        focused = false;
        Name.color = new Color(0,0,0,0.25f);
    }

    /// <summary>
    /// 選択
    /// </summary>
    /// <param name="sound">true..サウンドを鳴らす</param>
    public void Select(int no, bool sound)
    {
        if (sno == no)
        {
            return;
        }

        for (int i = 0; i < Buttons.Count; i++)
        {
            if (i == no)
            {
                Buttons[i].Select();
            }
            else
            {
                Buttons[i].UnSelect();
            }
        }
        
        if (sound == true)
        {
            //sound
            SoundPlay.Play();
        }

        sno = no;
        OnChange?.Invoke(sno);
        OnUpdate?.Invoke(sno);
    }
    
    /// <summary>
    /// 外部のオプション値をボタンに反映する。
    /// インスペクタで OnFetch を設定しておく必要がある
    /// </summary>
    public void FetchValue()
    {
        var args = new FetchArgs();
        OnFetch?.Invoke(args);
        fetchSelectNo(args.No);
    }

    /// <summary>
    /// ボタンの状態を外部のオプション値に反映する。
    /// インスペクタで OnUpdate を設定しておく必要がある
    /// </summary>
    public void UpdateValue()
    {
        OnUpdate?.Invoke(sno);
    }

    /// <summary>
    /// click event
    /// </summary>
    void click(object obj)
    {
        int no = (int)obj;
        
        Select(no, true);
        OnFocus?.Invoke(focusNo, false);
    }

    /// <summary>
    /// 指定番号のボタンを選択状態にする
    /// </summary>
    public void fetchSelectNo(int no)
    {
        no = Mathf.Clamp(no, 0, Buttons.Count-1);
        Select(no, false);
    }

}
