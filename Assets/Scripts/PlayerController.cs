using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public enum PlayerState
{
    Idling,
    Running,
    Dashing
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera currentCamera;
    [SerializeField] float speed = 5f;
    private Vector3 mousePos;
    public Vector2 rawInput;
    private Rigidbody rb;
    private Animator playerAnimator;
    private WeaponController weaponController;
    private PlayerDash playerDash;
    private PlayerState currentPlayerState = PlayerState.Idling;


    private void Awake()
    {
        weaponController = GetComponentInChildren<WeaponController>();
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerDash = GetComponent<PlayerDash>();
    }


    private void Update()
    {
        ChangeStates();
        RotateGun();
        weaponController.GunController(gameObject);


        switch (currentPlayerState)
        {
            case PlayerState.Idling:
                playerAnimator.SetBool("isIdling", true);
                playerAnimator.SetBool("isRunning", false);
                break;

            case PlayerState.Running:
                playerAnimator.SetBool("isIdling", false);
                playerAnimator.SetBool("isRunning", true);
                break;

        }
    }


    private void FixedUpdate()
    {

        Movement();
    }


    private void OnMovement(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void Movement()
    {
        if (playerDash.IsDashing) return;
        rb.velocity = new Vector3(rawInput.x, 0, rawInput.y) * speed;


        playerAnimator.SetFloat("xDirection", weaponController.direction.x);
        playerAnimator.SetFloat("zDirection", weaponController.direction.z);
    }



    private void ChangeStates()
    {
        if (rb.velocity != Vector3.zero)
        {
            currentPlayerState = PlayerState.Running;
        }
        else
        {
            currentPlayerState = PlayerState.Idling;
        }
    }


    private void RotateGun()
    {
        mousePos = Input.mousePosition;
        mousePos = currentCamera.ScreenToWorldPoint(mousePos);
        mousePos.y = 1.8f;
        weaponController.GunPointer = new Vector3(mousePos.x, mousePos.y, mousePos.z + 10);
    }

}
