using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBin : InteractiveObject
{
    public static PlayerController playerController;
    public const string hideString = "LB: ����";
    public const string unhideString = "LB: ������";

    public GameObject hideCamera;
    public Transform forwardTransform;
    public AudioClip hideSound;

    private void Reset()
    {
        objectName = "����";
        explainComment = hideString;
    }

    private void Start()
    {
        
        if (playerController == null)
        {
            playerController = GameManager.instance.playerController;
        }
    }

    private IEnumerator CheckUnHide()
    {
        //��Ŭ�� �Ŀ� ����Ǿ �ٷ� UnHide��. 1������ �ǳʶٱ�
        yield return null; 

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Unhide();
                break;
            }

            yield return null;
        }
    }

    public override void Interact()
    {
        explainComment = unhideString;
        hideCamera.SetActive(true);
        playerController.OffObjectInformation();
        GameManager.instance.hideWindow.SetActive(true);
        SFXPlayer.instance.Play(hideSound);

        //���ֿ��� �������� ���ָ� ���� ���ֵ���
        playerController.gameObject.transform.position = forwardTransform.position;
        playerController.gameObject.SetActive(false);

        StartCoroutine(CheckUnHide());
    }

    private void Unhide()
    {
        explainComment = hideString;
        hideCamera.SetActive(false);
        GameManager.instance.hideWindow.SetActive(false);

        SetPlayerLook();
        playerController.gameObject.SetActive(true);
    }

    private void SetPlayerLook()
    {
        playerController.gameObject.transform.LookAt(gameObject.transform);
        Vector3 rot = playerController.transform.eulerAngles;

        playerController.SetRotateWhenOutHideBin(rot);
    }

}
