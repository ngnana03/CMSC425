using UnityEngine;

//This script defines the behavior of the collectibles, applies hovering effect and collects them when player collision is detected
public class HoveringCollectible : MonoBehaviour
{
    //how far the object moves up and down
    public float hoverAmplitude = 0.5f;
    //hovering speed
    public float hoverSpeed = 2f;
    //particle effect when an object is collected
    public GameObject collectEffect;

    //reference to class that manages win condition
    public CollectibleCounter collectibleCounter;

    //Start position of collectible in the scene
    private Vector3 startPosition;

    // collect audio effect, assigned in the inspector
    public AudioClip collectSound;
    private AudioSource audioSource;

    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // hover effect
        float hover = Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;
        transform.position = startPosition + new Vector3(0, hover, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //trigger collection when the player object collides with the collectible
        if (other.CompareTag("Player"))
        {
            Collect();
            //play sound
            audioSource.PlayOneShot(collectSound);
        }
    }

    void Collect()
    {
        //effect of collectible when collected
        Instantiate(collectEffect, transform.position, Quaternion.identity);

        //disable collider to avoid sound from triggering multiple times
        this.GetComponent<Collider>().enabled = false;

        // add player logic here, e.g., increase score, health, etc.
        //Debug.Log("Collected!");
        //increase score
        collectibleCounter.AddCollectible();

        // Destroy the collectible object, delay for 3 seconds to allow sound to play
        Destroy(gameObject, 4f);
    }
}
