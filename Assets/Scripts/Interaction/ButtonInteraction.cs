using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public Animator animator;
    public GameObject gate;
    
    public void Interact()
    {
        animator?.SetTrigger("Interact");
        gate?.SetActive(false);
    }
}
