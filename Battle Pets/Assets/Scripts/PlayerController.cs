using UnityEngine;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

    UIController GameUI;
    GameController game;
    EnemyController EnemyChar;
    public ChoosePetController PetChoose;
    public Player PlayerChar;
    public GameObject PetGameobject;
    public Pet CurrentPet;
    PetController PetCol;

    GameLogController Log;

    public float MoveSpeed = 4f;

    bool Cool1Active;
    int Cool1Time;

    bool Cool2Active;
    int Cool2Time;

    bool Cool3Active;
    int Cool3Time;

    bool Cool4Active;
    int Cool4Time;

    
	// Use this for initialization
	void Start () {
        game = GameObject.FindObjectOfType<GameController>();
        GameUI = GameObject.FindObjectOfType<UIController>();
        EnemyChar = GameObject.FindObjectOfType<EnemyController>();
        PetCol = GameObject.FindObjectOfType<PetController>();
        Log = GameObject.FindObjectOfType<GameLogController>();
        PetController petcol = GameObject.FindObjectOfType<PetController>();

        
        Cool1Active = false;
        Cool2Active = false;
        Cool3Active = false;
        Cool4Active = false;

        
        CurrentPet = PlayerChar.PlayerPets[0];

        
    

        GameUI.Ability1Txt.text = CurrentPet.PetAbilities[0].Name;
        GameUI.Ability2Txt.text = CurrentPet.PetAbilities[1].Name;
        GameUI.Ability3Txt.text = CurrentPet.PetAbilities[2].Name;
        GameUI.Ability4Txt.text = CurrentPet.PetAbilities[3].Name;

        PetCol.SetColour();

        
	}
	
    void StartGame()
    {
        
        if(CurrentPet == null)
        {
            ChoosePet();

            
            SpawnPet(CurrentPet);
            
        }
        else
        {
            StartPlayerTurn();
        }

        GameUI.Ability1Txt.text = CurrentPet.PetAbilities[0].Name;
        GameUI.Ability2Txt.text = CurrentPet.PetAbilities[1].Name;
        GameUI.Ability3Txt.text = CurrentPet.PetAbilities[2].Name;
        GameUI.Ability4Txt.text = CurrentPet.PetAbilities[3].Name;

        PetCol.SetColour();

    }

    void SpawnPet(Pet ToSpawn)
    {
        CurrentPet = ToSpawn;

        

        

        GameUI.Ability1Txt.text = CurrentPet.PetAbilities[0].Name;
        GameUI.Ability2Txt.text = CurrentPet.PetAbilities[1].Name;
        GameUI.Ability3Txt.text = CurrentPet.PetAbilities[2].Name;
        GameUI.Ability4Txt.text = CurrentPet.PetAbilities[3].Name;

        PetCol.SetColour();
    }

    public void StartPlayerTurn()
    {
        PetCol.SetColour();
        if(CurrentPet == null)
        {
            print("No Player Pet you must choose one");
            ChoosePet();
        }
        else
        {
            print("Player Start Turn");
            GameUI.UpdateUI();
        }
        
    }
    void EndPlayerTurn()
    {
        print("Player ended turn");
        CheckCooldowns();
        GameUI.UpdateUI();
        Log.NewLog("");
        EnemyChar.StartEnemyTurn();
        PetCol.SetColour();
    }
    public void ChoosePet()
    {
        PetChoose.Show();
        
        GameUI.UpdateUI();
        SpawnPet(CurrentPet);

        GameUI.Ability1Txt.text = CurrentPet.PetAbilities[0].Name;
        GameUI.Ability2Txt.text = CurrentPet.PetAbilities[1].Name;
        GameUI.Ability3Txt.text = CurrentPet.PetAbilities[2].Name;
        GameUI.Ability4Txt.text = CurrentPet.PetAbilities[3].Name;

        PetCol.SetColour();


        EndPlayerTurn();
    }
    void CheckCooldowns()
    {
        if (Cool1Active == true)
        {
            Cool1Time -= 1;
            if (Cool1Time <= 0)
            {
                
                GameUI.Ability1Txt.text = CurrentPet.PetAbilities[0].Name;
                Log.NewLog(CurrentPet.PetAbilities[0].Name + " Has recharged");
                Cool1Active = false;

            }
            else
            {
                
                GameUI.Ability1Txt.text = "Recharging: " + Cool1Time;
            }
            
        }

        if (Cool2Active == true)
        {
            Cool2Time -= 1;
            if (Cool2Time <= 0)
            {
                Cool2Active = false;
                GameUI.Ability2Txt.text = CurrentPet.PetAbilities[1].Name;
                Log.NewLog(CurrentPet.PetAbilities[1].Name + " Has recharged");
            }
            else
            {
                GameUI.Ability2Txt.text = "Recharging: " + Cool2Time;
            }
            
        }

        if (Cool3Active == true)
        {
            Cool3Time -= 1;
            if (Cool3Time <= 0)
            {
                Cool3Active = false;
                GameUI.Ability3Txt.text = CurrentPet.PetAbilities[2].Name;
                Log.NewLog(CurrentPet.PetAbilities[2].Name + " Has recharged");
            }
            else
            {
                

                GameUI.Ability3Txt.text = "Recharging: " + Cool3Time;
            }
            
        }

        if (Cool4Active == true)
        {
            Cool4Time -= 1;
            if (Cool4Time <= 0)
            {
                Cool4Active = false;
                GameUI.Ability4Txt.text = CurrentPet.PetAbilities[3].Name;
                Log.NewLog(CurrentPet.PetAbilities[3].Name + " Has recharged");
            }
            else
            {
                

                GameUI.Ability4Txt.text = "Recharging: " + Cool4Time;
            }
            
        }
    }
    public void ActivateAbility1()
    {
        if(Cool1Active == false)
        {
            print("Player uses: " + CurrentPet.PetAbilities[0].Name);
            AttackOpponent(CurrentPet.PetAbilities[0]);
            Cool1Active = true;
            Cool1Time = CurrentPet.PetAbilities[0].RechargeTime;
            EndPlayerTurn();
        }
        
        
    }
    public void ActivateAbility2()
    {
        if (Cool2Active == false)
        {
            print("Player uses: " + CurrentPet.PetAbilities[1].Name);
            AttackOpponent(CurrentPet.PetAbilities[1]);
            Cool2Active = true;
            Cool2Time = CurrentPet.PetAbilities[1].RechargeTime;
            EndPlayerTurn();
        }
    }
    public void ActivateAbility3()
    {
        if(Cool3Active == false)
        {
            print("Player uses: " + CurrentPet.PetAbilities[2].Name);
            AttackOpponent(CurrentPet.PetAbilities[2]);
            Cool3Active = true;
            Cool3Time = CurrentPet.PetAbilities[2].RechargeTime;
            EndPlayerTurn();
        }
    }
    public void ActivateAbility4()
    {
        if(Cool4Active == false)
        {
            print("Player uses: " + CurrentPet.PetAbilities[3].Name);
            AttackOpponent(CurrentPet.PetAbilities[3]);
            Cool4Active = true;
            Cool4Time = CurrentPet.PetAbilities[3].RechargeTime;
            EndPlayerTurn();
        }
    }
    void AttackOpponent(Ability ActiveAbility)
    {

        Log.NewLog("Player used: " + ActiveAbility.Name);

        if(ActiveAbility.AttackType == AttackType.Heal)
        {

            CurrentPet.PetHealth += (ActiveAbility.BaseDamage / 2);
            Log.NewLog("Healed: " + (ActiveAbility.BaseDamage / 2));
        }
        else
        {
            game.EnemyCharacter.RecieveAttack(ActiveAbility);
        }
        
    }
    public void RecieveAttack(Ability OpponentAttack)
    {


        


        float CurrElemRes = 0;


        switch (OpponentAttack.ElementType)
        {
            case ElementType.Air:
                CurrElemRes = CurrentPet.AirRes;
                //print("resistign against: air " + CurrElemRes);
                break;
            case ElementType.Earth:
                CurrElemRes = CurrentPet.EarthRes;
                //print("resistign against: Earth " + CurrElemRes);
                break;
            case ElementType.Fire:
                CurrElemRes = CurrentPet.FireRes;
                //print("resistign against: Fire " + CurrElemRes);
                break;
            case ElementType.Water:
                CurrElemRes = CurrentPet.WaterRes;
                //print("resistign against: Water " + CurrElemRes);
                break;
        }

        int DamageDealt = Mathf.RoundToInt((OpponentAttack.BaseDamage * CurrElemRes) / 100);

        CurrentPet.PetHealth -= DamageDealt;
        Log.NewLog("Enemy Dealt: " + DamageDealt + " Damage");
        CheckPet();
    }
    void CheckPet()
    {
        if (CurrentPet.PetHealth <= 0)
        {
            KillPet();
        }
    }

    void KillPet()
    {
        Log.NewLog(CurrentPet.PetName + " Has Died");
        PlayerChar.PlayerPets.Remove(CurrentPet);
        CurrentPet = null;

        if(PlayerChar.PlayerPets.Count <= 0)
        {
            game.GameOver();
        }

        SpawnPet(PlayerChar.PlayerPets[0]);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
