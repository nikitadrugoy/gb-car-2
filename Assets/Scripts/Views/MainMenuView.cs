using System;
using Model.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buyButton;
        [SerializeField] private ShopProduct _shopProduct;
        
        public void Init(UnityAction startGame, Action<ShopProduct> itemBought)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buyButton.onClick.AddListener(() =>
            {
                Debug.Log(1);
                itemBought.Invoke(_shopProduct);
            });
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buyButton.onClick.RemoveAllListeners();
        }
    }
}

