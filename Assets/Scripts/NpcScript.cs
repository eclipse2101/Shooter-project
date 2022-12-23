using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public float startTimer; 
    float timer; 
    float direction = 1f; 
    Rigidbody2D rigibody2D;
    public GameObject projectilePrefab;
    Vector2 lookdirection = new Vector2(0, -1);
    
    // Start is called before the first frame update
    void Start()
    {
        rigibody2D = GetComponent<Rigidbody2D>();
        timer = startTimer;  
    }

    // Update is called once per frame
    void Update()
    {
      timer -= Time.deltaTime;

        if (timer < 0)
        {
            Launch();
            timer = startTimer;
        }  
    }

    void Launch()
    {
     GameObject BulletScript = Instantiate(projectilePrefab, rigibody2D.position + Vector2.up * 0.5f, Quaternion.identity);

     BulletScript CogAmmo = BulletScript.GetComponent<BulletScript>();
     CogAmmo.Launch(lookdirection, 300); 

     Debug.Log("Here");
     
    }
    
    void FixedUpdate()
    {
        Vector2 enemyPosition = rigibody2D.position; 
        enemyPosition.x = enemyPosition.x + Time.deltaTime * 3f * direction;

        rigibody2D.MovePosition(enemyPosition);  
    }

    void OnCollisionEnter2D (Collision2D other) // this is for the enemy to change direction and die if it gets touched by a bullet
    {
        
        
        if (other.gameObject.CompareTag("Border 1") || other.gameObject.CompareTag("Border 2") || other.gameObject.CompareTag("Enemy")) 
        {
            direction = -direction; 
        }

        if (other.gameObject.CompareTag("Player Bullet"))
        {
            Destroy(gameObject);
        }

    }



}
