using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {Spawning, Waiting, Counting }

    [System.Serializable]
    public class Wave
    {
        public string Name;
        public Transform EnemyType1;
        //public Transform EnemyType2;
       // public Transform Ammo;
        public int Count;
        //public int AmmoCount = 1;
        public float Rate;
    }

    public Wave[] Waves;
    private int NextWave = 0;

    public Transform[] SpawnPoints;

    public float TimeBetweenWaves = 5f;
    private float WaveCountDown;

    private float SearchCountDown = 1f;
    private SpawnState State = SpawnState.Counting;

    void Start()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.Log("No Spawn points found.");
        }

        WaveCountDown = TimeBetweenWaves; 


    }

    void Update()
    {
        if (State == SpawnState.Waiting)
        {
            //check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Start new wave
                WaveComplete();
                
            }else
            {
                return;
            }
        }



        if (WaveCountDown <= 0)
        {
            if (State != SpawnState.Spawning)
            {
                //Start Spawning Wave
                StartCoroutine(SpawnWave(Waves[NextWave]));
            }
        }
        else
        {
            WaveCountDown -= Time.deltaTime;
        }


        
    }

    void WaveComplete()
    {
        Debug.Log("Wave completed");
        State = SpawnState.Counting;
        WaveCountDown = TimeBetweenWaves;

        if (NextWave + 1 > Waves.Length - 1)
        {
            NextWave = 0;
            Debug.Log("ALL WAVES COMPLETE Looping...");
        }else
        {
            NextWave++;
        }
        
    }

    bool EnemyIsAlive()
    {
        SearchCountDown -= Time.deltaTime;
        if (SearchCountDown <= 0f)
        {
            SearchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _Wave)
    {

        // spawning enemies 
        State = SpawnState.Spawning;

        for (int x = 0; x < _Wave.Count; x++)
        {
            SpawnEnemy(_Wave.EnemyType1);
            yield return new WaitForSeconds(1f / _Wave.Rate);
        }

        //waiting for all enemies spawned to die
        State = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _Enemyone)
    {
        //spawns Enemy
        Debug.Log("Spawning enemies" + _Enemyone.name);


        Transform _SpawnPoints = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_Enemyone, _SpawnPoints.position, _SpawnPoints.rotation);
        //Instantiate(_Ammo, _SpawnPoints.position, _SpawnPoints.rotation);
        //Instantiate(_Enemytwo, _SpawnPoints.position, _SpawnPoints.rotation);

    }

}
