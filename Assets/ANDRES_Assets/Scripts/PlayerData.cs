using System;

[Serializable]

/*
 [Serializable] attribute is used to indicate that a class can be serialized 
 and its data can be displayed and edited in the Unity Inspector. 
 When a class is marked with [Serializable], Unity's serialization system can 
 save and load instances of that class, as well as allow the class fields to 
 be exposed and modified in the Inspector.
*/

public class PlayerData
{
    // Basic
    public float oxigen;
    public float oxigenMax;
    public float damage;
    public float damageMax;

    // Weapons
    public int currentWeapon; // 0 Hands, 1 Basic, 2 Bazooka, 3 LoveYou!
    public int bulletsCounter;
    public float weaponTemperature;
    public float weaponTemperatureMax;

    // Skils
    public bool fastRunUnlocked;
    public bool jumpUnlocked;
    public bool energyShieldUnlocked;

    // Items
    public int coinsCounter;
    public int keysCounter;
}