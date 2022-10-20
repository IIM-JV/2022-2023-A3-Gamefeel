using UnityEngine;

public abstract class Movement2D : MonoBehaviour
{
    protected float speed;

    public Vector2 direction { get; protected set; }

    public abstract void SetDirection(Vector2 newDirection);
}
