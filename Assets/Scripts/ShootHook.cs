using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHook : MonoBehaviour
{
    public GameObject ball;
    public float speed = 10;
    [SerializeField] Transform firePoint;
    private Vector3 origin;
    private Vector3 endPoint;
    private Rigidbody rb;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Find origin and end point
            origin = this.transform.position + this.transform.forward * 1f * this.transform.lossyScale.z;
            endPoint = origin + this.transform.forward * 10f;
            Vector3 direction = endPoint - origin;
            direction.Normalize();

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, 300f))
            {
                endPoint = hit.point;
                GameObject newBall = Instantiate(ball, firePoint.position, firePoint.rotation) as GameObject;
                rb = newBall.GetComponent<Rigidbody>();
                rb.velocity = (hit.point - transform.position).normalized * speed;

            }
           

            
        }
    }
}
