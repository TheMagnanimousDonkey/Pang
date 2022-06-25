using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    
    [SerializeField] GameObject trailPrefab;
    private Vector3 start;
    



    private void Start()
    {
        start = this.gameObject.transform.position;
        //StartCoroutine(placeTrailElementBetween(start, this.gameObject, trailPrefab));

    }
    private void FixedUpdate()
    {
        Vector3 b = this.gameObject.transform.position;

        // just for demo purpose, use "lerp" to find the middle position between a and b
        // this is where we'll put the newly instanced trail object
        Vector3 midPoint = Vector3.Lerp(start, b, 1f);
        // now scale the trail along Z so it fits exactly between a and b
        Vector3 delta = start - b;
        float scale = delta.magnitude; // make sure the trail element is exactly 1.0 units in z, or this won't work.

        // create a new trail segment from the prefab
        GameObject newTrailElement = Instantiate(trailPrefab);


        // put it between a nd b
        newTrailElement.transform.position = midPoint;

        // have it's z direction face towards b (the player's transform)
        // and make sure it aligns in UP direction
        newTrailElement.transform.LookAt(this.gameObject.transform, this.gameObject.transform.up);
        newTrailElement.AddComponent<DestroyTime>();

        // newTrailElement.transform.position += Vector3.up * 0.5f;
        BoxCollider bc;
        bc = newTrailElement.GetComponent<BoxCollider>();
        Vector3.Scale(bc.transform.localScale, new Vector3(1, 2, 1));
        start = this.transform.position;
    }

    IEnumerator placeTrailElementBetween(Vector3 a, GameObject player, GameObject theTrailPrefab)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f);
           
            // get the position of the player
            Vector3 b = player.transform.position;

            // just for demo purpose, use "lerp" to find the middle position between a and b
            // this is where we'll put the newly instanced trail object
            Vector3 midPoint = Vector3.Lerp(a, b, 1f);
            // now scale the trail along Z so it fits exactly between a and b
            Vector3 delta = a - b;
            float scale = delta.magnitude; // make sure the trail element is exactly 1.0 units in z, or this won't work.
          
                // create a new trail segment from the prefab
                GameObject newTrailElement = Instantiate(theTrailPrefab);


                // put it between a nd b
                newTrailElement.transform.position = midPoint;

                // have it's z direction face towards b (the player's transform)
                // and make sure it aligns in UP direction
                newTrailElement.transform.LookAt(player.transform, player.transform.up);
                newTrailElement.AddComponent<DestroyTime>();

               // newTrailElement.transform.position += Vector3.up * 0.5f;
                BoxCollider bc;
                bc = newTrailElement.GetComponent<BoxCollider>();
                Vector3.Scale(bc.transform.localScale, new Vector3(1, 2, 1));
            


            a = player.transform.position;
        }

        
    }
}
