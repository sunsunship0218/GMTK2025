using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public IInteractable interactableInRange;
    [SerializeField] GameObject icon;

    private void Awake()
    {
        icon.SetActive(false);
    }
    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            interactableInRange?.Interact();
        }
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable interactable  ) && interactable.CanInteract())
        {
            interactableInRange = interactable;
         icon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable==interactableInRange)
        {
            interactableInRange =null;
            icon.SetActive(false);
        }
    }

}
