using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viviana : MonoBehaviour
{
    public float speed = 5;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate (Vector3.right * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Valley"){
            Destroy(gameObject);
        }
    }
}
