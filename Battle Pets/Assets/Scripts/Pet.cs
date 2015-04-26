using UnityEngine;
using System.Collections;

public class Pet {


    public string PetName;
    public ElementType ElementType;
    public int PetHealth;
    public int PetStrength; 
    public float PetSpeed;
    public int CurrentXP;
    public int CurrentLvl;
    public float FireRes;
    public float EarthRes;
    public float WaterRes;
    public float AirRes;

    public Pet(string Name, ElementType EleType, int Health, int Strength, float Speed,  int XP, int Lvl, float ResFire, float ResEarth, float ResWater, float ResAir)
    {
        PetName = Name;
        ElementType = EleType;
        PetHealth = Health;
        PetStrength = Strength;  
        PetSpeed = Speed;
        CurrentXP = XP;
        CurrentLvl = Lvl;
        ResFire = FireRes;
        ResEarth = EarthRes;
        ResWater = WaterRes;
        ResAir = AirRes;
    }

    

}
