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

    float finalRotation;

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
        if(place == 1){
        finalRotation = player_sprite.transform.eulerAngles.z;
        }
        place++;
    }
    void move(){
        if(place == 2){
            if(finalRotation < 22.5 || finalRotation > 337.5){
                transform.position = transform.position + new Vector3( 0 * Time.deltaTime, 10 * Time.deltaTime, 0);
            }
            if(finalRotation > 22.5 && finalRotation < 67.5){
                transform.position = transform.position + new Vector3(-10 * Time.deltaTime, 10 * Time.deltaTime, 0);
            }
            if(finalRotation > 67.5 && finalRotation < 112.5){
                transform.position = transform.position + new Vector3(-10 * Time.deltaTime, 0 * Time.deltaTime, 0);
            }
            if(finalRotation > 112.5 && finalRotation < 157.5){
                transform.position = transform.position + new Vector3(-10 * Time.deltaTime, -10 * Time.deltaTime, 0);
            }
            if(finalRotation > 157.5 && finalRotation < 202.5){
                transform.position = transform.position + new Vector3( 0 * Time.deltaTime, -10 * Time.deltaTime, 0);
            }
            if(finalRotation > 202.5 && finalRotation < 247.5){
                transform.position = transform.position + new Vector3( 10 * Time.deltaTime, -10 * Time.deltaTime, 0);
            }
            if(finalRotation > 247.5 && finalRotation < 292.5){
                transform.position = transform.position + new Vector3( 10 * Time.deltaTime, 0 * Time.deltaTime, 0);
            }
            if(finalRotation > 292.5 && finalRotation < 337.5){
                transform.position = transform.position + new Vector3( 10 * Time.deltaTime, 10 * Time.deltaTime, 0);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(place > 1){
            Destroy(gameObject);
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
