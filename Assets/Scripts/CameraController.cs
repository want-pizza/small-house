using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float aimDistanceMult = 2f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Aiming();
        }
        else
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z) + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    private void Aiming()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Translate(Vector3.right * aimDistanceMult * mouseX * Time.deltaTime);
        transform.Translate(Vector3.up * aimDistanceMult * mouseY * Time.deltaTime);
    }
}
