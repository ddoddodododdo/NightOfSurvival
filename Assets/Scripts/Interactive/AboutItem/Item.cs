using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : InteractiveObject
{
    public Sprite itemImage;
    public Vector3 originRotate;

    private void Reset()
    {
        explainComment = "LB: �ݱ�";
    }

    public abstract void UseItem();

    public override void Interact()
    {
        InventoryManager.instance.AddItem(this);
    }
}
