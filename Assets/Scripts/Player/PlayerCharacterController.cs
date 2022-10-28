using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    private AnimatorManager playerAnimatorManager;
    private Movement2D playerMovement;
    private PlayerSmokeStep smokeStep;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
            return;

        var direction = context.ReadValue<Vector2>();
        playerAnimatorManager.UpdateAnimations(direction);
        playerMovement.SetDirection(direction);
        smokeStep.UpdateWalkingDirection(direction);
        smokeStep.UpdateWalkingState(context.performed);
    }

    private void Awake()
    {
        smokeStep = GetComponent<PlayerSmokeStep>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerMovement = GetComponent<Movement2D>();
    }
}
