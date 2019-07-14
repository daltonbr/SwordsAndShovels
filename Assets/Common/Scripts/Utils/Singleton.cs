﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance => _instance;

    public static bool IsInitialized => _instance != null;

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            Debug.LogError($"[Singleton] Trying to instantiate a seconds instance of a singleton class {nameof(T)}");
        }
        else
        {
            _instance = (T) this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
