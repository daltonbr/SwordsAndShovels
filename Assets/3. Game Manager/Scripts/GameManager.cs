using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> {}

public class GameManager : Singleton<GameManager>
{
    public enum GameState
    {
        Pregame,
        Running,
        Paused
    }

    public EventGameState OnGameStateChanged;
    
    [Tooltip("System Prefabs that will be dynamic instantiated")] [SerializeField]
    private GameObject[] systemPrefabs;
    private List<GameObject> _instancedSystemPrefabs;
    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;
    private GameState _currentGameState = GameState.Pregame;

    public GameState CurrentGameState
    {
        get => _currentGameState;
        private set => _currentGameState = value;
    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();
        InstantiateSystemPrefabs();
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            if (_loadOperations.Count == 0)
            {
                UpdateState(GameState.Running);
            }
        }

        Debug.Log("[GameManager] Load Complete");
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("[GameManager] Unload Complete");
    }

    private void UpdateState(GameState state)
    {
        var previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.Pregame:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                break;
            default:
                throw new ArgumentOutOfRangeException();
            
        }
        
        OnGameStateChanged?.Invoke(_currentGameState, previousGameState);
        // Transition between scenes
    }

    private void InstantiateSystemPrefabs()
    {
        foreach (var systemPrefab in systemPrefabs)
        {
            var prefabInstance = Instantiate(systemPrefab, gameObject.transform, true);
            _instancedSystemPrefabs.Add(prefabInstance);
            prefabInstance.name = nameof(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError($"[GameManager] Unable to load level {levelName}");
            return;
        }

        ao.completed += OnLoadOperationComplete;
        _loadOperations.Add(ao);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError($"[GameManager] Unable to unload level {levelName}");
            return;
        }

        ao.completed += OnUnloadOperationComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        foreach (var gameObj in _instancedSystemPrefabs)
        {
            Destroy(gameObj);
        }

        _instancedSystemPrefabs.Clear();
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }

}
