using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //TODO: keep track of the game state

    [Tooltip("System Prefabs that will be dynamic instantiated")]
    [SerializeField] private GameObject[] systemPrefabs;

    private List<GameObject> _instancedSystemPrefabs;
    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        _instancedSystemPrefabs = new List<GameObject>();
        _loadOperations = new List<AsyncOperation>();
        InstantiateSystemPrefabs();

        LoadLevel("Main");
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);

            // Dispatch messages
            // Transition between scenes
        }

        Debug.Log("[GameManager] Load Complete");
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("[GameManager] Unload Complete");
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

}
