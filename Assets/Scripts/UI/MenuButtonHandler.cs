using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuButtonHandler : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Button quitButton;
    public string gameSceneName = string.Empty;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        if (uiDocument == null) return;

        startButton = uiDocument.rootVisualElement.Q<Button>("StartBtn");
        quitButton = uiDocument.rootVisualElement.Q<Button>("QuitBtn");

        startButton?.RegisterCallback<ClickEvent>(StartButtonEvent);
        quitButton?.RegisterCallback<ClickEvent>(QuitButtonEvent);
    }

    void OnDisable()
    {
        startButton?.UnregisterCallback<ClickEvent>(StartButtonEvent);
        quitButton?.UnregisterCallback<ClickEvent>(QuitButtonEvent);
    }

    private void StartButtonEvent(ClickEvent _)
    {
        if (gameSceneName != string.Empty)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    private void QuitButtonEvent(ClickEvent _)
    {
    #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
