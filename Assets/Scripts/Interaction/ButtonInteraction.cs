using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteraction : MonoBehaviour
{
    private Animator animator;
    public GameObject gate;
    
    public void Interact()
    {
        animator = GetComponent<Animator>();

        animator?.SetTrigger("Interact");

        if (gate != null) {
            gate?.SetActive(false);
        } else {
            SceneManager.LoadScene("BossArena");
        }
    }
}
