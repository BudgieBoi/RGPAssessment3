// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
// public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
// {
//     private Player player;
//     private Button button;
//
//     public void Initialize(Player player, Button button)
//     {
//         this.player = player;
//         this.button = button;
//     }
//
//     public void OnPointerEnter(PointerEventData eventData)
//     {
//         if (button.name == "GunButton") // Assuming your gun has a button for clicking
//         {
//             player.OnGunHoverEnter();
//         }
//         else
//         {
//             player.OnItemHoverEnter(button);
//         }
//     }
//
//     public void OnPointerExit(PointerEventData eventData)
//     {
//         if (button.name == "GunButton")
//         {
//             player.OnGunHoverExit();
//         }
//         else
//         {
//             player.OnItemHoverExit();
//         }
//     }
// }