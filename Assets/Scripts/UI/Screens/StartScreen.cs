using UnityEngine;
using UnityEngine.UI;

public class StartScreen : ScreenBase
{
    public CharacterChoiceLayout characterChoiceLayout;
    public Button button;

    public override void Init(){
        characterChoiceLayout.Init();
        EventManager.MainEventBus.Subscribe<PlayerChoisen>(OnChosePlayer);
    }

    public void OnChosePlayer(PlayerChoisen e){
        button.gameObject.SetActive(true);
    }

}
