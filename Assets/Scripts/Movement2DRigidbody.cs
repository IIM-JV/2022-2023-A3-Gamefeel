using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Movement2DRigidbody : Movement2D
{
    private Rigidbody2D myRB2D;

    private void Awake()
    {
        myRB2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRB2D.velocity = speed * direction;
    }
}
