using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;
    // ini yg diatas masih yang sebelumnya


    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotationSpeed = 500f;

    Quaternion targetRotation;

    Animator animator;


    camera cameraController;

    CharacterController characterController;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<camera>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Abs(h) + Mathf.Abs(v);

        var moveInput = (new Vector3(h, 0, v)).normalized;

        var moveDir = cameraController.PlanarRotation * moveInput;

        if (moveAmount > 0)
        {
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("jog");
            playerAnim.ResetTrigger("idle");

            //steps1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("jog");
            playerAnim.SetTrigger("idle");

            //steps1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("jog backward");
            playerAnim.ResetTrigger("idle");
            //steps1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("jog backward");
            playerAnim.SetTrigger("idle");
            //steps1.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0)) // 0 adalah tombol kiri mouse
        {
            playerAnim.SetTrigger("throw");
            playerAnim.ResetTrigger("idle");

            // Tambahkan logika melempar objek di sini, jika diperlukan.
        }

        if (Input.GetKeyDown(KeyCode.Space)) // 0 adalah tombol kiri mouse
        {
            playerAnim.ResetTrigger("idle");
            playerAnim.SetTrigger("jumping");
            // Tambahkan logika melempar objek di sini, jika diperlukan.
        }

        if (Input.GetKey(KeyCode.A))
        {
           // playerAnim.SetTrigger("jog");
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
          //  playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetTrigger("jog");
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
            playerAnim.ResetTrigger("idle");
        }

    }
}
