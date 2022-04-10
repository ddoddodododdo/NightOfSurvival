using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveObject
{
    public Light lampLight;
    public AudioClip lampSound;

    private Color emissionColor;
    private Material emissionMaterial;

    void Awake()
    {
        emissionMaterial = GetComponent<MeshRenderer>().materials[3];
        emissionColor = lampLight.color;
        emissionColor.r = 0.8f;

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
            emissionMaterial.SetColor("_EmissionColor", Color.black);
            SFXPlayer.instance.Play(lampSound);
        }
        else
        {   //������ -> Ų����
            lampLight.enabled = true;
            explainComment = "LB: ����";
            emissionMaterial.SetColor("_EmissionColor", emissionColor);
            SFXPlayer.instance.Play(lampSound);
        }
            
    }


}
