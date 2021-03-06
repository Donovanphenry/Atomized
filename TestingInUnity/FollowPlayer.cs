using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player; // connecting the camera to a reference of the player
    public Vector3 camOffset; // camOffset = <x, y, z>

    // Update is called once per frame
    void Update()
    {
        // Set the position of the camera to track the player + the offset
        transform.position = player.position + camOffset;
    }
}
