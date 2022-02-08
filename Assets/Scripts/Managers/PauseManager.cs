using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : PopupUI
{
    private CursorLockMode beforeCursorMode;

    private void OnEnable()
    {
        beforeCursorMode = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.instance.playerController.onTab = true;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        //����â�� ����������� Ŀ���� ��������
        Cursor.lockState = beforeCursorMode;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.playerController.onTab = false;
    }

    

}
