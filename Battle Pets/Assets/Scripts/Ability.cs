using UnityEngine;
using System.Collections;

public class Ability
{

    public string Name;
    public ElementType ElementType;
    public AttackType AttackType;
    public int BaseDamage;
    public int RechargeTime;

    // Use this for initialization
    public Ability(string AbilName, ElementType EltType, AttackType AttType, int BaseDam, int Recharge)
    {
        Name = AbilName;
        ElementType = EltType;
        AttackType = AttType;
        BaseDamage = BaseDam;
        RechargeTime = Recharge;

    }
}
