using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float followSpeed;
    [SerializeField] private float maxXValue;

    private float minXValue;
    private Vector3 _offset;
    private Quaternion _followRotation;
    private bool _canFollow;

    void Start()
    {
        _offset = transform.position - followTarget.transform.position;
        _canFollow = true;
        _followRotation = transform.rotation;
        minXValue = transform.position.x;
    }

    void LateUpdate()
    {
        if (!_canFollow || followTarget == null || !followTarget.gameObject.activeInHierarchy)
            return;


        Vector3 followPos = new Vector3(followTarget.transform.position.x + _offset.x, transform.position.y, transform.position.z);

        if (followPos.x >= minXValue && followPos.x <= maxXValue)
        {
            transform.position = Vector3.Lerp(transform.position, followPos, Time.fixedDeltaTime * followSpeed);
        }
        else
        {
            return;
        }


    }
}