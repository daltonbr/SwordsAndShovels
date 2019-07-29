using System;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class MainMenu : MonoBehaviour
{
    // TODO: Function that can receive animation events

    [SerializeField] private AnimationClip fadeOutAnimation;
    [SerializeField] private AnimationClip fadeInAnimation;
    private Animation _mainMenuAnimator;

    private void Awake()
    {
        _mainMenuAnimator = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged.RemoveListener(HandleGameStateChanged);
    }

    public void OnFadeOutComplete()
    {
        Debug.Log("[MainMenu] FadeOut Complete");
    }

    public void OnFadeInComplete()
    {
        Debug.Log("[MainMenu] FadeIn Complete");

        UIManager.Instance.SetDummyCameraActive(true);
    }

    public void FadeIn()
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = fadeInAnimation;
        _mainMenuAnimator.Play();
    }

    public void FadeOut()
    {
        UIManager.Instance.SetDummyCameraActive(false);

        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = fadeOutAnimation;
        _mainMenuAnimator.Play();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (previousState == GameManager.GameState.Pregame &&
            currentState == GameManager.GameState.Running)
        {
            FadeOut();
        }
    }
}
