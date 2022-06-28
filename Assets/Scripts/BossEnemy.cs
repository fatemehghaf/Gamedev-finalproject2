using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed = 3f;
    public bool Act = false;

    private Animator animA;
   
//hit
    public int maxhealth;
    int currentHealth;

    void Start()
    {
        
        
        animA = GetComponent<Animator>();

        currentHealth = maxhealth;
    }


    // Update is called once per frame
    void Update()
    {
        

    }
public void TakeDamage(int damage){
        FindObjectOfType<AudioManager>().Play("enemyHurt");
        currentHealth -= damage;

        if(currentHealth <= 0){
            EnemyDie();
        }
    }
    void EnemyDie(){
        //speed=0;
        Debug.Log("Enemy died");
        Invoke("DestroyEnemy", 0.5f); 
    }
    void DestroyEnemy(){
        Destroy(gameObject);
    }
}
