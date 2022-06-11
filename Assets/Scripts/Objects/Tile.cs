using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    bool bouncing = false;
    bool bounceup = false;
    float bounceHeight = 0.1f;
    float moveSpeed = 0.25f;
    Vector2 origin;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = (int)(-100 * transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bouncing)
        {
            if (Vector2.Distance(transform.position, target) <= 0)
            {
                if (bounceup)
                {
                    target = origin;
                    bounceup = false;
                }
                else
                {
                    bouncing = false;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
        }
    }

    public void bounce()
    {
        Debug.Log("bouncing");
        if (!bouncing)
        {
            bouncing = true;
            bounceup = true;
            origin = transform.position;
            target = new Vector2(transform.position.x, transform.position.y + bounceHeight);
            Debug.Log(target);
        }
    }
}
