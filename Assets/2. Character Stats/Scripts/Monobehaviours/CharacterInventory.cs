using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventory : MonoBehaviour
{
    #region Variable Declarations
    public static CharacterInventory Instance;
    #endregion

    #region Initializations
    void Start()
    {
        Instance = this;
    }
    #endregion
}
