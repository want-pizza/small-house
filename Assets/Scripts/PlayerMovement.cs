using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float defSlowdown = 1f;
    private float currentSlowdown;
    private float currentSpeed;

    private void Start()
    {
        currentSlowdown = defSlowdown;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += CalculateMovementDirection() * currentSpeed / currentSlowdown * Time.deltaTime;
    }

    private Vector3 CalculateMovementDirection()
    {
        Vector3 rawInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return rawInput.normalized;
    }
}
