using UnityEngine;

[ExecuteInEditMode]
public class CameraRenderingTexture : MonoBehaviour
{
    public Material Mat;

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}