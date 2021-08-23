using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class FoodController: MonoBehaviour
    {
        [Serializable]
        public enum FoodName
        {
            OlhoEnguia,
            GeleiaMorango,
            OvoDragao,
            Cogumelos,
            Algas,
            Cenoura
        }
        
        [Serializable]
        class Food
        {
            public GameObject foodObject;
            public FoodName foodName;
            public bool collected = false;
        }
        
        [Serializable]
        class CollectFood
        {
            public FoodName foodName;
            public Image imageFood;
            public Sprite activeFoodSprite;
        }
        
        [SerializeField] List<Food> _foodList;
        [SerializeField] List<CollectFood> _collectFoods;
        [SerializeField] GameManager _gameManager;
        AudioManager _audioManager;

        List<GameObject> foods;

        void OnEnable()
        {
            foods = new List<GameObject>();
            DontDestroyOnLoad(gameObject);
            _audioManager = FindObjectOfType<AudioManager>();
        }
        
        //Fazer aparecer aleatoriamente no mapa
        public void SpawFoods()
        {
            foreach (var food in _foodList)
            {
                var instantiate = Instantiate(food.foodObject,transform);
                SetPosition(instantiate);
                instantiate.SetActive(true);
                foods.Add(instantiate.gameObject);
            }
        }

        void SetPosition(GameObject gameeObject)
        {
            if (gameeObject.name.Contains("Ovo"))
            {
                gameeObject.transform.position = new Vector3(-20.73f, 0.3f, -16.04f);
            }
            if (gameeObject.name.Contains("Geleia"))
            {
                gameeObject.transform.position = new Vector3(-5, 0.26f, 2.38f);
            }
            if (gameeObject.name.Contains("Cenoura"))
            {
                gameeObject.transform.position = new Vector3(16.05f, 2.14f, -14.96f);
            }
            if (gameeObject.name.Contains("Algas"))
            {
                gameeObject.transform.position = new Vector3(-12.97f, 2.28f, 25.29f);
            }
            if (gameeObject.name.Contains("Olho"))
            {
                gameeObject.transform.position = new Vector3(6.96f, 0.31f, 10.2f);
            }
        }

        // Chamar sempre ao colidir em uma comida
        //Ao completar as 5 ir para o EndGame. 
        public void CheckIfEnds(string foodName)
        {
            foreach (var food in _collectFoods.Where(food => food.foodName.ToString() == foodName))
            {
                food.imageFood.sprite = food.activeFoodSprite;
                _audioManager.Play("collect");
            }
            
            foreach (var food in _foodList.Where(food => food.foodName.ToString() == foodName))
            {
                food.collected = true;
                
            }
            
            if (_foodList.Any(food => !food.collected))
            {
                return;
            }

            _gameManager.EndGame();
        }

        public void CleanFoods()
        {
            foreach (var food in foods)
            {
                Destroy(food);
            }
        }
    }
}