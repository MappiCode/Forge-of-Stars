using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    private void OnMovement(InputValue moveInput)
    {
        Vector2 value = moveInput.Get<Vector2>();
        value.y = value.y / 2;
        rb.velocity = value * moveSpeed * Time.fixedDeltaTime;
    }
}
