using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] List<SpawnNode> _nodes;

    private void Update () {
        foreach (var node in _nodes) {
            node.Update ();
        }
    }

    public GameObject[] AllPrfabs;

    public void SetNodesParametrs (float New_Hp) {
        Debug.Log ("SetNodesParametrs() New_Hp="+New_Hp);
        foreach (var OneNode in _nodes) {
            OneNode.Hp = New_Hp;
            OneNode._prefab =AllPrfabs[UnityEngine.Random.Range (1, AllPrfabs.Length)];
        }
    }




    [Serializable]
    public class SpawnNode {
        [SerializeField] public float Hp;
        [SerializeField] public float Speed;
        [SerializeField] public int Damage;
        [SerializeField] public int reward_bread_new;
        [SerializeField] public int reward_exp_new;
        [SerializeField] public GameObject _prefab;
        [SerializeField] private Transform _startPoint; // Начальна точка спавна
        [SerializeField] private Transform _parent; // Роитель объекта
        [SerializeField] private float _spawnRate = 2; //Переодичность спавна мобов(2f=спавн каждых 2 секунды)

        private float _lastSpawnTime;

        private void Spawn () {
            _prefab.GetComponent<Zombi1> ()._hp = Hp;
            _prefab.GetComponent<Zombi1> ()._speed = Speed;
            _prefab.GetComponent<Zombi1> ()._damage = Damage;
            _prefab.GetComponent<Zombi1> ().reward_bread = reward_bread_new;
            _prefab.GetComponent<Zombi1> ().reward_exp = reward_exp_new;
            LeanPool.Spawn (_prefab, _startPoint.position, Quaternion.identity, _parent);
            // Instantiate (_prefab, _startPoint.position, Quaternion.identity, _parent);
        }
        public void Update () {
            var needSpawn = _lastSpawnTime < Time.time - _spawnRate;
            if (needSpawn) {
                _lastSpawnTime = Time.time;
                Spawn ();
            }
        }
    }

}