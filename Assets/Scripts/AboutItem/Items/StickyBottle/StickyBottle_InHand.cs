using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBottle_InHand : InHandItem
{
    public GameObject sticky_Used;

    public override bool UseItem()
    {
        Vector3 forward = transform.parent.forward;

        //transform.parent�� Used���� �÷��̾��� forward�� �������� ���� ����
        Instantiate(sticky_Used, transform.position + forward
            , transform.rotation, transform.parent);

        
        return true;
    }

}
