using System;
using UnityEngine;

public enum GameState { MAINMENU, GAMEPLAY, ARRANGE, START, FINISH }

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Vector2 minCamPos, maxCamPos;
    [SerializeField] int level;
    public int Level => level;
    public Vector2 MinCamPos => minCamPos;
    public Vector2 MaxCamPos => maxCamPos;

    private int goldVal;
    private GameState gameState;
    private TowerData pickedTower;

    // Delegate and event for gold value changes
    public delegate void GoldValueChanged(int newGoldValue);
    public event GoldValueChanged OnGoldValueChanged;

    private void Awake()
    {
        ChangeGameState(GameState.MAINMENU);
        UI.UIManager.Instance.OpenUI<UI.CanvasMainMenu>();
        goldVal = 50;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
    public void OpenShop()
    {
        this.gameState = GameState.MAINMENU;
        pickedTower = null;
    }
    public void ChangeGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public void ChooseTower(TowerData tower)
    {
        this.pickedTower = tower;
        ChangeGameState(GameState.ARRANGE);
    }

    public GameObject GetPickedTower()
    {
        return pickedTower.towerType;
    }

    public int GetGoldVal()
    {
        return goldVal;
    }

    public void GainCoin(int val)
    {
        goldVal += val;
        OnGoldValueChanged?.Invoke(goldVal); // Notify subscribers
    }

    public void MinusGoldVal()
    {
        goldVal -= pickedTower.price;
        OnGoldValueChanged?.Invoke(goldVal); // Notify subscribers
    }
}