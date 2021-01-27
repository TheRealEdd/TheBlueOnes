using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballCollision : MonoBehaviour
{
    public float TargetsHit = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision x)
    {
        Debug.Log("HitConfirmed");
        if (x.gameObject.CompareTag("Snowball"))
        {
            Destroy(x.gameObject);
            Debug.Log("destroyed");
            TargetsHit += 1f;
        }
        
    }
}
