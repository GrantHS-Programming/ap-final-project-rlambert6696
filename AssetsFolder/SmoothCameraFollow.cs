using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothCameraFollow : MonoBehaviour {

    public Transform player;

void Update () 
{
	transform.position = new Vector3 (player.position.x, player.position.y, player.position.z - 10); // Camera follows the player
}   //problem is that the z value is the same for the camera and the evil dude and wall so the camera doesn't see them
}