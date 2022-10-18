using UnityEngine;

public class PlayerAnimatorManager : AnimatorManager
{
    private static readonly int Direction = Animator.StringToHash("Direction");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    public override void UpdateAnimations(Vector2 newDirection)
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
