using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{

    public Vector3 cameraOffset = new Vector3(0, 0, -10);
    public float zoomInterval = 0.2f;
    public float zoomOutMax = 1.5f;
    public float zoomInMax = 0.5f;

    private new Camera camera;
    private Vector3 oldMousePos;
    private float currentZoomLevel = 1f;
    private float orignalOrphoSize;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        orignalOrphoSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleZoom();

    }

    void handleZoom()
    {
        float mouseScrollY = Input.mouseScrollDelta.y * zoomInterval;
        currentZoomLevel = Mathf.Clamp(currentZoomLevel - mouseScrollY, zoomInMax, zoomOutMax);
        camera.orthographicSize = orignalOrphoSize * Mathf.Abs(currentZoomLevel);
    }

    void handleMovement()
    {
        Vector3 cameraMove = Vector3.zero;

        if (Input.GetMouseButtonDown(1))
        {
            oldMousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
             cameraMove = oldMousePos - camera.ScreenToWorldPoint(Input.mousePosition);
        }

        camera.transform.position += cameraMove;
    }

}
