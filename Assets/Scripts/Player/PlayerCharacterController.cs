using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
        smokeStep.UpdateWalkingState(context.performed);
    }

    public void OnToggle(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        var volume = FindObjectOfType<Volume>();
        if (!volume.profile.TryGet(out Vignette vignette))
            return;

        var target = 0f;
        if (vignette.intensity == 0)
            target = 0.7f;
        DOTween.To(() => vignette.intensity.value, newIntensity => vignette.intensity.value = newIntensity, target,
            0.5f);
    }

    private void Awake()
    {
        smokeStep = GetComponent<PlayerSmokeStep>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerMovement = GetComponent<Movement2D>();
    }
}
