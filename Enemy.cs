using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float leftMax;
    public float rightMax;
    Vector2 walkingDirection = Vector2.right;
    float originalX;

    // Start is called before the first frame update
    void Start()
    {
         
         
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingDirection == Vector2.right && transform.position.x > originalX + rightMax){
            walkingDirection = Vector2.left;
        }
          if (walkingDirection == Vector2.left && transform.position.x < originalX - leftMax){
            walkingDirection = Vector2.right;
        }
        transform.Translate(walkingDirection * speed * Time.deltaTime);
    }
    
     void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<HUDManager>().LoseLife();
        }
    }
}
