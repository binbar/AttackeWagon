using UnityEngine;
using AppodealAds.Unity.Api;
using UnityEngine.Events;

public class RewardedVideoIsLoadedController : MonoBehaviour
{
    
    public bool AdsInitted { get; set; }
    [SerializeField] private UnityEventIsLoaded _isLoaded;

    void Update()
    {
        if (AdsInitted)
        {
            bool isLoaded = Appodeal.isLoaded(Appodeal.REWARDED_VIDEO);
            _isLoaded.Invoke(isLoaded);
        }
    }
    [System.Serializable] public class UnityEventIsLoaded : UnityEvent<bool> { }
    
}
