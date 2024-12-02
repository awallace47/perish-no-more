using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossStatusManager : EnemyStatusManager
{
    public VisualTreeAsset completeScreen;
    private UIDocument uiDocument;
    private PlayerStatusManager playerStatusManager;

    private void Start()
    {
        uiDocument = GameObject.Find("UIDocument").GetComponent<UIDocument>();
        playerStatusManager = GameObject.Find("Player").GetComponent<PlayerStatusManager>();
    }

    protected override IEnumerator Die()
    {
        yield return base.Die();
        Time.timeScale = 0;

        uiDocument.visualTreeAsset = completeScreen;
        Label timeBonusLabel = uiDocument.rootVisualElement.Q<Label>("TimeBonus");
        timeBonusLabel.text = playerStatusManager.timeInSeconds.ToString();
        Label totalScoreLabel = uiDocument.rootVisualElement.Q<Label>("TotalScore");
        totalScoreLabel.text = (playerStatusManager.timeInSeconds + playerStatusManager.score).ToString();
    }
}
