using System.Runtime.CompilerServices;
using Controllers;
using Model;
using Model.Shop;
using Tools;
using Tools.Ads;
using UnityEngine;
using Views;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly IShop _shop;
    private readonly MainMenuView _view;

    private ShopProduct _currentShopProduct;

    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower, IShop shop)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _shop = shop;
        _view = LoadView(placeForUi);
        _view.Init(StartGame, BuyItem);

        _shop.OnSuccessPurchase += OnItemBought;
    }
    
    private MainMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        
        return objectView.GetComponent<MainMenuView>();
    }

    private void ShowAddRequested()
    {
        _adsShower.ShowVideo(OnVideoShowSuccess);
    }

    private void OnVideoShowSuccess()
    {
        // Add model reward
    }

    private void BuyItem(ShopProduct item)
    {
        _currentShopProduct = item;
        _shop.Buy(item.Id);
    }

    private void OnItemBought()
    {
        _profilePlayer.Gold.Value += _currentShopProduct.Amount;
        
        Debug.Log(_profilePlayer.Gold.Value);
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}

