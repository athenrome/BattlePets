using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    GameController game;
    public Enemy Character;
    public GameObject PetGameobject;
    public Pet CurrentPet;
    UIController GameUI;
    PlayerController PlayerChar;
    PetController petcol;
    GameLogController Log;

    bool Cool1Active;
    int Cool1Time;

    bool Cool2Active;
    int Cool2Time;

    bool Cool3Active;
    int Cool3Time;

    bool Cool4Active;
    int Cool4Time;

    // Use this for initialization
    void Start()
    {
        GameUI = GameObject.FindObjectOfType<UIController>();
        game = GameObject.FindObjectOfType<GameController>();
        PlayerChar = GameObject.FindObjectOfType<PlayerController>();
        Log = GameObject.FindObjectOfType<GameLogController>();

        petcol = GameObject.FindObjectOfType<PetController>();
        
        CurrentPet = Character.CurrentPet;

        //petcol.SetColour();
        

        Cool1Active = false;
        Cool2Active = false;
        Cool3Active = false;
        Cool4Active = false;

        GameUI.UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartEnemyTurn()
    {
        print("Enemy Start Turn");
        GameUI.UpdateUI();
        AIActions();
        
    }

    void EndEnemyTurn()
    {
        print("Enemy ended turn");
        CheckCooldowns();
        GameUI.UpdateUI();
        Log.NewLog("");
        PlayerChar.StartPlayerTurn();
    }

    void AIActions()
    {
        int ChooseAbility = Random.Range(0, CurrentPet.PetAbilities.Count);

        if(Cool1Active == true && Cool2Active == true && Cool3Active == true && Cool4Active == true)
        {
            EndEnemyTurn();
        }
        
        
            switch (ChooseAbility)
            {

                case 0:
                    if (Cool1Active == false)
                    {
                        ActivateAbility1();
                    }
                    else
                    {
                        AIActions();
                    }
                    
                    break;
                case 1:
                    if (Cool2Active == false)
                    {
                        ActivateAbility2();
                    }
                    else
                    {
                        AIActions();
                    }
                    
                    break;
                case 2:
                    if (Cool3Active == false)
                    {
                        ActivateAbility3();
                    }
                    else
                    {
                        AIActions();
                    }
                    
                    break;
                case 3:
                    if (Cool4Active == false)
                    {
                        ActivateAbility4();
                    }
                    else
                    {
                        AIActions();
                    }
                    
                    break;
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
        Log.NewLog("Player Dealt: " + DamageDealt + " Damage");
        

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
        CurrentPet = null;
        game.GameOver();
    }

    
    void AttackOpponent(Ability ActiveAbility)
    {
        Log.NewLog("Enemy used: " + ActiveAbility.Name);
        if(ActiveAbility.AttackType == AttackType.Heal)
        {
            CurrentPet.PetHealth += (ActiveAbility.BaseDamage / 2);
            Log.NewLog("Healed: " + (ActiveAbility.BaseDamage / 2));
        }
        else
        {
            game.PlayerCharacter.RecieveAttack(ActiveAbility);
        }
        
    }
        
    

    void CheckCooldowns()
    {
        if (Cool1Active == true)
        {
            Cool1Time -= 1;
            if (Cool1Time <= 0)
            {
                

                Cool1Active = false;

            }
            else
            {

                //GameUI.Ability1Txt.text = "Recharging: " + Cool1Time;
            }

        }

        if (Cool2Active == true)
        {
            Cool2Time -= 1;
            if (Cool2Time <= 0)
            {
                Cool2Active = false;

            }
            else
            {
                //GameUI.Ability2Txt.text = "Recharging: " + Cool2Time;
            }

        }

        if (Cool3Active == true)
        {
            Cool3Time -= 1;
            if (Cool3Time <= 0)
            {
                Cool3Active = false;

            }
            else
            {


                //GameUI.Ability3Txt.text = "Recharging: " + Cool3Time;
            }

        }

        if (Cool4Active == true)
        {
            Cool4Time -= 1;
            if (Cool4Time <= 0)
            {
                Cool4Active = false;

            }
            else
            {


                //GameUI.Ability4Txt.text = "Recharging: " + Cool4Time;
            }

        }
    }

    public void ActivateAbility1()
    {
        if (Cool1Active == false)
        {
            print("Enemy uses: " + CurrentPet.PetAbilities[0].Name);
            AttackOpponent(CurrentPet.PetAbilities[0]);
            Cool1Active = true;
            Cool1Time = CurrentPet.PetAbilities[0].RechargeTime;
            EndEnemyTurn();
        }


    }

    public void ActivateAbility2()
    {
        if (Cool2Active == false)
        {
            print("Enemy uses: " + CurrentPet.PetAbilities[1].Name);
            AttackOpponent(CurrentPet.PetAbilities[1]);
            Cool2Active = true;
            Cool2Time = CurrentPet.PetAbilities[1].RechargeTime;
            EndEnemyTurn();
        }
    }

    public void ActivateAbility3()
    {
        if (Cool3Active == false)
        {
            print("Enemy uses: " + CurrentPet.PetAbilities[2].Name);
            AttackOpponent(CurrentPet.PetAbilities[2]);
            Cool3Active = true;
            Cool3Time = CurrentPet.PetAbilities[2].RechargeTime;
            EndEnemyTurn();
        }
    }

    public void ActivateAbility4()
    {
        if (Cool4Active == false)
        {
            print("Enemy uses: " + CurrentPet.PetAbilities[3].Name);
            AttackOpponent(CurrentPet.PetAbilities[3]);
            Cool4Active = true;
            Cool4Time = CurrentPet.PetAbilities[3].RechargeTime;
            EndEnemyTurn();
        }
    }

}
