using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Options : UI_Popup
{
    enum Buttons
    {
        AudioButton,
        VideoButton,
        GameplayButton,
        CustomizeButton,
        CheatsButton
    }

    enum Texts
    {

    }

    private void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        //GetButton((int)Buttons.AudioButton).gameObject.AddUIEvent(ResumeButtonClicked);
        //GetButton((int)Buttons.VideoButton).gameObject.AddUIEvent(SaveButtonClicked);
        //GetButton((int)Buttons.GameplayButton).gameObject.AddUIEvent(LoadButtonClicked);
        //GetButton((int)Buttons.CustomizeButton).gameObject.AddUIEvent(OptionButtonClicked);
        //GetButton((int)Buttons.CheatsButton).gameObject.AddUIEvent(QuitButtonClicked);
    }
    public override void Escape()
    {
        base.Escape();
        Managers.UI.ShowPopupUI<UI_Pause>();
    }
}
