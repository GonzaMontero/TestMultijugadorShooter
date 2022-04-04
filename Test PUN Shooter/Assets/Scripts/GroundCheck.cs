using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.gameObject)
        {
            return;
        }
        player.SetGroundedState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == player.gameObject)
        {
            return;
        }
        player.SetGroundedState(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == player.gameObject)
        {
            return;
        }
        player.SetGroundedState(true);
    }
}
