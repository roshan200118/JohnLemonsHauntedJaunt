using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    //If player collides with collider, then player is in range
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    //If player doesn't collide with collider, then player is not in range
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        //If player is in range
        if (m_IsPlayerInRange)
        {
            //Calaculate direction 
            Vector3 direction = player.position - transform.position + Vector3.up;

            //Create ray 
            Ray ray = new Ray(transform.position, direction);

            //Out parameter
            RaycastHit raycastHit;

            //If the raycast hits player, then player is caught
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}