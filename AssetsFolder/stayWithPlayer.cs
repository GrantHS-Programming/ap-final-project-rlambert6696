using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayWithPlayer : MonoBehaviour
{
    public GameObject player_sprite;
    float playerX;
    float playerY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerX = (float)(player_sprite.transform.position.x - 6.35);
        playerY = (float)(player_sprite.transform.position.y + 2.53);
        transform.position = new Vector3( playerX,playerY, 0);
    }
}
