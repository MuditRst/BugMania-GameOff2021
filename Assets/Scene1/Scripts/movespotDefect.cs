using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movespotDefect : PatrolAi{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            movespot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}