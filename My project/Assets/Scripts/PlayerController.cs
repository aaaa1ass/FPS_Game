using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD

=======
>>>>>>> 20a472256c66dc47b28ff1191b27c2f72f0cb032
public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float mouseSensitivity;
    [SerializeField] public float RotationLimit = 40;
    [SerializeField] public float currRotationX;
    Camera MainCamera;
    Rigidbody rid;

    void Start()
    {
        rid = GetComponent<Rigidbody>();
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();
        CameraRotation();
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * moveZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        rid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    private void PlayerRotation()
    {
        float rotationY = Input.GetAxisRaw("Mouse X");
        Vector3 playerRotationY = new Vector3(0f,rotationY, 0f) * mouseSensitivity;
        rid.MoveRotation(rid.rotation * Quaternion.Euler(playerRotationY));
    }

    private void CameraRotation()
    {
        float rotationX = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = rotationX * mouseSensitivity;
        currRotationX -= cameraRotationX;
        currRotationX = Mathf.Clamp(currRotationX, -RotationLimit, RotationLimit);
        MainCamera.transform.localEulerAngles = new Vector3(currRotationX, 0f, 0f);
    }
}
