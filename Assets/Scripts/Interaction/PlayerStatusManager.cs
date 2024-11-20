using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStatusManager : StatusManager
{
    public LayerMask enemyLayers;
    private UIManager uiManager;

    private PlayerAttack playerAttack;
    public int stamina = 100;
    public float regenTime = 2.0f;
    private float score = 0f;
    public int timeInSeconds = 300;
    private bool staminaRecentlyUsed = false;
    private bool damageRecentlyTaken = false;
    public bool godMode = false;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        uiManager = FindObjectsByType<UIManager>(FindObjectsSortMode.None).FirstOrDefault();

        StartCoroutine(UpdateStamina());
        StartCoroutine(UpdateHealth());
        StartCoroutine(UpdateCountdownTimer());
    }

    public void SubtractHealth(int amount)
    {
        StartCoroutine(FlashRed());
        health -= amount;
        damageRecentlyTaken = true;
        uiManager?.UpdateHealth(health);
        if (health <= 0f && !godMode)
        {
            StartCoroutine(Die());
        }
    }

    protected override IEnumerator Die()
    {
        yield return base.Die();
        uiManager?.GameOver();
        Time.timeScale = 0;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        uiManager?.UpdateHealth(health);
    }

    public void SubtractStamina(int amount)
    {
        stamina -= amount;
        uiManager?.UpdateStamina(stamina);
        staminaRecentlyUsed = true;
    }

    public void AddStamina(int amount)
    {
        stamina += amount;
        uiManager?.UpdateStamina(stamina);
    }

    public void AddScore(float amount)
    {
        score += amount;
        uiManager.UpdateScoreLabel(score);
    }

    protected override void HandleOnCollisionEnter2D(Collision2D collision)
    {
        if (!playerAttack.IsAttacking && (enemyLayers & (1 << collision.gameObject.layer)) != 0)
        {
            SubtractHealth(10);
        }
    }

    private IEnumerator UpdateStamina()
    {
        while (true)
        {
            if (stamina != 100.0f && !staminaRecentlyUsed)
            {
                AddStamina(10);
                yield return new WaitForSeconds(1.0f);
            }
            else if (staminaRecentlyUsed)
            {
                staminaRecentlyUsed = false;
                yield return new WaitForSeconds(1.0f);
            }

            yield return null;
        }
    }

    private IEnumerator UpdateHealth()
    {
        while (true) 
        {
            if (health != 100.0f && damageRecentlyTaken)
            {
                AddHealth(5);
                yield return new WaitForSeconds(2.0f);
            }
            else if (damageRecentlyTaken)
            {
                damageRecentlyTaken = false;
                yield return new WaitForSeconds(2.0f);
            }

            yield return null;
        }
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
}
