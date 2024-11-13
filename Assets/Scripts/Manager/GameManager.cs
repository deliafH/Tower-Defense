using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum GameState { MAINMENU, GAMEPLAY, ARRANGE, START, FINISH, }
public class GameManager: Singleton<GameManager>
{
    private int goldVal;
    private GameState gameState;
    private TowerData pickedTower;


    internal void OpenShop()
    {
        this.gameState = GameState.MAINMENU;
        pickedTower = null;
    }

    private void Awake()
    {
        ChangeGameState(GameState.MAINMENU);
        UI.UIManager.Instance.OpenUI<UI.CanvasMainMenu>();
        goldVal = 20;
    }

    public void ChangeGameState(GameState gameState)
    {
        this.gameState = gameState;
    }


    public GameState GetGameState()
    {
        return gameState;
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

    public void MinusGoldVal()
    {
        goldVal -= pickedTower.price;
    } 
}
