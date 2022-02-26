using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman_Used : MonoBehaviour
{
    public GameObject explosionParticle;
    public AudioClip boomSound;

    private RaycastHit hit;
    private Collider nowGhost;
    private IEnumerator betweenCheckerEnumerator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            nowGhost = other; 
            betweenCheckerEnumerator = CheckBetweenObstacle();
            StartCoroutine(betweenCheckerEnumerator);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            StopCoroutine(betweenCheckerEnumerator);
        }
    }
    
    //��Ʈ�� ���̿� ��ֹ� �ִ��� üũ
    private IEnumerator CheckBetweenObstacle()
    {
        while (true)
        {
            if (CanSeeGhost())
            {
                Boom();
                break;
            }
            yield return WaitTimeManager.WaitForFixedUpdate();
        }
    }

    private void Boom()
    {
        nowGhost.GetComponent<Ghost>().Stuned(2);
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        SFXPlayer.instance.Play(boomSound);
        Destroy(gameObject);
    }

    private bool CanSeeGhost()
    {
        //�ͽ��� ���߿� ���־ up�� ������
        Vector3 dir = nowGhost.transform.position + Vector3.up * 0.1f - transform.position;
        Physics.Raycast(transform.position + Vector3.up * 0.1f, dir, out hit);

        return hit.collider.CompareTag("Ghost");
    }
}
