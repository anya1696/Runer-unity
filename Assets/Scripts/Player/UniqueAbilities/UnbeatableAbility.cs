using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbeatableAbility : AbilityModuleBase
{
    Player player;

    override public void RunEffect(){
        player.IsBeatable = false;
    }

    override public void Init(){
        base.Init();
        player = FindObjectOfType<Player>();
    }
}
