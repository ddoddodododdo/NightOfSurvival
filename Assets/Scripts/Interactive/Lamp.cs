using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveObject
{
    public Light lampLight;
    public AudioClip lampSound;

    void Awake()
    {
        if (lampLight.enabled)
        {
            explainComment = "LB: ����";
        }
        else
        {
            explainComment = "LB: �ѱ�";
        }
    }

    public override void Interact()
    {
        if (lampLight.enabled)
        {
            lampLight.enabled = false;
            explainComment = "LB: �ѱ�";
            SFXPlayer.instance.Play(lampSound);
        }
        else
        {
            lampLight.enabled = true;
            explainComment = "LB: ����";
            SFXPlayer.instance.Play(lampSound);
        }
            
    }


}
