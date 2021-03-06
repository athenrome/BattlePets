﻿using UnityEngine;
using System.Collections.Generic;

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
    public List<Ability> PetAbilities;

    public Pet(string Name, ElementType EleType, int Health, int Strength, float Speed,  int XP, int Lvl, float ResFire, float ResEarth, float ResWater, float ResAir, List<Ability>Abilities)
    {
        PetName = Name;
        ElementType = EleType;
        PetHealth = Health;
        PetStrength = Strength;  
        PetSpeed = Speed;
        CurrentXP = XP;
        CurrentLvl = Lvl;
        FireRes = ResFire;
        EarthRes = ResEarth;
        WaterRes = ResWater;
        AirRes = ResAir;
        PetAbilities = Abilities;
    }

    

}
