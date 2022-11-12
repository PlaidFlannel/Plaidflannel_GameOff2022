using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSmoothTime;
    float currentAngle;
    float currentAngleVelocity;
    Camera cam;


    [Header("Gravity")]
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float gravityMultiplier = 2;
    //[SerializeField] float groundedGravity = -0.5f;
    [SerializeField] float jumpHeight = 3f;
    private float velocityY;

    [SerializeField] AudioClip coinPickup;

    AudioSource audioSource;    
    Bank bank;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bank = FindObjectOfType<Bank>();
    }
    void Update()
    {
        HandleMovement();
        HandleGravityandJump();


    }
    // Entire movement code encapsulated in a function
    // and calling it from Update
    private void HandleMovement()
    {
        //capturing Input from Player
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(rotatedMovement * speed * Time.deltaTime);
        }
    }
    void HandleGravityandJump()
    {

        //if (controller.isGrounded && velocityY < 0f) 
        //{ velocityY = groundedGravity; }

        //if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocityY = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        velocityY -= gravity * gravityMultiplier * Time.deltaTime;
        controller.Move(Vector3.up * velocityY * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinPickup);
            int depositValue = other.gameObject.GetComponent<Coin>().coinValue;
            Debug.Log("got coin" + depositValue);
            Destroy(other.gameObject);
            bank.Deposit(depositValue);
        }

    }
}