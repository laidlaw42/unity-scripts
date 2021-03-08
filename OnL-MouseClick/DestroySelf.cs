// Simple code that destroys the gameObject when L-mouse button is pressed down on gameObject
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [Header("Destroys this gameObject when L-mouse clicked")]
    private GameObject playerLocation;
    private float distanceToTrigger;
    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        // Destroy the gameObject, play particle effect, play a sound
        if (distanceToTrigger <= 5)
        {
            Destroy(gameObject, 0f); // Destroy the gameObject with a timer
        }
    }
}