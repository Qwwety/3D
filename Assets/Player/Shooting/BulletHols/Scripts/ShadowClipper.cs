using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClipper : MonoBehaviour
{
    private Projector shadowProjector;
    public float shadowDistanceToletance = 0.5f;

    private float origNearClipPlane;
    private float origFarClipPlane;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        shadowProjector = GetComponent<Projector>();
        if (!shadowProjector) shadowProjector = transform.GetComponentInChildren<Projector>();
        origNearClipPlane = shadowProjector.nearClipPlane;
        origFarClipPlane = shadowProjector.farClipPlane;
        Late();
    }

    private void Late()
    {
        Ray ray = new Ray(
            shadowProjector.transform.position
                + shadowProjector.transform.forward.normalized
                * origNearClipPlane,
            shadowProjector.transform.forward
        );
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, origFarClipPlane - origNearClipPlane, -shadowProjector.ignoreLayers))
        {
            var dist = hit.distance + origNearClipPlane;
            shadowProjector.nearClipPlane = Mathf.Max(dist - shadowDistanceToletance, 0);
            shadowProjector.farClipPlane = dist + shadowDistanceToletance;
        }
    }
}

