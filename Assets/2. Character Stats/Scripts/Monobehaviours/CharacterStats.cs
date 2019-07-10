using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterStats_SO characterDefinition;
    public CharacterInventory inventory;
    public GameObject weaponSlot; // maybe a Transform would be better?

    #region Constructors

    public CharacterStats()
    {
        inventory = CharacterInventory.Instance;
    }

    #endregion

    #region Initializations

    private void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 100;
            characterDefinition.currentHealth = 50;

            characterDefinition.maxMana = 25;
            characterDefinition.currentMana = 10;

            characterDefinition.maxWealth = 500;
            characterDefinition.currentWealth = 0;

            characterDefinition.baseDamage = 2;
            characterDefinition.currentDamage = characterDefinition.baseDamage;

            characterDefinition.baseResistance = 0;
            characterDefinition.currentResistance = 0;

            characterDefinition.maxEncumbrance = 50f;
            characterDefinition.currentEncumbrance = 0f;

            characterDefinition.charExperience = 0;
            characterDefinition.charLevel = 1;
        }
    }

    #endregion

    #region SaveData

    private void Update()
    {
        //TODO: This should be triggered by the game manager during a save point
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Saving Character Data");
            characterDefinition.SaveCharacterData();
        }
    }
    
    #endregion
    
    #region Stat Increasers

    public void ApplyHealth(int healthAmount)
    {
        characterDefinition.ApplyHealth(healthAmount);
    }

    public void ApplyMana(int manaAmount)
    {
        characterDefinition.ApplyMana(manaAmount);
    }

    public void GiveWealth(int wealthAmount)
    {
        characterDefinition.GiveWealth(wealthAmount);
    }

    #endregion Stat Increasers

    #region Weapon and Armor Change

    public void ChangeWeapon(ItemPickUp weaponPickUp)
    {
        if (!characterDefinition.UnEquipWeapon(weaponPickUp, inventory, weaponSlot))
        {
            characterDefinition.EquipWeapon(weaponPickUp, inventory, weaponSlot);
        }
    }
    
    public void ChangeArmor(ItemPickUp armorPickUp)
    {
        if (!characterDefinition.UnEquipArmor(armorPickUp, inventory))
        {
            characterDefinition.EquipArmor(armorPickUp, inventory);
        }
    }

    #endregion
    
    #region Stat Reducers

    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    public void TakeMana(int amount)
    {
        characterDefinition.TakeMana(amount);
    }
    
    //TODO: implement 'TakeWealth'

    #endregion

    #region Reporters

    public int GetHealth()
    {
        return characterDefinition.currentHealth;
    }

    public ItemPickUp GetCurrentWeapon()
    {
        return characterDefinition.weapon;
    }
    
    #endregion
    
}
