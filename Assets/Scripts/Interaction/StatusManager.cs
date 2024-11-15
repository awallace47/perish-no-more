using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public LayerMask enemyLayers;
    private UIManager uiManager;
    private PlayerAttack playerAttack;
    public float health = 100.0f;
    public float stamina = 100.0f;
    private float score = 0f;
    public int timeInSeconds = 300;
    private bool staminaRecentlyUsed = false;
    void Start()
    {
        uiManager = FindObjectsByType<UIManager>(FindObjectsSortMode.None).FirstOrDefault();
        playerAttack = GetComponent<PlayerAttack>();
        StartCoroutine(UpdateCountdownTimer());
        StartCoroutine(UpdateStamina());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerAttack.IsAttacking && (enemyLayers & (1 << collision.gameObject.layer)) != 0)
        {
            SubtractHealth(10.0f);
        }
    }

    public void SubtractHealth(float amount)
    {
        health -= amount;
        uiManager?.UpdateHealth(health);
    }

    public void AddHealth(float amount)
    {
        health += amount;
        uiManager?.UpdateHealth(health);
    }

    public void SubtractStamina(float amount)
    {
        stamina -= amount;
        uiManager?.UpdateStamina(stamina);
        staminaRecentlyUsed = true;
    }

    public void AddStamina(float amount)
    {
        stamina += amount;
        uiManager?.UpdateStamina(stamina);
    }

    public void AddScore(float amount)
    {
        score += amount;
        uiManager.UpdateScoreLabel(score);
    }

    private IEnumerator UpdateCountdownTimer()
    {
        while (timeInSeconds >= 0)
        {
            uiManager?.UpdateTimeLabel(timeInSeconds);
            timeInSeconds--;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator UpdateStamina()
    {
        while (true)
        {
            if (stamina != 100.0f && !staminaRecentlyUsed)
            {
                AddStamina(10.0f);
                yield return new WaitForSeconds(1.0f);
            } else if (staminaRecentlyUsed)
            {
                staminaRecentlyUsed = false;
                yield return new WaitForSeconds(1.0f);
            }

            yield return null;
        }
    }
}
