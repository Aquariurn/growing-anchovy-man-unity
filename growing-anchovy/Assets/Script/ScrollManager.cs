using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public Transform[] backgrounds;

    float leftPosX = 960f;
    float rightPosX = 960f;
    float leftPosY = 1920f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < backgrounds.Length; i++) {
            backgrounds[i].position += new Vector3(xSpeed, -ySpeed, 0) * Time.deltaTime;

            if(backgrounds[i].position.x > rightPosX) {
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x - (leftPosX * 2), nextPos.y + leftPosY, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }
}
