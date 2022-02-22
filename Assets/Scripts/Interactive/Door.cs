using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    public event Action _Interact;
    private static string openString = "LB: ����";
    private static string closeString = "LB: �ݱ�";


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
        if (isOpen) explainComment = closeString;
        else explainComment = openString;
    }

}
