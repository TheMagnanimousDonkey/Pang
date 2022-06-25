using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private void OnTriggerEnter(Collider any)

    {
        Hook hook = any.GetComponent<Hook>();
        if (hook != null)
        {
            Rigidbody rb = any.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            StartCoroutine(Delay());
            
        }
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(3);
            if (hook != null)
            {
                Destroy(hook.gameObject);
            }
        }

    }
}
