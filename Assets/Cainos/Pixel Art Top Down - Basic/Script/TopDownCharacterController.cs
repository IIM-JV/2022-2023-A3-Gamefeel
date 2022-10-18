using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;

    private static readonly int Direction = Animator.StringToHash("Direction");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private Animator animator;
    private Vector2 direction;
    private Rigidbody2D myRB2D;

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        UpdateAnimations(direction);
        Lol();
    }

    private void Lol()
    {
        Debug.Log("merdat");
    }

    private void Awake()
    {
        myRB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        myRB2D.velocity = speed * direction;
    }

    private void UpdateAnimations(Vector2 newDirection)
    {
        var isMoving = newDirection.magnitude > 0;
        animator.SetBool(IsMoving, isMoving);
        if (!isMoving)
            return;

        switch (newDirection.x)
        {
            case < 0:
                animator.SetInteger(Direction, 3);
                break;
            case > 0:
                animator.SetInteger(Direction, 2);
                break;
        }

        switch (newDirection.y)
        {
            case < 0:
                animator.SetInteger(Direction, 0);
                break;
            case > 0:
                animator.SetInteger(Direction, 1);
                break;
        }
    }
}
