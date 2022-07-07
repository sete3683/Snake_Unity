using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D area;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        (int x, int y) newFoodPosition =
            ((int)Random.Range(area.bounds.min.x, area.bounds.max.x), 
             (int)Random.Range(area.bounds.min.y, area.bounds.max.y));

        transform.position = new Vector3(newFoodPosition.x, newFoodPosition.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            RandomizePosition();
    }
}
