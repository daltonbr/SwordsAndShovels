using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    #region Variable Declarations
    
    public static CharacterInventory Instance;

    #endregion

    #region Initializations
    
    private void Start()
    {
        Instance = this;
    }
    
    #endregion
}
