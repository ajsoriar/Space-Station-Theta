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
    // Oxigen
    public int oxygenBotleCount;
    public int oxygen;
    public int oxygenMax; // 100
    
    // Health
    public int healthCaseCount;
    public int health;
    public int healthMax; //100

    // Weapons
    public int currentWeapon; // 0 Hands, 1 Basic, 2 Bazooka, 3 LoveYou!
    public int bulletsCounter;
    public float weaponTemperature;
    public float weaponTemperatureMax; // 100

    // Skils
    //public bool fastRunUnlocked;
    //public bool jumpUnlocked;
    public bool energyShieldUnlocked;

    // Speed Boots
    public int speedBootsSteps;
    public int speedBootsVelocity;

    // Items
    public int coinsCounter;
    public int keysCounter;

    //Other
    public int totalEnemies;
    public int enemiesNearMe;
    public bool isDeath; // death is an irreversible process where someone loses their existence as a person.
}