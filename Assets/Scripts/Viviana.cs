using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viviana : MonoBehaviour
{
    public float speed = 5;
    public bool Act = false;
    //private Animator animVivi;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        transform.Translate (Vector3.right * speed * Time.deltaTime);
        if(Act== false){
            speed=0;
            //animVivi.SetTrigger("viviIdle");
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Valley"){
            Destroy(gameObject);
        }
    }
}
