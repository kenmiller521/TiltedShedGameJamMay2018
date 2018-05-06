using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// handles the collectables for the scene
/// Joel Lee
/// </summary>
public class CollectablesHandler_NET : NetworkBehaviour {
    public CollectableObject ObjectToSpawn;
    public float SizeOfArena = 10f;
    public int MaxSpawnAmount = 15;
    public float SpawnDelay = 5f;
    private int _spawnedCount = 0;

    void Awake() {
        if (isServer) {
            for (int i = 0; i < MaxSpawnAmount; i++) {
                SpawnCollectable();
            }
            InvokeRepeating("SpawnCollectable", 5f, 5f);
        }
    }

    /// <summary>
    /// spawn a collectable in a random location
    /// </summary>
    public void SpawnCollectable() {
        if (_spawnedCount < MaxSpawnAmount) {
            Vector3 rand = new Vector3(Random.insideUnitCircle.x * SizeOfArena, Random.insideUnitCircle.y * SizeOfArena, 0);
            CollectableObject go = Instantiate(ObjectToSpawn, rand, Quaternion.identity);
            go.OnPickUp += LowerSpawnCount;
            NetworkServer.Spawn(go.gameObject);
            _spawnedCount++;
        }
    }

    /// <summary>
    /// spawn a collectable in a specific location
    /// </summary>
    /// <param name="position"></param> where it will spawn
    /// <param name="overflow></param> will it overflow?
    public void SpawnCollectable(Vector2 position) {
        CollectableObject go = Instantiate(ObjectToSpawn, position, Quaternion.identity);
        go.OnPickUp += LowerSpawnCount;
        NetworkServer.Spawn(go.gameObject);
    }

    /// <summary>
    /// receives event to lower the amount of collectables
    /// </summary>
    void LowerSpawnCount() {
        _spawnedCount--;
    }
}
