using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ColorChanger : MonoBehaviour
{
    private Renderer _cechedRenderer;

    private void Awake()
    {
        _cechedRenderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {

        _cechedRenderer.material.color = new Color(
            Random.value, Random.value, Random.value);
    }

    public void SetBaseColor(Color color)
    {
        _cechedRenderer.material.color = color;
    }

}