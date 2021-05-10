using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbeatableAbility : AbilityModuleBase
{
    public Player player;

    override public void ApplyEffect(){
        player.IsBeatable = false;
    }
}
