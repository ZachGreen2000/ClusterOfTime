using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header ("movement")]
    public float currentSpeed = 5;
    public float speed = 5f; // Adjust the speed as needed
    public float stamina = 20;
    public float maxStamina = 20;
    public float minStamina = 3;
    public bool staminaUse = false;
    public Animator animator;
    [Header ("mining")]
    public LayerMask ZGbreakableLayer; // Set this in the Inspector to the layer containing breakable objects
    public float ZGbreakRange = 2f; // Adjust the range of the raycast for breaking
    public float sprintSpeed = 10f; //sprint speed
    
    [Header("combat")]
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;

    [Header("NPC")]
    public LayerMask JFnpcLayer;
    public NPCManager npcManager;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (stamina <= maxStamina && staminaUse == false)
        {
            stamina++;
        }else if (stamina >= minStamina && staminaUse == true)
        {
            stamina--;
        }

        ZGMoveCharacter();

        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            ZGBreakObject();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void ZGMoveCharacter()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 5)
        {
            currentSpeed = sprintSpeed;
            staminaUse = true;
            animator.SetBool("sprint", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = speed;
            staminaUse = false;
            animator.SetBool("sprint", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * currentSpeed * Time.deltaTime;
            animator.SetBool("back", true);
        }else
        {
            animator.SetBool("back", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * currentSpeed * Time.deltaTime;
            animator.SetBool("forward", true);
        }else
        {
            animator.SetBool("forward", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * currentSpeed * Time.deltaTime;
            animator.SetBool("left", true);
        }else
        {
            animator.SetBool("left", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * currentSpeed * Time.deltaTime;
            animator.SetBool("right", true);
        }else
        {
            animator.SetBool("right", false);
        }
    }

    void ZGBreakObject()
    {
        // Get Mouse Hit
        RaycastHit2D hit = GetMouseRaycastHit();

        // Check if the ray hits a breakable object
        if (hit.collider != null)
        {
            // Destroy or disable the object as needed
            Destroy(hit.collider.gameObject);
        }
    }

    void Interact()
    {
        // Get Mouse Hit
        RaycastHit2D hit = GetMouseRaycastHit();

        // Check if the ray hits a breakable object
        if (hit.collider != null
            && hit.collider.gameObject.CompareTag("Anubis"))
        {
            npcManager.AnubisScenes();
        }
        if (hit.collider != null
           && hit.collider.gameObject.CompareTag("Peter"))
        {
            npcManager.PeterScenes();
        }
        if (hit.collider != null
           && hit.collider.gameObject.CompareTag("Gary"))
        {
            npcManager.GaryScenes();
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // Gets raycast of the mouse position
    RaycastHit2D GetMouseRaycastHit()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Raycast from the player to the mouse position
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (mousePos - transform.position).normalized, ZGbreakRange, JFnpcLayer);

        return hit;
    }
}