using System.Collections.Generic;
using Controllers;
using Model;
using Model.Shop;
using Tools.Ads;
using UnityEngine;

public class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly IShop _shop;
    
    private MainMenuController _mainMenuController;
    private GameController _gameController;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, IAdsShower adsShower, IShop shop)
    {
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _shop = shop;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _adsShower, _shop);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _profilePlayer.Analytic.SendMessage("StartGameActivity", new Dictionary<string, object>());
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}
