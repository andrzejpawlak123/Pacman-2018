using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMovement : MonoBehaviour {

    
    //   public Transform[] waypoints;
    private Vector2 nextPosition = Vector2.zero;
    

   int cur = 0;
    int helpVariable = 0;
   // public float velocity = Random.Range(1, 2);
    private float velocity = 0.1F;

    private const int LEFT = 0;
    private const int RIGHT = 1;
    private const int UP = 2;
    private const int DOWN = 3;

    private Vector2 lastDirection;


    private bool afterFirstColision;

    // Use this for initialization
    void Start () {
        afterFirstColision = true;
       
    }

    // called in a fixed time intervals, physics stuff should be done here
    void FixedUpdate()
    {   
       
        moveToPosition(nextPosition);

        if (afterFirstColision) //afterFirstColision
        {
            nextPosition = GenerateRandomMove(nextPosition);
            if (helpVariable < 50)
            {
                afterFirstColision = false;
                helpVariable++;
            }
            else
            {
                afterFirstColision = true;
            }
        }
        else {
            if (!canMove(Vector2.up))
            {
                afterFirstColision = true;
            }
            else {
                nextPosition = (Vector2)transform.position + Vector2.up;
                lastDirection = Vector2.up;
            }
        }
        setDirectionForPlayerAnimation();
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        switch (co.name)
        {
            case "player":
                Destroy(co.gameObject);
                SceneManager.LoadScene("DecisionMaking"); 
                break;
            case "map":
                afterFirstColision = true;
                break;
          
        }
    }

    private void moveToPosition(Vector2 nextPiosition)
    {
        Vector2 p = Vector2.MoveTowards(transform.position, nextPosition, velocity);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }

    private void setDirectionForPlayerAnimation()
    {
        Vector2 direction = nextPosition - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("HorizontalDirection", direction.x);
        GetComponent<Animator>().SetFloat("VerticalDirection", direction.y);
    }

    private Vector2 GenerateRandomMove(Vector2 nextPosition)
    {

        if (canMove(lastDirection)) {
            return nextPosition = (Vector2)transform.position + lastDirection;
        }

        int direction = Random.Range(0, 4); // creates a number between 0 and 4 ()
        switch (direction)
        {
            case LEFT:
                if (canMove(-Vector2.right)) {
                    lastDirection = -Vector2.right;
                    nextPosition = (Vector2)transform.position - Vector2.right;
                }
                break;
            case RIGHT:
                if (canMove(Vector2.right))
                {
                    lastDirection = Vector2.right;
                    nextPosition = (Vector2)transform.position + Vector2.right;
                }
                break;
            case UP:
                if (canMove(Vector2.up))
                {
                    lastDirection = Vector2.up;
                    nextPosition = (Vector2)transform.position + Vector2.up;
                }
                break;
            case DOWN:
                if (canMove(-Vector2.up))
                {
                    lastDirection = -Vector2.up;
                    nextPosition = (Vector2)transform.position - Vector2.up;
                }
                break;
        }


        return nextPosition;
    }

    private bool canMove(Vector2 direction)
    {
        Vector2 position = transform.position;
        RaycastHit2D raycastHit = Physics2D.Linecast(position + direction, position);

        return (raycastHit.collider == GetComponent<Collider2D>());
    }

}

