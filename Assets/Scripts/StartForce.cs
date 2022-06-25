using UnityEngine;

public class StartForce : MonoBehaviour
{
    public float min;
    public float max;

    void Start()
    {
        Vector3 startForce = new Vector3(UnityEngine.Random.Range(min, max), 0f, UnityEngine.Random.Range(min, max));
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
        
    }
}
