using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]

public class Billboarded3dText : MonoBehaviour {

    public bool yawOnly = false;
    public float minimalViewDistance = 0.5f;

    private MeshRenderer meshRenderer;
    private TextMesh textMesh;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        textMesh = GetComponent<TextMesh>();
    }

    private void LateUpdate()
    {
        var cam = Camera.main;
        if (cam == null) return;

        var lookDir = transform.position - cam.transform.position;
        if (yawOnly) lookDir.y = 0;

        if(Vector3.SqrMagnitude(lookDir) < minimalViewDistance)
        {
            meshRenderer.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
	
}