using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public GameController game;
    public Enemy Character;
    public GameObject PetGameobject;
    Pet CurrentPet;

    // Use this for initialization
    void Start()
    {
        game = GameObject.FindObjectOfType<GameController>();
        
        CurrentPet = Character.CurrentPet;
        print(CurrentPet.PetName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecieveAttack(Ability OpponentAttack)
    {


        CurrentPet = Character.CurrentPet;
        print(OpponentAttack.BaseDamage);

        float CurrElemRes = 0;
        print(CurrentPet.AirRes + "asdf");

        switch (OpponentAttack.ElementType)
        {
            case ElementType.Air:
                CurrElemRes = CurrentPet.AirRes;
                print("resistign against: air " + CurrElemRes);
                break;
            case ElementType.Earth:
                CurrElemRes = CurrentPet.EarthRes;
                print("resistign against: Earth " + CurrElemRes);
                break;
            case ElementType.Fire:
                CurrElemRes = CurrentPet.FireRes;
                print("resistign against: Fire " + CurrElemRes);
                break;
            case ElementType.Water:
                CurrElemRes = CurrentPet.WaterRes;
                print("resistign against: Water " + CurrElemRes);
                break;
        }

        
        print("dam asdhfkjsad" + (OpponentAttack.BaseDamage * CurrElemRes));

        //CurrentPet.PetHealth -= (OpponentAttack.BaseDamage *);
    }
}
