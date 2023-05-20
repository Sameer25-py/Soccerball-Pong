using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bat : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField] private bool lockX, lockY;

        private bool _enableMovement = false;

        private void OnEnable()
        {
            _camera = Camera.main;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider && col.gameObject.CompareTag("Wall"))
            {
                _enableMovement = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col && col.CompareTag("Wall"))
            {
                _enableMovement = false;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray          ray   = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit2D.collider != null && hit2D.collider.gameObject == gameObject)
                {
                    _enableMovement = true;
                }
                else
                {
                    _enableMovement = false;
                }

                if (_enableMovement)
                {
                    Vector2 screenMousePos = Input.mousePosition;
                    Vector2 worldMousePos  = _camera.ScreenToWorldPoint(screenMousePos);
                    transform.position = new Vector2(
                        lockX ? transform.position.x : worldMousePos.x,
                        lockY ? transform.position.y : worldMousePos.y
                    );
                }
            }
        }
    }
}