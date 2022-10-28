using UnityEngine;
using UnityEngine.VFX;

public class PlayerSmokeStep : MonoBehaviour
{
    private bool isCurrentlyWalking;
    private float lastWalkingStart;
    private VisualEffect visualEffect;

    public void UpdateWalkingDirection(Vector3 newDirection)
    {
        visualEffect.SetVector3("Walking Direction", newDirection);
    }

    public void UpdateWalkingState(bool isWalking)
    {
        if (isWalking)
            lastWalkingStart = Time.time;
        isCurrentlyWalking = isWalking;
    }

    private void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
    }

    private void Update()
    {
        if (isCurrentlyWalking) visualEffect.SetFloat("Walking Time", Time.time - lastWalkingStart);
    }
}
