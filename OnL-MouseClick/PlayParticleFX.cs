// Triggers assigned AudioClip to play when L-mouse button is pressed down on gameObject
using UnityEngine;

public class PlayParticleFX : MonoBehaviour
{
    [Header("When gameObject L-mouse clicked play particle effect")]
    [SerializeField] ParticleSystem[] effectToPlay = null;

    private GameObject playerLocation;
    private float distanceToTrigger;

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        if (distanceToTrigger <= 5)
        {
            Instantiate(effectToPlay[Random.Range(0,effectToPlay.Length)], transform.position, gameObject.transform.rotation);
        }
    }
}