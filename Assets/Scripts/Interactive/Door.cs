using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{
    public DoorBinder binder;
    private static string openString = "LB: ����";
    private static string closeString = "LB: �ݱ�";


    private void Reset()
    {
        objectName = "��";
        explainComment = "LB: ����";
    }

    public override void Interact()
    {
        if (!binder.isMoving)
        {
            binder.Interact();
        }
    }

    public void SetComment()
    {
        if (binder.isOpen) explainComment = closeString;
        else explainComment = openString;
    }

}
