using UnityEngine;

public class ZoomHendler : MonoBehaviour
{
    private float _distatance;
    private UnityEngine.Camera _camera;
    private void Awake()
    {
        _camera = UnityEngine.Camera.main;
    }
    
    private void Update()
    {
        if (Input.touchCount == 2) Zoom();
        else if (_distatance != 0) _distatance = 0;
    }

    private void Zoom()
    {
        Vector2 touchA = Input.GetTouch(0).position;
        Vector2 touchB = Input.GetTouch(1).position;
        
        if (_distatance == 0) _distatance = Vector2.Distance(touchA, touchA);

        float delta = Vector2.Distance(touchA, touchB) - _distatance;

        transform.position = Vector3.MoveTowards(transform.position,
            transform.position - transform.forward, delta * Time.deltaTime);

        _distatance = Vector2.Distance(touchA, touchA);
    }
}