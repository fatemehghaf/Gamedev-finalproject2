using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float velocity;
    public float links;
    private Vector3 rotation;

    private Animator animC;
   
//hit
    public int maxhealth;
    int currentHealth;

    void Start()
    {
        velocity = transform.position.x + velocity;
        links = transform.position.x - links;
        animC = GetComponent<Animator>();

        currentHealth = maxhealth;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(transform.position.x < links){

            transform.eulerAngles = rotation - new Vector3(0,180,0);
        }

        if(transform.position.x > velocity){
            transform.eulerAngles = rotation;
        }

    }
public void TakeDamage(int damage){
        currentHealth -= damage;

        if(currentHealth <= 0){
            EnemyDie();
        }
    }
    void EnemyDie(){
        speed=0;
        Debug.Log("Enemy died");
        animC.SetTrigger("EnemycDead");
        Invoke("DestroyEnemy", 0.8f); 
    }
    void DestroyEnemy(){
        Destroy(gameObject);
    }
}
