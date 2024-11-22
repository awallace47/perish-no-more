using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteraction : MonoBehaviour
{
    private Animator animator;
    public GameObject gate;
    public bool isGateTrigger;
    public AudioSource deathSound;
    public void Interact()
    {
        deathSound.Play();
        animator = GetComponent<Animator>();

        animator?.SetTrigger("Interact");

        if (gate != null) {
            gate?.SetActive(false);
        } else if (isGateTrigger){
            SceneManager.LoadScene("BossArena");
        }
    }
}
