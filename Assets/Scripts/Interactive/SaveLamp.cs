using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLamp : InteractiveObject
{
    private bool isSave = false;


    public override void Interact()
    {
        if (!isSave)
        {
            Debug.Log("�����͸� �����մϴ�");
            isSave = true;
            SaveManager.instance.Save();
            TutorialManager.instance.ShowTutoWindow("����Ǿ����ϴ�.");
        }
    }

}
