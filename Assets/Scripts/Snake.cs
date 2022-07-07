using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private List<Transform> snakeSegmentList;
    public GameObject snakeSegmentPrefab;

    private Rigidbody2D snakeHeadRigidbody;
    private Vector2 direction;
    

    private void Awake()
    {
        snakeHeadRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        snakeSegmentList = new List<Transform>();
        snakeSegmentList.Add(transform);
        direction = Vector2.right;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector2.up;

        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector2.down;

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector2.left;

        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        for (int i = snakeSegmentList.Count - 1; i > 0; i--)
        {
            snakeSegmentList[i].position = snakeSegmentList[i - 1].position;
        }

        snakeHeadRigidbody.position = (new Vector2(
            snakeHeadRigidbody.position.x + direction.x,
            snakeHeadRigidbody.position.y + direction.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Food": Grow(); break;
            case "Obstacle": Reset(); break;
            default: break;
        }
    }

    private void Grow()
    {
        Transform snakeSegment = Instantiate(snakeSegmentPrefab).transform;
        snakeSegment.position = snakeSegmentList[snakeSegmentList.Count - 1].position;
        snakeSegmentList.Add(snakeSegment);
    }

    private void Reset()
    {
        for (int i = 1; i < snakeSegmentList.Count; i++)
        {
            Destroy(snakeSegmentList[i].gameObject);
        }

        snakeSegmentList.Clear();
        transform.position = Vector3.zero;
        snakeSegmentList.Add(transform);
    }
}
