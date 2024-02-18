using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CentralCollisionManager : MonoBehaviour
{

    public Vector3 door1OpenPosition;
    public Vector3 door1ClosePosition;
    public Vector3 door2OpenPosition;
    public Vector3 door2ClosePosition;
    public Transform door1;
    public Transform door2;
    public float moveSpeed = 1f;

    private bool shouldOpenDoors = false;
    private bool shouldCloseDoors = false;

    void Update() {
        // check if doors should be moving
        if (shouldOpenDoors) {
            MoveDoors(true);
        }
        else if (shouldCloseDoors) {
            MoveDoors(false);
        }
    }

    private void MoveDoors(bool openOrClose) {
        // how much to move the door each frame
        float step = moveSpeed * Time.deltaTime;


        if (openOrClose) {
            door1.position += new Vector3(step, 0, 0);
            door2.position -= new Vector3(step, 0, 0);
        }
        else if (!openOrClose) {
            door1.position -= new Vector3(step, 0, 0);
            door2.position += new Vector3(step, 0, 0);
        }

    }

    public void HandleTriggerEnter(GameObject self, GameObject other)
    {
        if (self.name == "TriggerCube" && other.name == "Lever") {
            // Debug.Log("In here");
            shouldOpenDoors = true;
            shouldCloseDoors = false;
        }
        else if (self.name == "InvisibleWall" && other.name == "Player" ) {
            shouldCloseDoors = true;
            shouldOpenDoors = false;
        }

    }
 
}

