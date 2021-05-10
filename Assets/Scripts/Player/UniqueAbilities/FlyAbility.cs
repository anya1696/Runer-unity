using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAbility : AbilityModuleBase
{
    Player player;

    override public void RunEffect(){
        base.RunEffect();
        player.StartFly();
    }

    override public void Init(){
        base.Init();
        player = FindObjectOfType<Player>();
    }

    override public void EndEffect(){
        player.StopFly();
    }
}
