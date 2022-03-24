using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
