using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2 rectangleSize = new Vector2(10f, 5f); 
    [SerializeField] float baseAimSpeed = 10f;
    [SerializeField] float turningSpeed = 5f;
    [SerializeField] float followingPlayerSpeed = 4f;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Aiming();
        }
        else
        {
            FollowPlayer(followingPlayerSpeed);
        }
    }

    private void Aiming()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        clickPosition.z = -10f;

        float distance = Vector2.Distance(player.position, clickPosition);
        float speedMultiplier = Mathf.Clamp01(distance / rectangleSize.x);

        Vector3 direction = (clickPosition - player.position).normalized;
        Vector3 newPosition = transform.position + direction * baseAimSpeed * speedMultiplier * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, player.position.x - rectangleSize.x / 2, player.position.x + rectangleSize.x / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, player.position.y - rectangleSize.y / 2, player.position.y + rectangleSize.y / 2);
        newPosition.z = -10f;

        transform.position = newPosition;
    }

    private void FollowPlayer(float speed = 2f)
    {
        if (transform.position != new Vector3(0,0,-10))
        {
            if (Mathf.Abs(transform.position.x) < 0.05f && Mathf.Abs(transform.position.y) < 0.05f)
            {
                transform.position = new Vector3(0, 0, -10);
            }
            else
            {
                Vector3 targetPosition = new Vector3(player.position.x, player.position.y, -10);
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }
}
