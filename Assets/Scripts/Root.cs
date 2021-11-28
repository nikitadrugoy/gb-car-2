using System.Collections.Generic;
using Model;
using Model.Analytic;
using Tools.Ads;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private UnityAdsTools _adsTools;
    
    private MainController _mainController;

    private void Awake()
    {
        var analytics = new UnityAnalyticTools();
        var profilePlayer = new ProfilePlayer(15f, analytics);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _adsTools);
        analytics.SendMessage("GameStart", new Dictionary<string, object>());
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
