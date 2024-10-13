using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public GameObject[] particles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0)){
            MakeParticle();
            Debug.Log("마우스 클릭");
        }*/
    }

    public void BuyEffect(GameObject _gameobject) {
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[0], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[1], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[2], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
        Instantiate(particles[3], _gameobject.transform.position, quaternion.identity);
    }

    void MakeParticle()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Instantiate(particles[0], mouse, Quaternion.identity);
        Instantiate(particles[1], mouse, Quaternion.identity);
        Instantiate(particles[2], mouse, Quaternion.identity);
        Instantiate(particles[3], mouse, Quaternion.identity);
    }
}
