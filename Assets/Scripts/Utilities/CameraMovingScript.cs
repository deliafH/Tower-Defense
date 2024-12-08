using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingScript : Singleton<CameraMovingScript>
{
    [SerializeField] float lowerBorder, upperBorder, leftBorder, rightBorder;
    [SerializeField] Transform camera;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minDistance = 0.1f;
    private Vector3 initialMousePosition;

    private void Awake()
    {
        camera = Camera.main.transform;
        lowerBorder = GameManager.Instance.MinCamPos.y;
        upperBorder = GameManager.Instance.MaxCamPos.y;
        leftBorder = GameManager.Instance.MinCamPos.x;
        rightBorder = GameManager.Instance.MaxCamPos.x;    
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && camera != null)
        {
            Move();
        }
    }

    public void Move()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 direction = (initialMousePosition - currentMousePosition).normalized;

        Vector3 desiredPosition = camera.position + direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(camera.position, desiredPosition) > minDistance)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftBorder, rightBorder);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, lowerBorder, upperBorder);

            camera.position = Vector3.Lerp(camera.position, desiredPosition, Time.deltaTime * moveSpeed);
        }

        initialMousePosition = currentMousePosition;
    }

}