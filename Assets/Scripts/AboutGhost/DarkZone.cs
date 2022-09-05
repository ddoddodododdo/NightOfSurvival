using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZone : MonoBehaviour
{
    public Lamp[] lamps;
    public LayerMask playerLayer;
    public ShadowGhost shadowGhost;
    public AudioClip heartBeatSound;

    private AudioSource heartBeatAudio;
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
            heartBeatAudio.Stop();
            inPlayer = false;
        }
    }

    public IEnumerator CheckInLamp()
    {
        inPlayer = true;
        TutorialManager.instance.ShowTutoWindow
            ("�׽����� ������ �����Ͽ����ϴ�.\n��� ���� �������.");

        heartBeatAudio = SFXPlayer.instance.Play(heartBeatSound);

        while (true)
        {
            foreach (Lamp lamp in lamps)
            {
                if (lamp.lampLight.enabled)
                {
                    colls = Physics.OverlapSphere(lamp.transform.position, 3f, playerLayer);
                    //Debug.Log("Length: " + colls.Length);
                    if (colls.Length > 0)
                    {
                        inDarkTime = -1;
                        break;
                    }
                }
            }

            inDarkTime++;
            SetHeartBeatSound();
            //Debug.Log("��Ҽӿ� �ִ� �ð�:" + inDarkTime);
            if (CheckOverTime()) break;
            yield return WaitTimeManager.WaitForSeconds(1);
        }
    }

    private bool CheckOverTime()
    {
        if(inDarkTime > 14)
        {
            shadowGhost.StartKillPlayer();
            return true;
        }
        return false;
    }

    private void SetHeartBeatSound()
    {
        if (inDarkTime > 0)
        {
            heartBeatAudio ??= SFXPlayer.instance.Play(heartBeatSound);
        }
        else
        {
            heartBeatAudio?.Stop();
            heartBeatAudio = null;
        }
    }

}
