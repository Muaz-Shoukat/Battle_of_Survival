using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player, cameraTrans;
    public float followDistanceThreshold = 5f;
    public float followSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTrans.LookAt(player);
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the distance exceeds the follow distance threshold
        if (distance > followDistanceThreshold)
        {
            // Calculate the new position for the camera to follow the player
            Vector3 targetPosition = player.position;
            targetPosition.y = transform.position.y; // Maintain the camera's Y position

            // Move the camera towards the new position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
    }

}
