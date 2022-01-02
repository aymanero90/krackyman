using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.3f;
    private MeshRenderer renderer;

    private const string MAINT_TEX = "_MainTex";
    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        slide();
    }

    void slide()
    {
        Vector2 offset = renderer.sharedMaterial.GetTextureOffset(MAINT_TEX);
        offset.y -= Time.deltaTime * speed;

        renderer.sharedMaterial.SetTextureOffset(MAINT_TEX, offset);
    }
}
