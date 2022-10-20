using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    private AnimatorManager playerAnimatorManager;
    private Movement2D playerMovement;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
            return;

        var direction = context.ReadValue<Vector2>();
        playerAnimatorManager.UpdateAnimations(direction);
        playerMovement.SetDirection(direction);
    }

    private void Awake()
    {
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerMovement = GetComponent<Movement2D>();
    }
}
