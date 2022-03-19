using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUIManager : MonoBehaviour
{
    public PopupUI pausePopup;
    public PopupUI optionPopup;
    public PopupUI ghostDictionaryPopup;

    private Stack<PopupUI> activePopupList;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activePopupList.Count > 0)
                ClosePopup();
            else
                OpenPopup(pausePopup);
        }
    }

    private void Init()
    {
        activePopupList = new Stack<PopupUI>();

        List<PopupUI> allPopupList = new List<PopupUI>()
        {
            pausePopup, optionPopup, ghostDictionaryPopup
        };

        foreach(var popup in allPopupList)
        {
            //Ŭ���� ��ư �������� ���� �����ִ� ��ü�� Ŭ�� �����ؼ� ��
            popup.closeButton.onClick.AddListener(() => ClosePopup());
        }
    }

    private void ClosePopup()
    {
        activePopupList.Pop().gameObject.SetActive(false);
    }

    private void OpenPopup(PopupUI popup)
    {
        activePopupList.Push(popup);
        popup.gameObject.SetActive(true);

    }

    public void Button_Continue()
    {   //�� ��ư�� �������� �̰� ���� ���� �;���
        ClosePopup();
    }

    public void Button_Stop()
    {
        GameManager.instance.LoadTitleScene();
        gameObject.SetActive(false);
    }

    public void Button_Option()
    {
        OpenPopup(optionPopup);
    }

    public void Button_Dictionary()
    {
        OpenPopup(ghostDictionaryPopup);
    }
}
