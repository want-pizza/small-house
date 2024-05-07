using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 2f;
    [SerializeField] float defSlowdown = 1f;
    private float currentSlowdown;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = maxSpeed;
        currentSlowdown = defSlowdown;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * maxSpeed / currentSlowdown, Input.GetAxis("Vertical") * maxSpeed / currentSlowdown, 0) * Time.deltaTime;
    }
}
