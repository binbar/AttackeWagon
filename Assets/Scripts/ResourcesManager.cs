using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Lean.Pool;
using UnityEngine;
using System;

public class ResourcesManager : MonoBehaviour
{
    public enum ResourceType { Coin, Cube }
    public enum DetectionMode { Detect2D, Detect3D }

    public UI_controller drawStats;

    public static int coins;
    public static int cubes;

    public void SpawnResource(ResourceType resourceType, Vector3 startPoint)
    {
        switch (resourceType)
        {
            case ResourceType.Coin: SpawnCoin(startPoint); break;
            case ResourceType.Cube: SpawnCube(startPoint); break;
        }
    }

    public const string PLAYER_PREFS_KEY_COINS = "COINS";
    public const string PLAYER_PREFS_KEY_CUBES = "CUBES";
    [Header("UI References")]
    public Transform targetCanvas;
    [Space(5)]
    public RectTransform coinIcon;
    public TextMeshProUGUI coinCounterTMPro;

    [Space(4)]
    [SerializeField] private RectTransform cubeIcon;
    [SerializeField] private  TextMeshProUGUI cubeCounterTMPro;

    [Header("Prefabs")]
    [SerializeField] private FlyingIcon coinAnimatedPrefab;
    [SerializeField] private FlyingIcon cubeAnimatedPrefab;

    [Header("Settings")]
    public DetectionMode detectionMode = DetectionMode.Detect3D;
    public bool useMouse = true;
    public bool useTouch = true;

    [Space(5)]
    public float animatonDuration = 1f;
    public Ease animationEase = Ease.Linear;

    private GameResource gameResource;

    public GameObject zombiPosition;

    private void Start()
    {
        coins = PlayerPrefs.GetInt(PLAYER_PREFS_KEY_COINS, 0);
        cubes = PlayerPrefs.GetInt(PLAYER_PREFS_KEY_CUBES, 0);
        UpdateResourceCounter(ResourceType.Coin);
        UpdateResourceCounter(ResourceType.Cube);
    }

    private void OnDisable()
    {
        SaveResourcesToPlayPrefebs();
    }

    private void SaveResourcesToPlayPrefebs()
    {
        PlayerPrefs.SetInt(PLAYER_PREFS_KEY_COINS, coins);
        PlayerPrefs.SetInt(PLAYER_PREFS_KEY_COINS, cubes);
        PlayerPrefs.Save();
    }

    //запуск монет
    public void SpawnCoin(Vector3 startPoint)
    {
        ExecutePickup(startPoint, coinAnimatedPrefab, null, coinIcon);
    }

    public void SpawnCube(Vector3 startPoint)
    {
        ExecutePickup(startPoint, cubeAnimatedPrefab, null, cubeIcon);
    }

    
    public void OnDestroy (){
        transform.DOKill();
    }
      //Запуск анимации
    private void ExecutePickup(Vector3 startPoint, FlyingIcon resourcePrefab, GameObject resourceEffectPrefab, RectTransform resrouceIcon)
    {
        var icon = LeanPool.Spawn(resourcePrefab, startPoint, Quaternion.identity, targetCanvas);

        Action animateResourceIsonAction = () =>
               {
                   resrouceIcon
                       .DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.4f)
                       .OnComplete(() => resrouceIcon.localScale = Vector3.one)
                       .Play();
                   drawStats.DrawStats();
               };

        icon.Fly(resrouceIcon, animateResourceIsonAction);

        // startPoint.gameObject.SetActive(false);
    }

    public void Animation_tooth(int some_data_int)
    {
        cubeCounterTMPro.text = "" + some_data_int;
        cubeCounterTMPro.rectTransform.DOPunchScale(new Vector3(0.15f, 0.15f, 0f), 0.4f)
            .OnComplete(() =>
            {
                cubeCounterTMPro.rectTransform.localScale = Vector3.one;

            })
            .Play();
    }

    public void Animation_bread(int some_data_int)
    {
        coinCounterTMPro.text = "" + some_data_int;
        coinCounterTMPro.rectTransform.DOPunchScale(new Vector3(0.15f, 0.15f, 0f), 0.4f)
            .OnComplete(() =>
            {
                coinCounterTMPro.rectTransform.localScale = Vector3.one;

            })
            .Play();
    }

    private void UpdateResourceCounter(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Coin:
                coinCounterTMPro.text = coins.ToString();
                coinCounterTMPro.rectTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.4f)
                    .OnComplete(() =>
                    {
                        coinCounterTMPro.rectTransform.localScale = Vector3.one;

                    })
                    .Play();
                break;
            case ResourceType.Cube:
                coinCounterTMPro.text = cubes.ToString();
                coinCounterTMPro.rectTransform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), 0.4f)
                    .OnComplete(() =>
                    {
                        coinCounterTMPro.rectTransform.localScale = Vector3.one;

                    })
                    .Play();
                break;
        }
    }
}