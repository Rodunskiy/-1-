using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _monster;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Transform _target;

    private int randPosition;
    private float _coolDown = 2.0f;
    private bool _isSpawnerWork = true;

    private void Start()
    {
        StartCoroutine(SpawnDalayRoutine());       
    }

    private void OnDisable()
    {
        _isSpawnerWork = false;
        StopCoroutine(SpawnDalayRoutine());
    }

    private IEnumerator SpawnDalayRoutine()
    {
        while (_isSpawnerWork)
        {
            randPosition = Random.Range(0, _spawnPoint.Length);
            Transform randomSpawnPoint = _spawnPoint[randPosition];
            EnemyMover temporaryMonster = Instantiate(_monster, randomSpawnPoint.position, Quaternion.identity);
            temporaryMonster.SetTarget(_target.position);

            yield return new WaitForSeconds(_coolDown);
        }
    }
}
