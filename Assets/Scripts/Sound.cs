using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject ShootPrefab, Footsteps2Prefab, GasEmitPrefab, MenuMoveLongPrefab, MenuMoveShortPrefab, MenuSelectPrefab,
        MoneyGetPrefab, PitchforkThrowPrefab, PlayerDamagedPrefab, ShotgunTowerShoot2Prefab, TowerDestroyPrefab, TowerPlace1Prefab,
        WaveIncomingPrefab;
    public float DestroyTime;
   
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSound(string SFXPlay)
    {
        switch (SFXPlay)
        {
            case "Shoot": //Shooting.cs
                GameObject shoot = Instantiate(ShootPrefab);
                Destroy(shoot, DestroyTime);
                break;
            case "Footsteps2": //
                GameObject footsteps2 = Instantiate(Footsteps2Prefab);
                Destroy(footsteps2, DestroyTime);
                break;
            case "Gas_Emit": //
                GameObject gasEmit = Instantiate(GasEmitPrefab);
                Destroy(gasEmit, DestroyTime);
                break;
            case "MenuMoveLong": //
                GameObject menuMoveLong = Instantiate(MenuMoveLongPrefab);
                Destroy(menuMoveLong, DestroyTime);
                break;
            case "MenuMoveShort": //
                GameObject menuMoveShort = Instantiate(MenuMoveShortPrefab);
                Destroy(menuMoveShort, DestroyTime);
                break;
            case "MenuSelect": //
                GameObject menuSelect = Instantiate(MenuSelectPrefab);
                Destroy(menuSelect, DestroyTime);
                break;
            case "MoneyGet": //CurrencyManager.cs
                GameObject moneyGet = Instantiate(MoneyGetPrefab);
                Destroy(moneyGet, DestroyTime);
                break;
            case "PitchforkThrow": //
                GameObject pitchforkThrow = Instantiate(PitchforkThrowPrefab);
                Destroy(pitchforkThrow, DestroyTime);
                break;
            case "PlayerDamaged": //PlayerHealth.cs
                GameObject playerDamaged = Instantiate(PlayerDamagedPrefab);
                Destroy(playerDamaged, DestroyTime);
                break;
            case "ShotgunTowerShoot2": //
                GameObject shotgunTowerShoot2 = Instantiate(ShotgunTowerShoot2Prefab);
                Destroy(shotgunTowerShoot2, DestroyTime);
                break;
            case "TowerDestroy": //TowerHealth.cs
                GameObject towerDestroy = Instantiate(TowerDestroyPrefab);
                Destroy(towerDestroy, DestroyTime);
                break;
            case "TowerPlace1": //BuildManager.cs
                GameObject towerPlace1 = Instantiate(TowerPlace1Prefab);
                Destroy(towerPlace1, DestroyTime);
                break;
            case "WaveIncoming": //EnemyController.cs
                GameObject waveIncoming = Instantiate(WaveIncomingPrefab);
                Destroy(waveIncoming, DestroyTime);
                break;

        }

    }
}
