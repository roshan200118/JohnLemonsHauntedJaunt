using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //Reference player and corresponding teleport pad
    public Transform player;
    public Transform otherTeleportPad;

    //Checks if player is in range
    bool m_IsPlayerInRange;

    void Update()
    {
        //If player is in range, then move position of player to position of other teleport pad
        if (m_IsPlayerInRange)
        {
            player.transform.position = otherTeleportPad.transform.position;
        }
    }

    //If the collision is with player, then the player is in range
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    //When player exits teleport pad, the player is no longer in range

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
