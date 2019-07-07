using System.Collections;
using System.Collections.Generic;
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
