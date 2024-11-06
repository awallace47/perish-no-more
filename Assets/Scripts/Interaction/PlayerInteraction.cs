using System.Linq;
using UnityEngine;

class PlayerInteraction : MonoBehaviour
{
    public Transform interactCenter;
    public float interactRange = 0.5f;
    public LayerMask buttonLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactCenter == null) return;

        Gizmos.DrawWireSphere(interactCenter.position, interactRange);
    }

    void Interact()
    {
        Collider2D buttonCollider = Physics2D.OverlapCircleAll(interactCenter.position, interactRange, buttonLayer).FirstOrDefault();

        if (buttonCollider != null)
        {
            ButtonInteraction button = buttonCollider.gameObject.GetComponent<ButtonInteraction>();
            if (button != null)
            {
                button.Interact();
            }
        }
    }
}
