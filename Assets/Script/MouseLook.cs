using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;   // sensitifitas mouse

    public Transform playerBody;

    float xRoration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // menghilangkan kursor agar tidak terlihat di layar
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;    // Input gerakan sumbu X (side-to-side) pada setiap frame
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;    // Input gerakan sumbu Y (up-down) pada setiap frame

        xRoration -= mouseY;    // inisialisasi gerakan sumbu y (up-down)
        xRoration = Mathf.Clamp(xRoration, -90f, 90f);  // gerakkan kamera up-down dibatasi hanya 90 derajat ke atas dan bawah (biar tidak overrotate ke arah belakang)

        transform.localRotation = Quaternion.Euler(xRoration, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // menggerakkan kamera berdasarkan sumbu x (side-to-side)
    }
}
