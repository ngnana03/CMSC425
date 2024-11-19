using UnityEngine;

public class ChangeCubes : MonoBehaviour
{
    //For disabling and enabling cubes
    private Renderer greenRenderer;
    private Renderer redRenderer;
    private BoxCollider greenCubeCollider;
    private BoxCollider redCubeCollider;
    public Material emptyMaterial;
    public Material fillMaterial;

    void Start()
    {
        if (CompareTag("GreenCubePlatform"))
        {
            // Get the Renderer component if this is the cube
            greenRenderer = GetComponent<Renderer>();
            greenCubeCollider = GetComponent<BoxCollider>();
            //Debug.Log("green cube set");
        }

        if (CompareTag("RedCubePlatform"))
        {
            // Get the Renderer component if this is the cube
            redRenderer = GetComponent<Renderer>();
            redCubeCollider = GetComponent<BoxCollider>();

            Material[] ms = redRenderer.sharedMaterials;
            ms[1] = emptyMaterial;
            redRenderer.sharedMaterials = ms;

            //Debug.Log("red cube set");

        }

    }

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeCubeState(greenCubeCollider, greenRenderer);
            changeCubeState(redCubeCollider, redRenderer);
        }
    }


    void changeCubeState(Collider col, Renderer rend)
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
}
