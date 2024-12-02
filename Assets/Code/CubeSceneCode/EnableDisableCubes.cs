using UnityEngine;

//This script flips the cubes when player jumps, takes advantage of hierarchy structure to find all the red and green cubes in the scene
public class EnableDisableCube : MonoBehaviour
{
    //Arrays to hold colliders and renderers of red and green cubes
    private Collider[] redColliders, greenColliders;
    private Renderer[] redRenderers, greenRenderers;

    //To change the material of the cubes
    public Material emptyMaterial;
    public Material fillMaterial;

    //Reference to player object
    private PlayerMovementCubeScene player;

    void Start()
    {
        // Get all colliders and renderers from child objects
        GameObject greens = GameObject.Find("Greens");
        GameObject reds = GameObject.Find("Reds");

        redColliders = reds.GetComponentsInChildren<Collider>();
        redRenderers = reds.GetComponentsInChildren<Renderer>();
        FlipCubes(redColliders, redRenderers);

        greenColliders = greens.GetComponentsInChildren<Collider>();
        greenRenderers = greens.GetComponentsInChildren<Renderer>();

        //Reference to player object
        GameObject obj = GameObject.Find("Player");
        player = obj.GetComponent<PlayerMovementCubeScene>();
    }

    void Update()
    {
        // Flips the cubes, only if the user jumps and if the character is grounded
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        {
            FlipCubes(redColliders, redRenderers);
            FlipCubes(greenColliders, greenRenderers);
        }
    }

    void ChangeCubeStateHelper(Collider col, Renderer rend)
    {
        if (col != null && rend != null)
        {
            bool isEnabled = !col.enabled;
            col.enabled = isEnabled;
            Material[] ms = rend.sharedMaterials;

            if (isEnabled)
            {
                ms[1] = fillMaterial;
            }
            else
            {
                ms[1] = emptyMaterial;
            }

            rend.sharedMaterials = ms;
        }
    }

    public void FlipCubes(Collider[] cols, Renderer[] rends)
    {
        int i = 0;
        while (i < cols.Length)
        {
            ChangeCubeStateHelper(cols[i], rends[i]);
            i++;
        }
    }
}
