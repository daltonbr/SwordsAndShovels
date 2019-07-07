using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    #region New Class Definitions
    

    /// <summary>
    /// stats added per level up
    /// </summary>
    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public int baseDamage;
        public float baseResistance;
        public float maxEncumbrance;
    }
    #endregion

    #region Fields

    public bool setManually = false;
    public bool saveDataOnClose = false;

    // Armor
    public ItemPickUp weapon { get; private set; }
    public ItemPickUp headArmor { get; private set; }
    public ItemPickUp chestArmor { get; private set; }
    public ItemPickUp handArmor { get; private set; }
    public ItemPickUp legArmor { get; private set; }
    public ItemPickUp footArmor { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }
    
    // Stats
    
    public int maxHealth = 0;
    public int currentHealth = 0;
    
    public int maxWealth = 0;
    public int currentWealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0f;
    public float currentResistance = 0f;

    public float maxEncumbrance = 0f;
    public float currentEncumbrance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;
    
    public CharLevelUps[] charLevelUps;

    #endregion
    
    #region Stat Increasers

    public void ApplyHealth(int healthAmount)
    {
        if (currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void ApplyMana(int manaAmount)
    {
        if (currentMana + manaAmount) > maxMana))
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += manaAmount;
        }

    }

    public void GiveWealth(int wealthAmount)
    {
        if ((currentWealth + wealthAmount) > maxWealth)
        {
            currentWealth = maxWealth;
        }
        else
        {
            currentWealth += wealthAmount;
        }
    }

    public void EquipWeapon(ItemPickUp weaponPickUp, CharacterInventory characterInventory, GameObject weaponSlot)
    {
        Rigidbody newWeapon;
        weapon = weaponPickUp;
        //characterInventory.inventoryDisplaySlots[2].sprite = weaponPickUp.itemDefinition.itemIcon;
        //newWeapon = Instantiate(weaponPickUp.itemDefinition, weaponSlotObject, weaponSlot.transform);
        //currentDamage = baseDamage + weapon.itemDefinition.itemAmount;
    }

// Commented lines are going to be implemented in a future Item loot course
//    public void EquipArmor(ItemPickUp armorPickUp, CharacterInventory characterInventory)
//    {
//        switch (armorPickUp.itemDefinition.itemArmorSubType)
//        {
//            case ItemArmorSubType.Head:
//                //characterInventory.inventoryDisplaySlots[3].sprite = armorPickUp.itemDefinition.itemIcon;
//                headArmor = armorPickUp;
//                currentResistance += armorPickUp.itemDefinition.itemAmount;
//                break;
//            case ItemArmorSubType.Chest:
//                //characterInventory.inventoryDisplaySlots[4].sprite = armorPickUp.itemDefinition.itemIcon;
//                chestArmor = armorPickUp;
//                currentResistance += armorPickUp.itemDefinition.itemAmount;
//                break;
//            case ItemArmorSubType.Hands:
//                //characterInventory.inventoryDisplaySlots[5].sprite = armorPickUp.itemDefinition.itemIcon;
//                handArmor = armorPickUp;
//                currentResistance += armorPickUp.itemDefinition.itemAmount;
//                break;
//            case ItemArmorSubType.Legs:
//                //characterInventory.inventoryDisplaySlots[6].sprite = armorPickUp.itemDefinition.itemIcon;
//                legArmor = armorPickUp;
//                currentResistance += armorPickUp.itemDefinition.itemAmount;
//                break;
//            case ItemArmorSubType.Boots:
//                //characterInventory.inventoryDisplaySlots[7].sprite = armorPickUp.itemDefinition.itemIcon;
//                footArmor = armorPickUp;
//                currentResistance += armorPickUp.itemDefinition.itemAmount;
//                break;
//        }
//    }

    #endregion
}
