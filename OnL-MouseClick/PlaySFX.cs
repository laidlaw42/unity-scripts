// Triggers assigned AudioClip to play when L-mouse button is pressed down on gameObject
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [Header("When gameObject L-mouse clicked play sound")]
    [SerializeField] AudioClip[] audioToTrigger = null;
    private GameObject playerLocation;
    private float distanceToTrigger;

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        if (distanceToTrigger <= 5)
        {
            AudioSource.PlayClipAtPoint(audioToTrigger[Random.Range(0,audioToTrigger.Length)], transform.position);
        }
    }
}