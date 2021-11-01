using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

using UnityEngine;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour, IRewardedVideoAdListener, IInterstitialAdListener
{
    public GameObject Bonus_Windows;
    [SerializeField]
    [TextArea]
    private string _appKey = "f632e5b41f6938dcc8a13d5282bf1bc9cbf49df97b85e220";
    [SerializeField]
    private string[] _networksFromDisable = { "facebook", "flurry", "inmobi", "amazon_ads", "yandex" };
    [SerializeField] private bool _isTesting = true;
    [SerializeField] private bool _muteVideosIfCallsMuted = true;
    [Header("События")]
    [SerializeField] private UnityEvent _onInitialized;
    [SerializeField] private UnityEventBool _onRewardedVideoLoaded;
    [SerializeField] private UnityEvent _onRewardedVideoFailedToLoad;
    [SerializeField] private UnityEvent _onRewardedVideoShown;
    [Tooltip("Когда видео закончилочь и можно дать награду")]
    [SerializeField] private UnityEventRewardedVideo _onRewardedVideoFinished;
    [SerializeField] private UnityEventBool _onRewardedVideoClosed;
    [SerializeField] private UnityEvent _onRewardedVideoExpired;
    [SerializeField] private UnityEvent _onRewardedVideoClicked;
    [SerializeField] private UnityEvent _onRewardedVideoShowFailed;
    public Info info_top_panel;

    private void Start()
    {
        Initialize(_isTesting);

    }

    private void Initialize(bool isTesting)
    {
        Appodeal.setTesting(isTesting); //Включаем тестовый режим
        Appodeal.muteVideosIfCallsMuted(_muteVideosIfCallsMuted); //Отключить звук в видео, если на телефоне отключен звук

        foreach (string network in _networksFromDisable)//отключаем не нужные сети
            Appodeal.disableNetwork(network);

        Appodeal.setRewardedVideoCallbacks(this);    // пометить этот класс как интерыейс для вызова коллбэков рекламы

        Appodeal.initialize(_appKey, Appodeal.REWARDED_VIDEO | Appodeal.INTERSTITIAL); //Показываем не пропускаемое видео

        _onInitialized.Invoke();
    }

    public void ShowAds()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }
    #region Реклама за награду! 

    public void onRewardedVideoLoaded(bool precache)
    {
        _onRewardedVideoLoaded.Invoke(precache);
    }
    public void onRewardedVideoFailedToLoad()
    {
        _onRewardedVideoFailedToLoad.Invoke();
    }
    public void onRewardedVideoShown()
    {
        _onRewardedVideoShown.Invoke();
    }
    /// <summary>
    ///  Когда видео закончилочь и можно дать награду,
    ///  Настравиается отдельно в Unity Dashboard
    /// </summary>
    /// <param name="amount">Сколько награда</param>
    /// <param name="name"> Имя награды</param>
    public void onRewardedVideoFinished(double amount, string name)
    {
        // _onRewardedVideoFinished.Invoke(amount, name);
        PlayerPrefs.SetInt("Bread", (PlayerPrefs.GetInt("Bread") + 1000));
        PlayerPrefs.SetInt("Tooth", (PlayerPrefs.GetInt("Tooth") + 200));
        info_top_panel.Draw_money(); //Обновить UI с валютами
        Bonus_Windows.SetActive(true); //Показать окно благодарности

    }
    public void onRewardedVideoClosed(bool finished)
    {
        _onRewardedVideoClosed.Invoke(finished);
    }
    public void onRewardedVideoExpired()
    {
        _onRewardedVideoExpired.Invoke();
    }
    public void onRewardedVideoClicked()
    {
        _onRewardedVideoClicked.Invoke();
    }

    public void onRewardedVideoShowFailed()
    {
        _onRewardedVideoShowFailed.Invoke();
    }
    #endregion


    public void ShowInterstitial()
    { //Проверка на загрузку рекламы
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
            Debug.Log("Показываю рекламу ADS Magaer");
        Debug.Log("Реклама загружена");
    }


    public void ShowNonSkippable()
    {
        if (Appodeal.isLoaded(Appodeal.NON_SKIPPABLE_VIDEO))
            Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
        Debug.Log("Просмотр рекламы.");
    }
    #region Не пропускаемая реклама

    public void onInterstitialLoaded(bool isPrecache)
    {
        // Вызывается, когда полноэкранная реклама загрузилась. Флаг precache указывает, является ли реклама прекешем.
        print("Interstitial loaded");
    }
    public void onInterstitialFailedToLoad()
    {
        // Вызывается, когда полноэкранная реклама не загрузилась
        print("Interstitial failed");
    }

    public void onInterstitialShowFailed()
    {
        // Вызывается, когда полноэкранная реклама загрузилась, но не может быть показана (внутренние ошибки сети, настройки плейсментов или неверный креатив)
        print("Interstitial show failed");
    }

    public void onInterstitialShown()
    {
        // Вызывается после показа полноэкранной рекламы
        print("Interstitial opened");
    }
    public void onInterstitialClosed()
    {
        // Вызывается при закрытии полноэкранной рекламы
        print("Interstitial closed");
    }
    public void onInterstitialClicked()
    {
        // Вызывается при клике на полноэкранную рекламу
        print("Interstitial clicked");
    }
    public void onInterstitialExpired()
    {
        // Вызывается, когда полноэкранная реклама больше не доступна.

        print("Interstitial expired");
    }
    #endregion

    [System.Serializable] private class UnityEventBool : UnityEvent<bool> { }
    [System.Serializable] private class UnityEventRewardedVideo : UnityEvent<double, string> { }







}