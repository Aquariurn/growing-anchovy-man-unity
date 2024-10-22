using UnityEngine;

public class Particle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 direction;
    
    public float initialSpeed;
    public float colorSpeed;

    private float lifetime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(1.0f, -1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        transform.Translate(direction * initialSpeed * (1 / lifetime));
        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(spriteRenderer.color.a, 0, Time.deltaTime * colorSpeed);
        spriteRenderer.color = color;

        if(spriteRenderer.color.a <= 0.01f) {
            Destroy(gameObject);
        }
    }
}
