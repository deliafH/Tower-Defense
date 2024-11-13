using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowePositionScript : MonoBehaviour
{
    [SerializeField] Sprite normalGrass, pickedGrass;
    [SerializeField] SpriteRenderer sprite;
    bool isPicked;
    private void Awake()
    {
        isPicked = false;
    }
    private void OnMouseDown()
    {

        /*if (!isPicked)
        {
            SetIsPicked(true);
        }*/
           

        if (transform.childCount == 0 && GameManager.Instance.GetGameState() == GameState.ARRANGE)
        {
            GameObject go = Instantiate(GameManager.Instance.GetPickedTower(), this.transform);
            go.transform.position = this.transform.position;
            GameManager.Instance.ChangeGameState(GameState.MAINMENU);
            GameManager.Instance.MinusGoldVal();
        }
    }

    public void SetIsPicked(bool isPick)
    {
        this.isPicked = isPick;
        sprite.sprite = isPicked ? pickedGrass : normalGrass;
    }
}
