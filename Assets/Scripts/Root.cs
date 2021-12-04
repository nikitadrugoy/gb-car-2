using System.Collections.Generic;
using Model;
using Model.Analytic;
using Model.Shop;
using Tools.Ads;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _adsTools;
    [SerializeField] private List<ShopProduct> _shopProducts;
    
    private MainController _mainController;

    private void Awake()
    {
        var analytics = new UnityAnalyticTools();
        var profilePlayer = new ProfilePlayer(15f, analytics);
        var shop = new ShopTools(_shopProducts);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _adsTools, shop);
        analytics.SendMessage("GameStart", new Dictionary<string, object>());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
