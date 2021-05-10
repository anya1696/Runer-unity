using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAbility : AbilityModuleBase
{
    public Player player;

    override public void ApplyEffect(){
        base.ApplyEffect();
        player.StartFly();
    }

    override public void DisableEffect(){
        player.StopFly();
    }
}
