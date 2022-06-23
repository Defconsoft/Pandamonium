using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool isInteractable = true;
    
    public abstract void Interact();
    
    public void Disable() 
    {
        isInteractable = false;
    }

    public void Enable()
    {
        isInteractable = true;
    }

    public bool isEnabled()
    {
        return isInteractable;
    }
}