using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument uiDocument;
    private ProgressBar healthBar;
    private ProgressBar staminaBar;
    private Label scoreLabel;
    private Label timeLabel;


    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        healthBar = uiDocument.rootVisualElement.Q<ProgressBar>("HealthBar");
        staminaBar = uiDocument.rootVisualElement.Q<ProgressBar>("StaminaBar");
        scoreLabel = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        timeLabel = uiDocument.rootVisualElement.Q<Label>("TimeLabel");
    }

    public void UpdateHealth(float health)
    {
        healthBar.value = health;
    }

    public void UpdateStamina(float stamina)
    {
        staminaBar.value = stamina;
    }

    public void UpdateScoreLabel(float score)
    {
        scoreLabel.text = score.ToString();
    }

    public void UpdateTimeLabel(int time)
    {
        timeLabel.text = time.ToString();
    }
}
