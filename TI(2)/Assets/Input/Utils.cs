
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWord(Camera camera, Vector3 position){
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
}
