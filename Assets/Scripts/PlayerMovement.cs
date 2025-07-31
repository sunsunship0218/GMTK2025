using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movespeed = 5f;
    float horizontalMove;
    float verticalMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontalMove * movespeed, verticalMove *movespeed);
    }
    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        horizontalMove = input.x;
        verticalMove = input.y;
        
    }
 
}
