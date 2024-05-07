using System;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float followSpeed = 2f;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float aimDistanceMult = 2f;
    [SerializeField] float aimSpeed = 0.01f;
    [SerializeField] float maxDistanceFromPlayer = 5f;
    private bool returning = false;

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
        else FollowPlayer();
    }

    private void Aiming()
    {
        if (returning) 
        {
            FollowPlayer(0.3f);
            return;
        }

        Vector3 mousePos = Input.mousePosition; 

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);

        float screenEdgeDistance = 1f; 

        Vector3 direction = (targetPos - transform.position).normalized;

        Vector3 newPosition = transform.position + direction * Mathf.Min((Camera.main.orthographicSize * Camera.main.aspect) - screenEdgeDistance,
            (targetPos - transform.position).magnitude);
        newPosition.z = -10;

        float distanceFromPlayer = Vector3.Distance(transform.position, new Vector3(player.position.x, player.position.y, -10));
        if (distanceFromPlayer < maxDistanceFromPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, aimSpeed * Time.deltaTime);
        }
        else 
        { 
            returning = true;
            StartCoroutine(SetReturningFalse(1f)); 
        }
    }

    IEnumerator SetReturningFalse(float time)
    {
        yield return new WaitForSeconds(time);
        returning = false;
    }

    private void FollowPlayer(float speed = 2f)
    {
        if (transform.position != new Vector3(player.position.x, player.position.y, -10))
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, 0) + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

}
