using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

    private Color _lightColor;
    private Material emissionMaterial;
    private Collider[] insideGhostCols;

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
        explainComment = _isOnLight ? LIGHT_ON_STRING : LIGHT_OFF_STRING;
        emissionMaterial.SetColor("_EmissionColor", _isOnLight ? _lightColor : Color.black);
    }

    private IEnumerator BlinkLight()
    {
        //�������� ������ �����̸� �ٸ��� �ϱ����� offset ����
        //WaitTimeManager�� �ִ� ��ųʸ��� ������ �ð��� �߰����ִµ�
        //�Ǽ�(0.0f ~ 0.1f)�� �ϸ� ���� �ٸ� �Ǽ��� ���� ��ųʸ��� ���� �߰��ż� ������ 10���� �������� ��.
        yield return WaitTimeManager.WaitForSeconds(Random.Range(0, 10) * 0.1f);

        while (true)
        {
            float waitTime = 2f;

            if (_isOnLight && CheckIsInsideGhost())
            {
                //�������� ��ٸ��� �ð� �ٿ��� �� �����̵���
                float closeGhostDis = insideGhostCols.Min(t => (transform.position - t.transform.position).sqrMagnitude);
                float subTime = 2 / (closeGhostDis * 0.1f);
                waitTime -= subTime > 1.7f ? 1.7f : subTime;

                lampLight.DOColor(Color.black, 0.4f - (0.3f/waitTime)*0.2f)
                .SetEase(Ease.InQuart)
                .SetLoops(1, LoopType.Yoyo)
                .OnUpdate(() => emissionMaterial.SetColor("_EmissionColor", lampLight.color))
                .OnComplete(() =>
                {
                    lampLight.color = _lightColor;
                    emissionMaterial.SetColor("_EmissionColor", lampLight.color);
                });
                Debug.Log("waitTime: " + waitTime);
            }
            
            yield return WaitTimeManager.WaitForSeconds(waitTime);
        }
    }

    private bool CheckIsInsideGhost()
    {
        insideGhostCols = Physics.OverlapSphere(transform.position, 20, GameData.GHOST_LAYER_MASK);


        return insideGhostCols.Length > 0;

        //return false;
    }


}
