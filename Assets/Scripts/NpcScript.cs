using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    float startTimer = 3.0f; 
    float timer; 
    float direction = 1f; 
    Rigidbody2D rigibody2D; 
    
    // Start is called before the first frame update
    void Start()
    {
        rigibody2D = GetComponent<Rigidbody2D>();
        timer = startTimer;  
    }

    // Update is called once per frame
    void update()
    {
        
    }
    
    void FixedUpdate()
    {
        Vector2 enemyPosition = rigibody2D.position; 
        enemyPosition.x = enemyPosition.x + Time.deltaTime * 3f * direction;

        rigibody2D.MovePosition(enemyPosition);  
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Border 1") || other.gameObject.CompareTag("Border 2")) 
        {
            direction = -direction; 
        }
        
    }

}
