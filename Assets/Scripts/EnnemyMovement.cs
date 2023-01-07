using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int maxDistance = 2;
    private Vector2 startPosition;
    private Vector2 newPosition;

    private void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;

    }
    private void Update()
    {
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * moveSpeed));
        transform.position = newPosition;
    }
}
