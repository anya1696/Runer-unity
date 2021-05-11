using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceLayoutElement : MonoBehaviour
{
   public MeshRenderer model;
   public Text desctiprion;
   Player player;

   public void OnChoise(){
      EventManager.MainEventBus.Publish(new PlayerChosen(Player));
   }

   public Player Player{
      get{
         return player;
      }
      set{
         player = value;
         model.GetComponent<MeshFilter>().mesh = Player.model3d.GetComponent<MeshFilter>().sharedMesh;
         //model = Player.model3d;
         desctiprion.text = Player.Description;
      }
   }
}
