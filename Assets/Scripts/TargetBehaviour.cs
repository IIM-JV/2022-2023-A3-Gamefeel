#region

using DG.Tweening;
using UnityEngine;

#endregion

public class TargetBehaviour : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveZ(5, 2);
    }
}