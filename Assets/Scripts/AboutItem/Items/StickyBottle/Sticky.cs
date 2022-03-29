using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Vector3 setPos = transform.position;
        //���� �ٴ°� 0.1 ���߿� �������
        setPos.y = 0.1f;
        transform.position = setPos;

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameData.GHOST_TAG))
        {
            other.GetComponent<Ghost>().GetSlow();
        }
    }

}
