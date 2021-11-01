using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class ChunksPavozka : MonoBehaviour {
    public Transform Povozka;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk> ();
    public bool Stoppovozka = true; //Состояние повозки,true если жива

    private void Start () {
        spawnedChunks.Add (FirstChunk);
    }
    private void Update () {

        if (Stoppovozka == true) {
            if (Povozka.position.x < spawnedChunks[spawnedChunks.Count - 1].End.position.x) {
                SpawnChunks ();
            }
        }

    }
    private void SpawnChunks () {
        Chunk newChunk = LeanPool.Spawn(ChunkPrefabs[Random.Range (0, ChunkPrefabs.Length)]); //Создание обьекта
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].Begin.position - newChunk.End.localPosition; //Установка позиции
        spawnedChunks.Add (newChunk);
        if (spawnedChunks.Count >= 5) {
            LeanPool.Despawn(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}