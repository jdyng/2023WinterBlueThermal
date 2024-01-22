using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, UI_Define.UIEvent type = UI_Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}