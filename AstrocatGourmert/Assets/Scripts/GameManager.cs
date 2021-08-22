using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameLogic
{
    public class GameManager : MonoBehaviour
    {
        public enum Scene
        {
            MainScene,
            Cena1,
            EndScene,
            LoadingScene
        }
        
        [SerializeField] GameController gameController;
        [SerializeField] FoodController foodController;
        [SerializeField] GameObject eventSystem;
        [SerializeField] MenuNavigationController mainMenu;
        [SerializeField] GameOverMenuController gameOverMenu;
        [SerializeField] GameObject gameHud;
        [SerializeField] Dialog dialog;

        void OnEnable()
        {
            Time.timeScale = 1;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(gameController);
            DontDestroyOnLoad(foodController);
            DontDestroyOnLoad(gameHud);
            DontDestroyOnLoad(gameOverMenu);
            DontDestroyOnLoad(mainMenu);
            DontDestroyOnLoad(eventSystem);
            DontDestroyOnLoad(dialog);
            gameHud.SetActive(false);
            dialog.gameObject.SetActive(false);
            dialog.onDialogFinish += InitGame;
            gameOverMenu.onTouchAnyKey += LoadMainScene;
            EndGameMenuController.onTouchAnyKey += LoadMainScene;
            gameOverMenu.gameObject.SetActive(false);
        }

        void LoadMainScene()
        {
            mainMenu.gameObject.SetActive(true);
            gameOverMenu.gameObject.SetActive(false);
            Load(Scene.LoadingScene);
        }


        void Load(Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
        
        // Ao iniciar o jogo
        public void InitGame()
        {
            dialog.gameObject.SetActive(false);
            gameHud.SetActive(true);
            gameController.StartGame();
            foodController.SpawFoods();
        }

        public void InitDialog()
        {
            dialog.gameObject.SetActive(true);
            Load(Scene.Cena1);
            mainMenu.gameObject.SetActive(false);
        }

        // Ao finalizar o tempo
        public void GameOver()
        {
            foodController.CleanFoods();
            gameOverMenu.gameObject.SetActive(true);
            gameHud.SetActive(false);
        }

        // Ao achar todos os itens do mundo
        public void EndGame()
        {
            foodController.CleanFoods();
            mainMenu.gameObject.SetActive(false);
            gameHud.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
            gameController.StopGame();
            Load(Scene.EndScene);
        }
    }
}