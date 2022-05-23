using UnityEngine;

namespace Game.GameAndUI
{
    public class TouchRotation : MonoBehaviour
    {
        [SerializeField] private GameObject selectBlock;
        private UnityEngine.Camera _camera;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    hit.collider.GetComponent<Rotation>().RotateZ();
                }
            }

            if (Input.GetMouseButtonUp(1))
            {
                if (!(selectBlock == null))
                {
                    selectBlock = null;
                }
            }
#endif
#if UNITY_ANDROID
            if (Input.touchCount == 2)
            {
                Touch touchA = Input.GetTouch(0);
                Touch touchB = Input.GetTouch(1);
                Vector2 touchADirection = touchA.position - touchA.deltaPosition;
                Vector2 touchBDirection = touchB.position - touchB.deltaPosition;

                if (hit.collider != null && hit.collider.CompareTag("Model"))
                {
                    selectBlock = hit.transform.gameObject;
                    float angle = Vector3.SignedAngle(touchA.position - touchB.position,
                        touchADirection - touchBDirection, -_camera.transform.forward);
                    selectBlock.transform.RotateAround(_camera.transform.position, Vector3.forward, angle);
                }
            }
#endif
        }
    }
}
