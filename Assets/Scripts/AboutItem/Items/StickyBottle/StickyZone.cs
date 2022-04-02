using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Vector3 setPos = transform.position;
        //���� �ٴ°� 0.1 ���߿� �������
        setPos.y = 0.1f;
        transform.position = setPos;

        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameData.GHOST_TAG))
        {
            Debug.Log("��Ʈ ����");
            other.GetComponent<Ghost>().SetSlow(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameData.GHOST_TAG))
        {
            Debug.Log("��Ʈ �ƿ�");
            other.GetComponent<Ghost>().SetSlow(false);
        }
    }

}
