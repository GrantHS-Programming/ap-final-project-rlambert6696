using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class weapon : MonoBehaviour
{
    public GameObject player_sprite;
    public GameObject bulletClone;
    float playerPositionX;
    float playerPositionY;
    float playerPositionZ;
    public Rigidbody2D rb2D;
    public BoxCollider2D boxCoide;
    bool isCurrentlyColliding;
    int place = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(place == 1){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                clone(); 
            }
        }        
    }
    void clone(){
        playerPositionX = player_sprite.transform.position.x;
        playerPositionY = player_sprite.transform.position.y;
        playerPositionZ = player_sprite.transform.position.z;

        Instantiate(bulletClone, new Vector3(playerPositionX, playerPositionY, playerPositionZ), transform.rotation); 
        place++;
    }
    void move(){
        transform.position = transform.position + new Vector3(5 * Time.deltaTime, 3 * Time.deltaTime, 0);
        if(isCurrentlyColliding){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col) {
        isCurrentlyColliding = true;
    }
}
