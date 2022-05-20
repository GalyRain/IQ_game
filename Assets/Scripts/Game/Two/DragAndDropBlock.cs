using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDropBlock : MonoBehaviour
{
    [SerializeField] private GameObject selectBlock; 
    private Transform _target;
    private UnityEngine.Camera _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera = UnityEngine.Camera.main;
    }
    
    private void Update () 
    {
        RaycastHit2D hit = Physics2D.Raycast(
            _camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        DragAndDrop(hit);
        RotateY(hit);
        RotateZ(hit);
    }

    private void DragAndDrop(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.transform != null && hit.transform.CompareTag("Model"))
            {
                selectBlock = hit.transform.gameObject;
                _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            }
        }
        if (selectBlock != null)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            selectBlock.transform.position = _camera.ScreenToWorldPoint(newPosition) + _offset;
        }
        NotActivated(0);
    }
    
    private void RotateZ(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (hit.transform != null && hit.transform.CompareTag("Model"))
            {
                selectBlock = hit.transform.gameObject;
                // _target = selectBlock.transform.Find("Target");
                _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                selectBlock.transform.RotateAround(_offset, Vector3.forward, 45);
            }
        }
        NotActivated(1);
    }

    private void RotateY(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (hit.transform != null && hit.transform.CompareTag("Model"))
            {
                selectBlock = hit.transform.gameObject;
                // _target = selectBlock.transform.Find("Target");
                _offset = selectBlock.transform.position - _camera.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                selectBlock.transform.RotateAround(_offset, Vector3.down, 180);
            }
        }
        NotActivated(2);
    }

    private void NotActivated(int mouseButton)
    {
        if (Input.GetMouseButtonUp(mouseButton))
        {
            if (selectBlock != null)
            {
                selectBlock = null;
            }
        }
    }
}
