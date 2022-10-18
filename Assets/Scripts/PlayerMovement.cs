using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : Movement2DRigidbody
{
    public float maxSpeed;
    public float maxLerpTime;

    private Vector2 lastRealDirection;
    private TweenerCore<float, float, FloatOptions> speedTween;

    public override void SetDirection(Vector2 newDirection)
    {
        DOTween.Kill(this);
        var directionMagnitude = newDirection.magnitude;
        var lerpTime = maxLerpTime * math.abs(lastRealDirection.magnitude - directionMagnitude);
        var endValue = maxSpeed * directionMagnitude;
        DOTween.To(() => speed, newSpeed => speed = newSpeed, endValue, lerpTime);
        if (newDirection != Vector2.zero)
            direction = newDirection.normalized;
        lastRealDirection = newDirection;
    }
}
