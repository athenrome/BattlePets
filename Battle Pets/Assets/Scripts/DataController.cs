using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataController : MonoBehaviour {

    GameController game;

    public TextAsset PetDataText;
    public TextAsset AbilityDataText;

    public List<Ability> AbilityList;
    public List<Pet> PetList;
    
    


	void Awake () {
        LoadPetData();
        LoadAbilityData();

        game = GameObject.FindObjectOfType<GameController>();

        
        
	}

   

    void LoadAbilityData()
    {

        List<AbilityData> RawAbilityData;

        System.IO.StringReader reader = new System.IO.StringReader(AbilityDataText.text);
        CsvHelper.CsvParser parser = new CsvHelper.CsvParser(reader);
        CsvHelper.CsvReader CsvReader = new CsvHelper.CsvReader(parser);
        CsvReader.Configuration.AutoMap<AbilityData>();

        RawAbilityData = CsvReader.GetRecords<AbilityData>().ToList();

        ProcessAbilityData(RawAbilityData);

    }

    void ProcessAbilityData(List<AbilityData> RawAbilityData)
    {

        Ability NewAbility;
        List<Ability> NewAbilityList = new List<Ability>();

        foreach(AbilityData RawAbility in RawAbilityData)
        {
            string Name = RawAbility.Name;
            ElementType ElementType = ChooseElement(RawAbility.ElementType);
            AttackType AttackType = ChooseAttackType(RawAbility.AttackType);
            int BaseDamage = ConvertToInt(RawAbility.BaseDamage);
            float RechargeTime = ConvertToFloat(RawAbility.RechargeTime);

            NewAbility = new Ability(Name, ElementType, AttackType, BaseDamage, RechargeTime);

            NewAbilityList.Add(NewAbility);
            
        }

        AbilityList = NewAbilityList;

        print("Loaded " + AbilityList.Count + "Abilities");
        

        
        
    }

    void LoadPetData()
    {

        List<PetData> RawPetData;

        System.IO.StringReader reader = new System.IO.StringReader(PetDataText.text);
        CsvHelper.CsvParser parser = new CsvHelper.CsvParser(reader);
        CsvHelper.CsvReader CsvReader = new CsvHelper.CsvReader(parser);
        CsvReader.Configuration.AutoMap<PetData>();

        RawPetData = CsvReader.GetRecords<PetData>().ToList();

        ProcessPetData(RawPetData);

    }

    void ProcessPetData(List<PetData> RawPetData)
    {
        Pet NewPet;

        List<Pet> NewPetList = new List<Pet>();

        foreach(PetData RawPet in RawPetData)
        {
            string PetName = RawPet.Name;
            ElementType ElementType = ChooseElement(RawPet.ElementType);
            int PetHealth = ConvertToInt(RawPet.Health);
            int PetStrength = ConvertToInt(RawPet.Strength);
            float PetSpeed = ConvertToFloat(RawPet.Speed);
            int CurrentXP = ConvertToInt(RawPet.Xp);
            int CurrentLvl = ConvertToInt(RawPet.Lvl);
            float FireRes = ConvertToFloat(RawPet.FireRes);
            float EarthRes = ConvertToFloat(RawPet.EarthRes);
            float WaterRes = ConvertToFloat(RawPet.WaterRes);
            float AirRes = ConvertToFloat(RawPet.AirRes);


            NewPet = new Pet(PetName, ElementType, PetHealth, PetStrength, PetSpeed, CurrentXP, CurrentLvl, FireRes, EarthRes, WaterRes, AirRes, ChooseAbilities(AbilityList));

            NewPetList.Add(NewPet);
            
            
        }

        PetList = NewPetList;
        print("Loaded " + PetList.Count + "Pets");

    }

    List<Ability> ChooseAbilities(List<Ability> LocalAbilityList)
    {
        List<Ability> PetAbilities = new List<Ability>();

        for(int i = 0; PetAbilities.Count < 4; i++)
        {
            int Chooser = Random.Range(0, LocalAbilityList.Count);
            PetAbilities.Add(LocalAbilityList[Chooser]);
            LocalAbilityList.Remove(LocalAbilityList[Chooser]);
        }

        return PetAbilities;
    }

    AttackType ChooseAttackType(string ToConvert)
    {

        AttackType NewPetAttack = AttackType.Default;

        switch (ToConvert)
        {
            case "Beam":
                NewPetAttack = AttackType.Beam;
                break;
            case "Heal":
                NewPetAttack = AttackType.Heal;
                break;
            case "Projectile":
                NewPetAttack = AttackType.Projectile;
                break;
            case "Melee":
                NewPetAttack = AttackType.Melee;
                break;
        }

        return NewPetAttack;

    }

    ElementType ChooseElement(string ToConvert)
    {

        ElementType NewPetElement = ElementType.Default;

        switch (ToConvert)
        {
            case "Air":
                NewPetElement = ElementType.Air;
                break;
            case "Earth":
                NewPetElement = ElementType.Earth;
                break;
            case "Fire":
                NewPetElement = ElementType.Fire;
                break;
            case "Water":
                NewPetElement = ElementType.Water;
                break;
        }

        return NewPetElement;
    }

    int ConvertToInt(string ToConvert)
    {
        int NewInt;

        NewInt = int.Parse(ToConvert);

        return NewInt;
    }


    float ConvertToFloat(string ToConvert)
    {
        float NewFloat;

        NewFloat = float.Parse(ToConvert);

        return NewFloat;
    }
}
