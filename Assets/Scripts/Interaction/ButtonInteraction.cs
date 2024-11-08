using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    private Animator animator;
    public GameObject gate;
    
    public void Interact()
    {
        animator = GetComponent<Animator>();
        animator?.SetTrigger("Interact");
        gate?.SetActive(false);
    }
}
