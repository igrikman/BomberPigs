using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_Player : MonoBehaviour
{
    [SerializeField] private ControlType controlType;
    private AudioSource audioSource;
    private enum ControlType { PC, Android }
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bombPrefab;
    private bool bombActive = false;
    [SerializeField] private float HP = 10;
    [SerializeField] private Text hpText;
    private Material matBlink;
    private Material matDefault;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            spriteRenderer.material = matBlink;
            TakeDamege();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            spriteRenderer.material = matBlink;
            TakeDamege();
        }
    }
    private void TakeDamege()
    {
        HP -= 2;
        if (HP < 0)
        {
            HP = 0;
            Death();
        }
        else { Invoke("ResetMaterial", 0.2F); }
    }
    private void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }
    private void Death()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hpText.text = ((int)HP).ToString();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("Enemy_Blink", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
    }
    private void SpawnBomd()
    {
        if (bombActive == false)
        {
            Instantiate(bombPrefab, gameObject.transform.position, new Quaternion());
            bombActive = true;
        }
        else
        {
            Activebomb();
        }
    }
    private void Activebomb()
    {
        if (GameObject.FindGameObjectsWithTag("Bomb").Length == 0)
        {
            Debug.Log("Бомба не существует");
            bombActive = false;
            SpawnBomd();
        }
        else
        {
            Debug.Log("Бомба существует");
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
        spriteRenderer.flipX = direction.x < 0 ? true : false;
        UpdateHpText();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void UpdateHpText()
    {
        hpText.text = ((int)HP).ToString();
    }

}