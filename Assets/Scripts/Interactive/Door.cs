using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    public event Action _Interact;
    private const string OPEN_STRING = "LB: ����";
    private const string CLOSE_STRING = "LB: �ݱ�";

    private void Reset()
    {
        objectName = "��";
        explainComment = "LB: ����";
    }

    public override void Interact()
    {
        _Interact();
    }

    public void SetComment(bool isOpen)
    {
        if (isOpen) explainComment = CLOSE_STRING;
        else explainComment = OPEN_STRING;
    }

}
