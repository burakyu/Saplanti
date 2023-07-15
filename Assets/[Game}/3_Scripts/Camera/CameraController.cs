using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float followSpeed;

    private Vector3 _offset;
    private Quaternion _followRotation;
    private bool _canFollow;

    void Start()
    {
        _offset = transform.position - followTarget.transform.position;
        _canFollow = true;
        _followRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (!_canFollow || followTarget == null || !followTarget.gameObject.activeInHierarchy)
            return;

        Vector3 followPos = new Vector3(followTarget.transform.position.x + _offset.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, followPos, Time.fixedDeltaTime * followSpeed);
    }
}