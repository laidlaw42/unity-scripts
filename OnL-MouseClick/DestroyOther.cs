// Destroys the GameObject assigned to the objectToDestory when L-mouse button is pressed down on gameObject
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    [Header("Secondary object to destroy")]
    [SerializeField] private GameObject objectToDestroy = null;
    private GameObject playerLocation;
    private float distanceToTrigger;

    private void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        if (distanceToTrigger <= 5)
        {
            Destroy(objectToDestroy);
        }
    }
}