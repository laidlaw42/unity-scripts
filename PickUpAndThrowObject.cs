// Pick up an oject, play object pickup sound, throw an object, play throw object sound
using UnityEngine;

public class PickUpAndThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip[] throwSoundToPlay;
    public AudioClip[] pickupSoundToPlay;
    private AudioSource audioSource;
    public int dmg;
    private bool touched = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position); // Distance from player
        if (dist <= 5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
            Debug.Log("Pressed");
            RandomAudioPickup();
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                RandomAudioThrow();
            }
            else if (Input.GetMouseButtonDown(2))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
    void RandomAudioThrow()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.clip = throwSoundToPlay[Random.Range(0, throwSoundToPlay.Length)];
        audioSource.Play();

    }

    void RandomAudioPickup()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.clip = pickupSoundToPlay[Random.Range(0, pickupSoundToPlay.Length)];
        audioSource.Play();

    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
