using UnityEngine;
using UnityEngine.UI;

public class StartScreen : ScreenBase
{
    public CharacterChoiceLayout characterChoiceLayout;
    public Button button;

    public override void Init(){
        base.Init();
        characterChoiceLayout.Init();
        EventManager.MainEventBus.Subscribe<PlayerChosen>(OnChosePlayer);
    }

    public void OnChosePlayer(PlayerChosen e){
        button.gameObject.SetActive(true);
    }

}
