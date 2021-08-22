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

        void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        //Fazer aparecer aleatoriamente no mapa
        public void SpawFoods()
        {
            foreach (var food in _foodList)
            {
                var instantiate = Instantiate(food.foodObject,transform);
                instantiate.transform.position = RandomPosition();
                instantiate.SetActive(true);
            }
        }

        Vector3 RandomPosition()
        {
            var x = Random.Range(-10, 10);
            var y = Random.Range(0, 2);
            var z = Random.Range(-10, 10);

            return new Vector3(x, y, z);
        }

        // Chamar sempre ao colidir em uma comida
        //Ao completar as 5 ir para o EndGame. 
        public void CheckIfEnds(string foodName)
        {
            foreach (var food in _collectFoods.Where(food => food.foodName.ToString() == foodName))
            {
                food.imageFood.sprite = food.activeFoodSprite;
            }
            
            foreach (var food in _foodList.Where(food => food.foodName.ToString() == foodName))
            {
                food.collected = true;
                food.foodObject.SetActive(false);
            }
            
            if (_foodList.Any(food => !food.collected))
            {
                return;
            }

            _gameManager.EndGame();
        }
    }
}