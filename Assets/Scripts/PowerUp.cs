using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1f;
    public GameObject pickupEffect;
    public float duration;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine  (Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
    //    Debug.Log("Power up picked up");
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale /= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.transform.localScale *= multiplier;


        Destroy(gameObject);
    }
}
