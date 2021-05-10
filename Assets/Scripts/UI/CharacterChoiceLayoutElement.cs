﻿using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceLayoutElement : MonoBehaviour
{
   public MeshRenderer model;
   public Text desctiprion;
   Player player;

   public void OnChoise(){
      EventManager.MainEventBus.Publish(new PlayerChoisen(Player));
   }

   public Player Player{
      get{
         return player;
      }
      set{
         player = value;
         model = Player.model3d;
         desctiprion.text = Player.Description;
      }
   }
}