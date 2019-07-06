using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    [Tooltip("layermask used to isolate raycasts against clickable layers")]
    public LayerMask clickableLayer;

    [Tooltip("normal mouse pointer")]
    public Texture2D pointer;
    [Tooltip("target mouse pointer")]
    public Texture2D target;
    [Tooltip("doorway mouse pointer")]
    public Texture2D doorway;

    public EventVector3 OnClickEnvironment;

    private Camera camera;
    
    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out var hit, 50, clickableLayer.value))
        {
            bool door = false;
            if (hit.collider.gameObject.CompareTag("Doorway"))
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButton(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEnvironment?.Invoke(doorway.position + doorway.forward * 10);
                }
                else
                {
                    OnClickEnvironment?.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }

