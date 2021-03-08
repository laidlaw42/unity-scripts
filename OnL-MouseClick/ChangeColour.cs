// Object color changes from colorStart to colorEnd when L-mouse button is pressed down on gameObject
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private Renderer rend;
    public Color colorStart = Color.green;
    public Color colorEnd = Color.red;
    private GameObject playerLocation;
    private float distanceToTrigger;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colorStart;
    }

    void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        if (distanceToTrigger <= 5)
        {
            rend.material.color = colorEnd;
        }
    }
}