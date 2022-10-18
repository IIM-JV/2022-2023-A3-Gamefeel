using DG.Tweening;
using UnityEngine;

public class DoTweenExample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.DOMoveZ(25, 10).SetEase(EaseInElastic);
    }

    private float EaseInElastic(float time, float duration, float overshootOrAmplitude, float period)
    {
        const float newPeriod = 2 * Mathf.PI / 3;
        if (time <= 0) return 0;
        if (time >= 1) return 1;

        return -Mathf.Pow(2, 10 * time - 10) * Mathf.Sin((time * 10 - 10.75f) * newPeriod);

        // Modern version
        /*
        return time switch
        {
            <=0 => 0,
            >=1 => 1,
            _ => -Mathf.Pow(2, 10 * time - 10) * Mathf.Sin((time * 10 - 10.75f) * period)
        };
        */
    }
}
