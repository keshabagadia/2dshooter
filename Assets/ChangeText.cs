// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// /// <summary>
// /// This class inherits from the UIelement class and handles the display of the high score
// /// </summary>
// public class ChangeText : UIelement
// {
//     [Tooltip("The text UI to use for display")]
//     public Text displayText = null;
//     int defeated, toDefeat;
//     Scene m_Scene;
//     string sceneName;
//     GameManager gameManager;

//     /// <summary>
//     /// Description:
//     /// Changes the high score display
//     /// Inputs:
//     /// none
//     /// Returns:
//     /// void (no return)
//     /// </summary>
//     void Start(){
//         gameManager = GameManager.instance();
//         defeated = gameManager.enemiesDefeated;
//         toDefeat =gameManager.enemiesToDefeat - defeated;
//         m_Scene = SceneManager.GetActiveScene();
//         sceneName = m_Scene.name;
//         UpdateUI();
//     }

//     public void UpdatePauseScreen()
//     {
//         if(displayText != null){
//             if(toDefeat>0){
//                 displayText.text = defeated.ToString() +" enemies killed.\n" + toDefeat.ToString() + " enemies left to kill.\n";
//             } else if(sceneName == "Level2"){
//                 if(!gameManager.powerUpCollected){
//                     displayText.text = "Enemy troops defeated, but the Boss Enemy looms.\n Tip: Make sure to collect the shield that \n he drops as he dies.";
//                 } else{
//                     displayText.text = "Hurry and fly away from the planet \n before the new troops come get you.";
//                 }
//             }else if(sceneName == "Level1"){
//                 if(!gameManager.powerUpCollected){
//                     displayText.text = "One of the enemy ships seem to \n have left a gun behind.";
//                 } else{
//                     displayText.text = "Quick, break free from the prison \n before they send more of the guards.";
//                 }
//             }
//         }        
//     }

//     /// <summary>
//     /// Description:
//     /// Overrides the virtual function UpdateUI() of the UIelement class and uses the DisplayHighScore function to update
//     /// Inputs:
//     /// none
//     /// Returns:
//     /// void (no return)
//     /// </summary>
//     public override void UpdateUI()
//     {
//         // This calls the base update UI function from the UIelement class
//         base.UpdateUI();

//         // The remaining code is only called for this sub-class of UIelement and not others
//         UpdatePauseScreen();
//     }
// }
