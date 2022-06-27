using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jump = 7;
    

    private bool isgrounded = false;

    private Animator anim;
    private Vector3 rotation;
    private StarManagment sm;

    public GameObject panel;
    //public GameObject fire;
    public GameObject camera;

    //heart
    int playerHealth=3;
    public GameObject[] heart;

    //attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayers;
    

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//!
        rotation = transform.eulerAngles;
        sm = GameObject.FindGameObjectWithTag("Text").GetComponent<StarManagment>();
        playerHealth = heart.Length; //heart
    }

    
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0){
            anim.SetBool("IsRunning" , true);
        }else{
            anim.SetBool("IsRunning" , false);
        }

        if(direction < 0){
            transform.eulerAngles = rotation - new Vector3(0,180,0);
            transform.Translate(Vector2.right * speed * -direction * Time.deltaTime);
        }
        if(direction > 0){
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }

        if (isgrounded == false){
            anim.SetBool("IsJumping" , true);
        }else{
            anim.SetBool("IsJumping" , false);
        }

        

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded){
            rb.AddForce(Vector2.up * jump , ForceMode2D.Impulse);
            isgrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.A)){
            playerAttack();
        }

        camera.transform.position = new Vector3(transform.position.x , 0 , -10);

    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ground"){
            isgrounded=true;
        }
        if(collision.gameObject.tag == "Enemy"){
            HeartDecrease();
        }
    }
    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "star"){
            sm.AddStar();
            Destroy(other.gameObject);
            //FindObjectOfType<AudioManager>().Play("Coin");
        }
        if(other.gameObject.tag == "upKill"){
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Monster"){   
            HeartDecrease();
        }
        if(other.gameObject.tag == "Valley"){
            Destroy(gameObject);
            panel.SetActive(true); 
        }
        if(other.gameObject.tag == "Flag"){
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void HeartDecrease(){
        anim.SetTrigger("playerHurt");
        playerHealth--;
            if(playerHealth <= 0){
            //Instantiate(fire, transform.position , Quaternion.identity);
            panel.SetActive(true); 
            Destroy(gameObject);
            //FindObjectOfType<AudioManager>().Play("Die");
            }
            Destroy(heart[playerHealth].gameObject);
    }

    public void playerAttack(){
        anim.SetTrigger("playerAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange , enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("Vincenzo hit "+enemy.name);
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;

            Gizmos.DrawWireSphere(attackPoint.position , attackRange);
        
    }
}
