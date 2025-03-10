using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIPaths : MonoBehaviour
{
    public GameObject anubis;
    public GameObject cade;
    public GameObject sabella;
    public List<GameObject> waypointsA;
    public List<GameObject> waypointsB;
    public List<GameObject> waypointsC;
    private float speed = 5;
    int indexA = 0;
    int indexB = 0;
    int indexC = 0;
    public GameManager gameManager;

    void anubisMovement()
    {
        if (gameManager.monday == true)
        {
            Vector3 destination = waypointsA[indexA].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            anubis.transform.position = newPos;
            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0)
            {
                indexA++;
            }
        }
        if (gameManager.tuesday == true)
        {
            Vector3 destination = waypointsB[indexB].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            anubis.transform.position = newPos;
            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0)
            {
                indexB++;
            }
        }
        if (gameManager.wednesday == true)
        {
            Vector3 destination = waypointsC[indexC].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            anubis.transform.position = newPos;
            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0)
            {
                indexC++;
            }
        }

    }

    void cadeMovement()
    {
        Vector3 destination = waypointsB[indexB].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        cade.transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0)
        {
            indexB++;
        }

    }

    void sabellaMovement()
    {
        Vector3 destination = waypointsC[indexC].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        sabella.transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0)
        {
            indexC++;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anubisMovement();
        cadeMovement();
        sabellaMovement();
    }
}
