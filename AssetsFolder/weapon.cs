using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public SpriteRenderer sprender;
    bool isCurrentlyColliding;
    int place = 1;
    public float targetTime;
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

        if(targetTime <= 0.0f){
            if(place > 1){
                Destroy(gameObject);
                Debug.Log("time up");
            }
        }
    }
    void clone(){
        targetTime = 5f;
        transform.position = new Vector3(playerPositionX,playerPositionY,playerRotationZ);
        bulletClone = Instantiate(bulletClone, new Vector3(playerPositionX, playerPositionY, playerRotationZ), transform.rotation);
        bulletClone.name = "Bullet";
        if(place == 1){
        finalRotation = player_sprite.transform.eulerAngles.z;
        }
        place++;
    }
    void move(){
        targetTime -= Time.deltaTime;

        if(place == 2){
            if(finalRotation < 22.5 || finalRotation > 337.5){
                transform.position = transform.position + new Vector3( 0 * Time.deltaTime, 13 * Time.deltaTime, 0);
            }
            if(finalRotation >= 22.5 && finalRotation < 67.5){
                transform.position = transform.position + new Vector3(-13 * Time.deltaTime, 13 * Time.deltaTime, 0);
            }
            if(finalRotation >= 67.5 && finalRotation < 112.5){
                transform.position = transform.position + new Vector3(-13 * Time.deltaTime, 0 * Time.deltaTime, 0);
            }
            if(finalRotation >= 112.5 && finalRotation < 157.5){
                transform.position = transform.position + new Vector3(-13 * Time.deltaTime, -13 * Time.deltaTime, 0);
            }
            if(finalRotation >= 157.5 && finalRotation < 202.5){
                transform.position = transform.position + new Vector3( 0 * Time.deltaTime, -13 * Time.deltaTime, 0);
            }
            if(finalRotation >= 202.5 && finalRotation < 247.5){
                transform.position = transform.position + new Vector3( 13 * Time.deltaTime, -13 * Time.deltaTime, 0);
            }
            if(finalRotation >= 247.5 && finalRotation < 292.5){
                transform.position = transform.position + new Vector3( 13 * Time.deltaTime, 0 * Time.deltaTime, 0);
            }
            if(finalRotation >= 292.5 && finalRotation < 337.5){
                transform.position = transform.position + new Vector3( 13 * Time.deltaTime, 13 * Time.deltaTime, 0);
            }
        }
    }
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(place > 1){
            if(collision.gameObject.tag != "Player"){
                Destroy(gameObject);
            }
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
