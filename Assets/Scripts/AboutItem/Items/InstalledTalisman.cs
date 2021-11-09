using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstalledTalisman : MonoBehaviour
{
    public GameObject explosionParticle;
    

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            Debug.Log("��Ʈ�±�");
            other.GetComponent<Ghost>().Stuned(3);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
