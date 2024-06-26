using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    public GameObject clone;
    public GameObject player_sprite;
    Vector2 randomPosition;

    public float xRange = 10;
    public float yRange = 10;

    public float heightOffset = 10;

    float playerPositionX;
    float playerPositionY;
    public float movementSpeed;

    float one;
    float two;
    int placeholder;
    int kills;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPositionX = player_sprite.transform.position.x;
        playerPositionY = player_sprite.transform.position.y;

        if (tag != "Fake")
        {
            if (Random.Range(1, 1500) == 1)
            {

                //createClone(num);
                num++;
            }
        }

        move();
    
    }

    void createClone(int num)
    {

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        clone = Instantiate(clone, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 1), transform.rotation);

        transform.Rotate(Vector3.right * Time.deltaTime);

        float xPositionPos = Random.Range(playerPositionX + xRange, playerPositionX + (xRange * 2));
        float yPositionPos = Random.Range(playerPositionY + yRange, playerPositionY + (yRange * 2));

        float xPositionMin = Random.Range(playerPositionX - xRange, playerPositionX - (xRange * 2));
        float yPositionMin = Random.Range(playerPositionY - yRange, playerPositionY - (xRange * 2));

        placeholder = Random.Range(1, 4);
            if(placeholder == 1)
            {
                one = xPositionPos;
                two = yPositionPos;
            }
            else if(placeholder == 2)
            {
                one = xPositionPos;
                two = yPositionMin;
            }
            else if(placeholder == 3)
            {
                one = xPositionMin;
                two = yPositionMin;
            }
            else
            {
            one = xPositionMin;
                two = yPositionPos;
            }

        randomPosition = new Vector2(one, two);

        transform.position = randomPosition;

        clone.name = "clone " + num;

        clone.tag = "Fake";
        
    }
    void move()
    {   
        float posX = transform.position.x;
        float posY = transform.position.y;
        if(tag == "Fake"){
            if(posX < playerPositionX){
                if(posY < playerPositionY){
                    transform.position = transform.position + new Vector3(5 * movementSpeed * Time.deltaTime, 5 * movementSpeed * Time.deltaTime, 0);
                }
                if(posY > playerPositionY){
                    transform.position = transform.position + new Vector3(5 * movementSpeed * Time.deltaTime, -5 * movementSpeed * Time.deltaTime, 0);
                }
            }
            if(posX > playerPositionX){
                if(posY < playerPositionY){
                    transform.position = transform.position + new Vector3(-5 * movementSpeed * Time.deltaTime, 5 * movementSpeed * Time.deltaTime, 0);
                }
                if(posY > playerPositionY){
                    transform.position = transform.position + new Vector3(-5 * movementSpeed * Time.deltaTime, -5 * movementSpeed * Time.deltaTime, 0);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Bullet"){
            if(tag == "Fake"){
                Destroy(gameObject);
            }
        }
    }
}
