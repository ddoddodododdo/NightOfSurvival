using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talisman_Used : MonoBehaviour
{
    public GameObject explosionParticle;
    public AudioClip boomSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            other.GetComponent<Ghost>().Stuned(2);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            SFXPlayer.instance.Play(boomSound);
            Destroy(gameObject);
        }
    }

}
