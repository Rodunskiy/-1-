using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Transform _target;

    private int randPosition;
    private float _coolDown = 2.0f;
    private float _timeLeft;

    private void Start()
    {
        _timeLeft = _coolDown;
    }

    private void Update()
    {
        SpawnEnemyEveryTwoSecond();
    }

    private void SpawnEnemyEveryTwoSecond()
    {
        Transform temporarySpawnPoint = null;
        _timeLeft -= Time.deltaTime;

        if (_timeLeft <= 0)
        {
            _timeLeft = _coolDown;
            randPosition = Random.Range(0, _spawnPoint.Length);
            temporarySpawnPoint = _spawnPoint[randPosition];
            GameObject temporaryMonster = Instantiate(_monster, temporarySpawnPoint.transform.position, Quaternion.identity);

            temporaryMonster.GetComponent<Movement>().SetTarget(_target.position);
        }
    }
}
