using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sink"))
        {
            player.GetComponent<Collider>().isTrigger = true;
        }
    }
}
