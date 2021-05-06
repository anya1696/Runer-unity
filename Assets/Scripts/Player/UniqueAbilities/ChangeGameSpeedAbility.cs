using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameSpeedAbility : AbilityModuleBase
{
    public GameSpeed changeGameSpeedTo = GameSpeed.Max;
    override public void RunEffect(){
        EventManager.MainEventBus.Publish(new ChangeGameSpeed(changeGameSpeedTo));
    }

}
