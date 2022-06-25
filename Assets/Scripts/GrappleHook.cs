using UnityEngine;

public class GrappleHook : MonoBehaviour
{

    private LineRenderer hook;
    private Vector3 origin;
    private Vector3 endPoint;
    [SerializeField] GameObject hookPrefab;
    [SerializeField] LineRenderer linePrefab;


    void Start()
    {

    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CheckHook();
        }
        //else hook.enabled = false;
    }

    void CheckHook()
    {
        hook = Instantiate(linePrefab);
        hook.startWidth = 0.2f;
        hook.endWidth = 0.2f;
        //Find origin and end point
        origin = this.transform.position + this.transform.forward * 1f * this.transform.lossyScale.z;
        endPoint = origin + this.transform.forward * 10f;
        Vector3 direction = endPoint - origin;
        direction.Normalize();

        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, 300f))
        {
            endPoint = hit.point;
        }

        //Set Positions
        hook.SetPosition(0, origin);
        hook.SetPosition(1, endPoint);


        //Fire
        hook.enabled = true;

        if (hook.transform.childCount == 0)
        {
            var hookFab = Instantiate(hookPrefab);
            hookFab.transform.parent = hook.transform;
        }
        


    }


}
