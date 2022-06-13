using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lamp : InteractiveObject
{
    //�������� ��, �������� �� ������ ���ڿ�
    public const string LIGHT_ON_STRING = "LB: ����";
    public const string LIGHT_OFF_STRING = "LB: �ѱ�";
    public static int idSetter = 0;

    public Light lampLight;
    public AudioClip lampSound;
    public LayerMask ghostLayer;
    public int id;

    private Color _emissionColor;
    private Color _lightColor;
    private Material emissionMaterial;

    private bool _isOnLight;

    //void Awake()
    //{
    //    emissionMaterial = GetComponent<MeshRenderer>().materials[3];
    //    _emissionColor = lampLight.color;
    //    _lightColor = lampLight.color;

    //    //Set Lamp �Լ��� ���� ���� ����ż� ��������
    //    SettingSave();
    //    SetLamp();
    //    StartCoroutine(BlinkLight());
    //}

    private void Start()
    {
        emissionMaterial = GetComponent<MeshRenderer>().materials[3];
        _emissionColor = lampLight.color;
        _lightColor = lampLight.color;

        SettingSave();
        SetLamp();
        StartCoroutine(BlinkLight());
    }

    private void SettingSave()
    {
        id = idSetter++;
        LampManager.instance.allLampDictionary.Add(id, this);
    }

    public override void Interact()
    {
        _isOnLight = !_isOnLight;
        SetLamp();
        SFXPlayer.instance.Play(lampSound);
    }

    public void SetLamp(bool isOnLight)
    {
        _isOnLight = isOnLight;
        SetLamp();
    }

    private void SetLamp()
    {
        lampLight.enabled = _isOnLight;
        explainComment = _isOnLight ? "LB: ����" : "LB: �ѱ�";
        emissionMaterial.SetColor("_EmissionColor", _isOnLight ? _emissionColor : Color.black);
    }

    private IEnumerator BlinkLight()
    {
        //�������� ������ �����̰� �ٸ��� �ϱ����� offset ����
        //WaitTimeManager�� �ִ� ��ųʸ��� ������ �ð��� �߰����ִµ�
        //�Ǽ��� �ϸ� ����������ŭ �߰��Ǿ 0~10 ������ ����
        yield return WaitTimeManager.WaitForSeconds(Random.Range(0, 10) * 0.1f);

        while (true)
        {
            if (_isOnLight && CheckIsInsideGhost())
            {
                lampLight.DOColor(Color.black, 0.3f)
                .SetEase(Ease.InQuart)
                .SetLoops(1, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    lampLight.color = _lightColor;
                });
            }
            yield return WaitTimeManager.WaitForSeconds(1);
        }
    }

    private bool CheckIsInsideGhost()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 20, GameData.GHOST_LAYER_MASK);
        if(cols.Length > 0)
        {
            return true;
        }
        return false;

        //return false;
    }


}
