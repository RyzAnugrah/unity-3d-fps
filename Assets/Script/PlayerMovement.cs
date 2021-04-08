using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  

    public float speed = 6f;    // set kecepatan normal
    public float sprintSpeed = 12f; // set kecepatan saat berlari
    public float walkSpeed = 6f;    // set kecepatan saat kembali normal
    public float gravity = -49.05f; // set gravity dibebaskan (-9.81 * 5)
    public float jumpHeight = 3f;   // set ketinggian lompat

    public Transform groundCheck;   
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;   // kecepatan dalam skala vektor
    bool isGrounded;    // cek apakah karakter menapak tanah

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // mengecek apakah pemain berdiri di atas bidang yang baru 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");  // input
        float z = Input.GetAxis("Vertical");    // input

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); // gerakan karakter dengan WASD (8 arah)

        if (Input.GetButtonDown("Jump") && isGrounded)  // jika tombol Space ditekan dan player menapak tanah
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);    // player akan melompat
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)  // jika tombol Shift ditekan atau ditahan dan player menapak tanah
            speed = sprintSpeed;    // player berlari
        else
            speed = walkSpeed;  // player berjalan normal

        velocity.y += gravity * Time.deltaTime; // mengatur airtime player agar lebih nyata

        controller.Move(velocity * Time.deltaTime); // agar player dapat bergerak
    }
}
