using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : WindowManager
{
    public GameObject OptionWindow;
    private CursorLockMode beforeCursorMode;

    private void OnEnable()
    {
        beforeCursorMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.playerController.onTab = true;
        Time.timeScale = 0;
    }

    private void Update()
    {
        CheckCloseTab();
    }

    private void OnDisable()
    {
        //����â�� ����������� Ŀ���� ��������
        //Cursor.lockState = beforeCursorMode;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.playerController.onTab = false;
    }

    public void Button_Continue()
    {
        gameObject.SetActive(false);
    }

    public void Button_Stop()
    {
        GameManager.instance.LoadTitleScene();
        gameObject.SetActive(false);
    }

    public void Button_Option()
    {
        OptionWindow.SetActive(true);
    }

}
