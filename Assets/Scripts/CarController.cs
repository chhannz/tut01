using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class CarController : MonoBehaviour
{
    [SerializeField] private CarData carData;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Controller control;
    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        control = new Controller();
        sr.sprite = carData.CarSprite;
    }

    private void OnEnable()
    {
        control.Enable();
        control.CarInput.Control.performed += MovePlayer;
        control.CarInput.Control.canceled += MovePlayer;
    }
    
    private void OnDisable()
    {
        control.Disable();
        control.CarInput.Control.performed -= MovePlayer;
        control.CarInput.Control.canceled -= MovePlayer;
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation - carData.TurnSpeed * moveInput.x * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + (Vector2)transform.up * moveInput.y * carData.MoveSpeed * Time.fixedDeltaTime);
    }
}
