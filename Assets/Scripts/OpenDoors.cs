using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public GameObject wall;
    public GameObject lever;
    public Transform door1;
    public Transform door2;
    public float moveSpeed = 1f;

    private bool shouldOpenDoors = false;
    private bool shouldCloseDoors = false;

    void Update() {
        // Check if doors should be moving
        if (shouldOpenDoors) {
            MoveDoors(true);
        }
        else if (shouldCloseDoors) {
            MoveDoors(false);
        }
    }

    private void MoveDoors(bool openOrClose) {
        // variable to dictate how much to move the door each frame
        float step = moveSpeed * Time.deltaTime;

        Debug.Log(openOrClose);

        if (openOrClose) {
            door1.position += new Vector3(step, 0, 0);
            door2.position -= new Vector3(step, 0, 0);
        }
        else if (!openOrClose) {
            door1.position -= new Vector3(step, 0, 0);
            door2.position += new Vector3(step, 0, 0);
        }

    }

    // Example trigger detection to start moving doors
    private void OnTriggerEnter(Collider other) {
        Debug.Log("are we in here?");
        if (other.CompareTag("switch")) {
            // Debug.Log("WE ARE FR IN HERE AND IT SHOULD BE DOING THINGS");
            // StartMovingDoors();
            shouldOpenDoors = true;
            shouldCloseDoors = false;
        }
        if (other.CompareTag("Player")) {
            Debug.Log("player if statement");
            shouldCloseDoors = true;
            shouldOpenDoors = false;
        }
    }
}

