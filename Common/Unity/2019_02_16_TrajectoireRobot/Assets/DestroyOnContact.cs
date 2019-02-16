using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public LayerMask m_layerAllowToDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touch", collision.gameObject);
        if(Contains(m_layerAllowToDestroy, collision.gameObject.layer))
            Destroy(this.gameObject);
    }
    public static bool Contains( LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
