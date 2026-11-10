using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private InputManager inputManager;
    
    private Rigidbody2D rigidBody;
    private PlayerAnimController playerAnim;
    private SpriteRenderer playerSprite;
    
    [SerializeField] private float moveSpeed;

    [Header("Attack Params")]
    [SerializeField] private Vector2 attackArea;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask enemyLayer;
    private Collider2D enemyRef;
    
    private void Awake()
    {
        inputManager = new InputManager();
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimController>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        inputManager.DisableInput();
    }

    private void Update()
    {
        if (inputManager.IsAttackPressed == true)
        {
            print("Atack pressed");
            PlayerAttack();
        }
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = inputManager.InputDirection * moveSpeed;
        
        UpdateWalkAnim();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attackArea);
    }

    private void PlayerAttack()
    {
        playerAnim.SetAttack();
        print("Playing: Attack Anim");
        
        enemyRef = Physics2D.OverlapBox(attackPos.position, attackArea,0, enemyLayer);
        if (enemyRef != null)
        { 
            Destroy(enemyRef.gameObject); 
            print("Enemy name: " + enemyRef.gameObject.name);
        }
    }

    private void UpdateWalkAnim()
    {
        playerAnim.SetIsMoving(inputManager.InputDirection != Vector2.zero);
        
        if (inputManager.InputDirection.x < 0)
            playerSprite.flipX = true;
        if (inputManager.InputDirection.x > 0)
            playerSprite.flipX = false;
        
        if (inputManager.InputDirection != Vector2.zero)
            print("Playing: Walk Anim");
        else
            print("Playing: Idle Anim");
    }
}
