using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{
    [SerializeField] GameObject mediumBall;
    [SerializeField] GameObject smallBall;
    private void OnTriggerEnter(Collider any)

    {
        Hook ball = any.GetComponent<Hook>();
        if (ball != null)
        {
            
            if (this.gameObject.name == "BigSphere")
            {
                gameObject.transform.position = new Vector3(0f, 255f,0f);
                Instantiate(mediumBall);
                Instantiate(mediumBall);
            }
            else if (this.gameObject.name == "MediumSphere(Clone)")
            {
                gameObject.transform.position = new Vector3(0f, 255f, 0f);
                Instantiate(smallBall);
                Instantiate(smallBall);
            }

            Destroy(this.gameObject);


        }


    }
}
