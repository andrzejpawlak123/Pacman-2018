using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private readonly float velocity = 0.1F;
    private Vector2 nextPosition = Vector2.zero;

    // Use this for initialization
    void Start () {
		
	}

    // called in a fixed time intervals, physics stuff should be done here
    void FixedUpdate()
    {
        nextPosition = handleKeyboardInput(nextPosition);
        moveToPosition();
        setDirectionForPlayerAnimation();
    }
    private void moveToPosition() {
        Vector2 p = Vector2.MoveTowards(transform.position, nextPosition, velocity);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }

    private void setDirectionForPlayerAnimation() {
        Vector2 direction = nextPosition - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("HorizontalDirection", direction.x);
        GetComponent<Animator>().SetFloat("VerticalDirection", direction.y);
    }

    private Vector2 handleKeyboardInput(Vector2 nextPosition) {
        if (Input.GetKey(KeyCode.UpArrow) && canMove(Vector2.up))
            nextPosition = (Vector2)transform.position + Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow) && canMove(Vector2.right))
            nextPosition = (Vector2)transform.position + Vector2.right;
        if (Input.GetKey(KeyCode.DownArrow) && canMove(-Vector2.up))
            nextPosition = (Vector2)transform.position - Vector2.up;
        if (Input.GetKey(KeyCode.LeftArrow) && canMove(-Vector2.right))
            nextPosition = (Vector2)transform.position - Vector2.right;

        return nextPosition;
    }

    private bool canMove(Vector2 direction)
    {
        Vector2 position = transform.position;
        RaycastHit2D raycastHit = Physics2D.Linecast(position + direction, position);
        return (raycastHit.collider == GetComponent<Collider2D>());
    }
}
