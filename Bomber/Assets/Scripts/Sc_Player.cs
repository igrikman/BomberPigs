using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Player : MonoBehaviour
{
    [SerializeField] private ControlType controlType;
    private enum ControlType { PC, Android }
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (controlType == ControlType.PC)
        {
            //direction.x = Input.GetAxisRaw("Horizontal");
            //direction.y = Input.GetAxisRaw("Vertical");
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if(controlType == ControlType.Android)
        {
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
