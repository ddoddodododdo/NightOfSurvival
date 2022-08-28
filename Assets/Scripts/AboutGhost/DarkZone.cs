using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZone : MonoBehaviour
{
    public Lamp[] lamps;
    public LayerMask playerLayer;
    public ShadowGhost shadowGhost;

    private Coroutine Co_CheckInLamp;
    private Collider[] colls;
    private int inDarkTime;
    private bool inPlayer;

    void Start()
    {
        inDarkTime = 0;
        inPlayer = false;
        playerLayer = GameData.PLAYER_LAYER_MASK;
    }

    private void OnTriggerEnter(Collider other)
    {
        //inPlayer�� �ڷ�ƾ �ߺ����� ����
        if (other.CompareTag("Player") && !inPlayer)
        {
            inDarkTime = 0;
            Co_CheckInLamp = StartCoroutine(CheckInLamp());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && Co_CheckInLamp != null)
        {
            StopCoroutine(Co_CheckInLamp);
            inPlayer = false;
        }
    }

    public IEnumerator CheckInLamp()
    {
        inPlayer = true;
        TutorialManager.instance.ShowTutoWindow
            ("�׽����� ������ �����Ͽ����ϴ�.\n��� ���� �������.");

        while (true)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lampLight.enabled)
                {
                    colls = Physics.OverlapSphere(lamp.transform.position, 3f, playerLayer);
                    Debug.Log("Length: " + colls.Length);
                    if (colls.Length > 0)
                    {
                        inDarkTime = -1;
                        break;
                    }
                }
            }

            inDarkTime++;
            //Debug.Log("��Ҽӿ� �ִ� �ð�:" + inDarkTime);
            if (CheckOverTime()) break;
            yield return WaitTimeManager.WaitForSeconds(1);
        }
    }

    public bool CheckOverTime()
    {
        if(inDarkTime > 10)
        {
            shadowGhost.StartKillPlayer();
            return true;
        }
        return false;
    }


}
