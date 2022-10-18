using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimatorManager : MonoBehaviour
{
    protected Animator animator;
    public abstract void UpdateAnimations(Vector2 newDirection);

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
