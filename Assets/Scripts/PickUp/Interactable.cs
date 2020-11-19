using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactableTransform;
    public Transform player;

    public float radius = 3f;

    bool isFocus;
    bool hasInteractable = false; 

    private void OnDrawGizmos() {
        if (interactableTransform == null)
        {
            interactableTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactableTransform.position, radius);
    }

    private void Update() {
        
        float distance = Vector3.Distance(interactableTransform.position, player.position);

            if (distance <= radius)
            {
                Interact();
            }
    }

    public virtual void Interact()
    {
        Debug.Log("Interaction");
    }

    public void OnFocused(Transform newPlayer)
    {
        isFocus = true;
        player = newPlayer;
        hasInteractable = false;
    }

    public void NotFocused()
    {
        isFocus = false;
        player = null;
        hasInteractable = false;
    }
}
