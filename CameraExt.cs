using UnityEngine;

static class CameraExt
{
    // Extension method for easily get the FMinimalViewInfo
    // Code sample from Unreal: view.GetViewPoint(FMinimalViewInfo)
    public static void GetViewPoint(this Camera camera, out Unreal.FMinimalViewInfo info)
    {
        info = new Unreal.FMinimalViewInfo();
        info.ProjectionMatrix = camera.projectionMatrix;
        info.FOV = camera.fieldOfView;
        info.Near = camera.nearClipPlane;
        info.Far = camera.farClipPlane;

        info.Location = camera.transform.position;
        info.Rotation = camera.transform.eulerAngles;
    }
}
