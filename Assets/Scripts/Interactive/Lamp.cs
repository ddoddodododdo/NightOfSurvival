using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveObject
{
    public Light lampLight;
    public AudioClip lampSound;

    private Color emissionColor;

    void Awake()
    {
        emissionColor = lampLight.color;

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
            //Ų���� -> ������
            lampLight.enabled = false;
            explainComment = "LB: �ѱ�";
            GetComponent<MeshRenderer>().materials[3].SetColor("_EmissionColor", Color.black);
            SFXPlayer.instance.Play(lampSound);
        }
        else
        {   //������ -> Ų����
            lampLight.enabled = true;
            explainComment = "LB: ����";
            GetComponent<MeshRenderer>().materials[3].SetColor("_EmissionColor", emissionColor);
            SFXPlayer.instance.Play(lampSound);
        }
            
    }


}
