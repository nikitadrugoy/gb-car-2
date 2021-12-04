using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Model.Shop
{
    [CreateAssetMenu(fileName = "ShopProduct", menuName = "Config/ShopProduct", order = 0)]
    public class ShopProduct : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private ProductType _productType;
        [SerializeField] private int _amount;

        public string Id => _id;
        public ProductType ProductType => _productType;
        public int Amount => _amount;
    }
}