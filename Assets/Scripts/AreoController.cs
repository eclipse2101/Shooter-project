using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreoController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Vector2 lookdirection = new Vector2(1, 0);
    
    public GameObject projectilePrefab;

    
    
    // Start is called before the first frame update
    void Start()
    {
        // Write the code below to get your Rigidbody2D component
        rigidbody2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Write the code below to get your Horizontal and Vertical axis
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            Launch(); 
        }
    }

    private void FixedUpdate() // the movement script
    {
        Vector2 position = rigidbody2d.position;
       position.x = position.x + speed * horizontal * Time.deltaTime; // this function will change the speed of how fast your character moves
       position.y = position.y + speed * vertical * Time.deltaTime;
       rigidbody2d.MovePosition(position);
    }
    
    void Launch()// this needs to be fixed. This part is gonna make me scream
    {
     GameObject BulletScript = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

     BulletScript CogAmmo = BulletScript.GetComponent<BulletScript>();
     CogAmmo.Launch(lookdirection, 300); 
     
    }
    
}
