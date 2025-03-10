using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockRandSpawn : MonoBehaviour
{
    public GameObject[] Rocks;
    private PolygonCollider2D collider;
    public LayerMask obstacleLayer;


    public void rockSpawn() 
    {
        Bounds colliderBounds = collider.bounds;

        Vector2 randomPoint;
        bool isInsideCollider = false;

        do 
        {
            randomPoint = new Vector2(
                Random.Range(colliderBounds.min.x, colliderBounds.max.x),
                Random.Range(colliderBounds.min.y, colliderBounds.max.y)
            );

            isInsideCollider = collider.OverlapPoint(randomPoint);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPoint, 0.6f, obstacleLayer);
            if (colliders.Length > 0) 
            {
                isInsideCollider = true;
            }
        } while (!isInsideCollider);

        int randomIndex = Random.Range(0, Rocks.Length);
        Instantiate(Rocks[randomIndex], randomPoint, Quaternion.identity);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();

        for (int i = 0; i < 60; i++) 
        {
            rockSpawn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
