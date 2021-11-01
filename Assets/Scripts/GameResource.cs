using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResource : MonoBehaviour
{
    [SerializeField] private ResourcesManager.ResourceType _resourceType;
    [SerializeField] private ResourcesManager _resourcesManager;
    [SerializeField] private LevelStats _levelStats;
    [SerializeField] private int _count = 1;
    [SerializeField] private int _countByStep = 5;
    [SerializeField] private float _stepTime = 0.2f;
    private Camera _camera;

    [SerializeField] private AudioSource audioSource;
  public Vector3 PositionInUI => _camera.WorldToScreenPoint(transform.position);

    private void Awake()
    {
        _camera = Camera.main;
    // audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        Get();
        audioSource.Play();
    }
    public void Get()
    {
        StartCoroutine(cr_Get());
    }
    private IEnumerator cr_Get()
    {
        var wfs = new WaitForSeconds(_stepTime);

        for (int i = 0; i < _count; i++)
        {
            _resourcesManager.SpawnResource(_resourceType, PositionInUI);
            GetStat();
            yield return wfs;
        }
        yield return null;


        Destroy(gameObject);
    }

    private void GetStat()
    {
        switch (_resourceType)
        {
            case ResourcesManager.ResourceType.Coin: _levelStats.RewardInt("Bread", _countByStep); break;
            case ResourcesManager.ResourceType.Cube: _levelStats.RewardInt("Tooth", _countByStep); break;
        }
    }
}
