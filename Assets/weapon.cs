using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class weapon : MonoBehaviour
{
    public GameObject player_sprite;
    public GameObject bulletClone;
    float playerPositionX;
    float playerPositionY;
    public float playerRotationZ;
    public float remaining; 
    public Rigidbody2D rb2D;
    public BoxCollider2D boxColide;
    public SpriteRenderer sprender;
    bool isCurrentlyColliding;
    int place = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        playerPositionX = player_sprite.transform.position.x;
        playerPositionY = player_sprite.transform.position.y;
        playerRotationZ = player_sprite.transform.eulerAngles.z;
        remaining = 360 - playerRotationZ;

        if(place == 1){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                clone(); 
            }
        }

        offAndOn();
        move();     
    }
    void clone(){
        transform.position = new Vector3(playerPositionX,playerPositionY,playerRotationZ);
        Instantiate(bulletClone, new Vector3(playerPositionX, playerPositionY, playerRotationZ), transform.rotation); 
        place++;
    }
    void move(){
        if(place > 1){
            //if(playerRotationZ > 0 && playerRotationZ < 90){
                transform.position = transform.position + new Vector3( Input.mousePosition.x * Time.deltaTime, Input.mousePosition.y * Time.deltaTime, 0);
            //}
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(place > 1){
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
    void offAndOn() {
        if(place == 1){
            sprender = gameObject.GetComponent<SpriteRenderer>();
            sprender.enabled = false;
        }
        else{
            sprender.enabled = true;
        }
    }
}
