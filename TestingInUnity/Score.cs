using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text playerScore;

	// Update is called once per frame
	void Update () {
        // Sets a text passed into this object to represent a player's
        // position along the z-axis
        playerScore.text = ((int)player.position.z).ToString() + " [m]";
	}
}