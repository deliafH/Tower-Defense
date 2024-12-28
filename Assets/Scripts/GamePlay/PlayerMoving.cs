using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : Singleton<PlayerMoving>
{
    Vector3 destPos;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;
    private Camera cam;
    private CameraMovingScript cameraMoving;
    private void Start()
    {
        cam = Camera.main;
        cameraMoving = cam.GetComponent<CameraMovingScript>();
    }
    public void SetDest(Vector3 dest)
    {
        this.destPos = dest;
        PlayAnim();
        animator.SetBool("isMoving", false);
    }

    public void PlayGame()
    {
        sprite.color = Color.white / 2; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            Vector2 mousePosition = Input.mousePosition;
            SetDest(cam.ScreenToWorldPoint(mousePosition));
        }

        // Move towards the destination
        if (Vector2.Distance(transform.position, destPos) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destPos, speed * Time.deltaTime);
            animator.SetBool("isForward", Mathf.Abs(destPos.y - transform.position.y) > Mathf.Abs(destPos.x - transform.position.x));
            cameraMoving.SetDest(this.transform.position);
        }
        else
        {
            animator.SetInteger("vx", 0);
            animator.SetInteger("vy", 0);
            animator.SetBool("isMoving", true);
        }

    }

    private void PlayAnim()
    {
        // Animator logic
        float deltaX = destPos.x - transform.position.x;
        float deltaY = destPos.y - transform.position.y;

        animator.SetInteger("vx", deltaX < 0 ? -1 : (deltaX > 0 ? 1 : 0));
        animator.SetInteger("vy", deltaY < 0 ? -1 : (deltaY > 0 ? 1 : 0));

    }
}