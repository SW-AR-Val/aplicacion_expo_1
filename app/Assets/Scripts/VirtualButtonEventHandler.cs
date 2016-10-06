using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{

    // Private fields to store the models
    private GameObject Sphere;

    /// Called when the scene is loaded
    void Start()
    {

        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }

        // Find the models based on the names in the Hierarchy
        Sphere = transform.FindChild("Sphere").gameObject;

    }

    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        //Debug.Log(vb.VirtualButtonName);
        Debug.Log("Button pressed!");

        switch (vb.VirtualButtonName)
        {
            case "Red":
                Sphere.GetComponent<Renderer>().material.color = Color.red;
                break;
            case "Blue":
                Sphere.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }

    }

    /// Called when the virtual button has just been released:
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("Button released!");
        switch (vb.VirtualButtonName)
        {
            case "Red":
                Sphere.GetComponent<Renderer>().material.color = Color.white;
                break;
            case "Blue":
                Sphere.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }
}

