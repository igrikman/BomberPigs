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
    [SerializeField] private GameObject bombPrefab;
    private bool bombActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SpawnBomd()
    {
        if (bombActive == false)
        {
            Instantiate(bombPrefab, gameObject.transform.position, new Quaternion());
            bombActive = true;
        }
    }
    private void Update()
    {
        if (controlType == ControlType.PC)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        if (controlType == ControlType.PC)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SpawnBomd();
            }
        }
        else if (controlType == ControlType.Android)
        {
            direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
