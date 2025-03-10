using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float minDistance = 4f;

    void Update()
    {
        if (player != null)
        {
            Vector3 offset = player.position - transform.position;
            float currentDistance = offset.magnitude;

            if(currentDistance < minDistance)
            {
                Vector3 newPosition = player.position - offset.normalized * minDistance;
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * speed);
            }
        }

    }
}
