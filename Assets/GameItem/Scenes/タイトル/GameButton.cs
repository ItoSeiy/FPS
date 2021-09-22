using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Image           ImgFrame    = null;
    [SerializeField]
    Image           MouseHover  = null;
    [SerializeField]
    Image           ImgSelected = null;
    [SerializeField]
    Text TxtDesc     = null;

    Color           camColor;

    Action<object>  clickEvent;
    object          clickEventTag;
    bool            selected;

    /// <summary>
    /// awake
    /// </summary>
    void Awake()
    {
        camColor = Camera.main.backgroundColor;

        dispExitMouseHover();
        if (selected == true)
        {
            dispSelected();
        }
        else
        {
            dispUnSelected();
        }
    }

    /// <summary>
    /// on disable
    /// </summary>
    void OnDisable()
    {
        dispExitMouseHover();
        dispUnSelected();
    }

    public void SetClickEvent(Action<object> _clickEvent, object _tag)
    {
        clickEvent    = _clickEvent;
        clickEventTag = _tag;
    }

    public void Select()
    {
        selected = true;
        dispSelected();
    }

    public void UnSelect()
    {
        selected = false;
        dispUnSelected();
    }

    public void Hover()
    {
        dispHover();
    }

    void dispSelected()
    {
        ImgFrame.color = new Color(0, 0, 0, 1);
        ImgSelected.color = new Color(0, 0, 0, 1);
        TxtDesc.color  = new Color(camColor.r, camColor.g, camColor.b, 1);
    }

    void dispUnSelected()
    {
        //ImgFrame.color = new Color(0, 0, 0, 0.5f);
        //ImgSelected.color = new Color(0, 0, 0, 0);
        //TxtDesc.color  = new Color(0, 0, 0, 0.5f);
    }

    void dispHover()
    {
        ImgFrame.color = new Color(0, 0, 0, 1);
        ImgSelected.color = new Color(0, 0, 0, 0);
        TxtDesc.color  = new Color(0, 0, 0, 1);
    }

    void dispEnterMouseHover()
    {
        MouseHover.color = new Color(0, 0, 0, 1);
    }

    void dispExitMouseHover()
    {
        MouseHover.color = new Color(0, 0, 0, 0);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        dispEnterMouseHover();
    }
    
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        dispExitMouseHover();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        clickEvent?.Invoke(clickEventTag);
    }
}
