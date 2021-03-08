// Triggers an animation to play when L-mouse button is pressed down on gameObject
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [Header("When gameObject L-mouse clicked play animation")]
    [SerializeField] private GameObject objectToAnimate = null;
    [SerializeField] private string animationParameter = "";

    private Animator _animator;
    private GameObject playerLocation;
    private float distanceToTrigger;


    private void Start()
    {
        _animator = objectToAnimate.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        playerLocation = GameObject.Find("PlayerLocation");
        distanceToTrigger = Vector3.Distance(gameObject.transform.position, playerLocation.transform.position);

        if (distanceToTrigger <= 5)
        {
            _animator.SetTrigger(animationParameter);
        }
    }
}