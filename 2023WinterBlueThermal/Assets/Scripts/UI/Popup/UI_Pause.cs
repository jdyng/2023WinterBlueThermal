using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Pause : UI_Popup
{
    [SerializeField]
    private Define.Scenes _titleScene;
    enum Buttons
    {
        ResumeButton,
        SaveButton,
        LoadButton,
        OptionButton,
        QuitButton
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

        GetButton((int)Buttons.ResumeButton).gameObject.AddUIEvent(ResumeButtonClicked);
        GetButton((int)Buttons.SaveButton).gameObject.AddUIEvent(SaveButtonClicked);
        GetButton((int)Buttons.LoadButton).gameObject.AddUIEvent(LoadButtonClicked);
        GetButton((int)Buttons.OptionButton).gameObject.AddUIEvent(OptionButtonClicked);
        GetButton((int)Buttons.QuitButton).gameObject.AddUIEvent(QuitButtonClicked);
    }

    public void ResumeButtonClicked(PointerEventData data)
    {
        Escape();
    }

    public override void Escape()
    {
        base.Escape();
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void SaveButtonClicked(PointerEventData data)
    {

    }
    public void LoadButtonClicked(PointerEventData data)
    {

    }
    public void OptionButtonClicked(PointerEventData data)
    {
        ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_Options>();
    }
    public void QuitButtonClicked(PointerEventData data)
    {
        SceneManagement.Instance.MoveScene(_titleScene);
        Time.timeScale = 1;
        Managers.UI.CloseAllPopupUI();
    }
}