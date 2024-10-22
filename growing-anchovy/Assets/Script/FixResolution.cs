using UnityEngine;
using UnityEngine.U2D;

public class FixResolution : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scaleWidth = 1f / scaleHeight;

        if(scaleHeight < 1) {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) / 2f;
        } else {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
