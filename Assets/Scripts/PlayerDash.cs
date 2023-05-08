using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float dashSpeed = 5;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] float dashingTime = 0.2f;
    private bool isDashing = false;
    private bool canDash = true;
    public bool IsDashing => isDashing;
    private Animator playerAnimator;
    private Rigidbody rb;
    private PlayerController playerController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        playerAnimator = GetComponent<Animator>();
    }


    private void OnDash()
    {
        StartDashing();
    }


    private void StartDashing()
    {
        if (!canDash) return;
        StartCoroutine(Dash());
    }


    IEnumerator Dash()
    {
        isDashing = true;
        playerAnimator.SetBool("isDashing", isDashing);
        canDash = false;
        rb.velocity *= dashSpeed;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        playerAnimator.SetBool("isDashing", isDashing);

        float timer = 0f;
        while (timer < dashCooldown)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        canDash = true;
    }
}
