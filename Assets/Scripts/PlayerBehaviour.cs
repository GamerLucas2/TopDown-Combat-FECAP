using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private InputManager inputManager;
    
    private Rigidbody2D rigidBody;
    
    [SerializeField] private float moveSpeed;
    
    private void Awake()
    {
        inputManager = new InputManager();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        inputManager.DisableInput();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = inputManager.InputDirection * moveSpeed; 
    }
}
