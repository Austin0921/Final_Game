using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
 private CustomInput input=null;
 private Vector2 moveVec = Vector2.zero;
 private Rigidbody2D rb = null;
 private float movementspeed = 5f;
 private Animator animator;
 private GameObject GameMenu;


    //public void Start()
    //{
    //    if (panel != null)
    //    {
    //        panel.SetActive(false); // For example, you can deactivate the panel at the start.
    //    }
    //}
    private void Awake()
    {
       
        input = new CustomInput(); 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled ;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }
    private void FixedUpdate()
    {
        rb.velocity = moveVec * movementspeed;

    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVec = value.ReadValue<Vector2>();

        if (moveVec.x != 0 || moveVec.y != 0)
        {
            animator.SetFloat("X", moveVec.x);
            animator.SetFloat("Y", moveVec.y);

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVec = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "House")
        {
            GameMenu.SetActive(true);
        }
    }

}
