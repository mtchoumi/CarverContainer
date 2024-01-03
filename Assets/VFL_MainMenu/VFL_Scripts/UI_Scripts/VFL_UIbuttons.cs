using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VFL_UIbuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton(){
        SceneManager.LoadScene("VFL_TrueCCGame");
    }
    public void InstructionsButton(){
        SceneManager.LoadScene("VFL_Instructions");
    }
    public void BackBtnOne(){
        SceneManager.LoadScene("VFL_MainMenu");
    }
    public void MainMenuBtn(){
        SceneManager.LoadScene("VFL_MainMenu");
        VFL_PlayerHealthDisplay.playerHealth = 250;
        VFL_HealthDisplay.bossHealth = 600;
    }
    public void LoadingBtn(){
        QuickPlay.nextScene();
        VFL_PlayerHealthDisplay.playerHealth = 250;
        VFL_HealthDisplay.bossHealth = 600;
    }
}
