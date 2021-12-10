using UnityEngine;

public class BoingScript : MonoBehaviour
{
    [SerializeField]
    private float maxScale; //Maximum scale for game object to grow to
    [SerializeField] [Range(0, 1f)] 
    private float minScale; //Minimum scale for game object to grow from
    private float time;

    private void Awake()
    {
        maxScale = transform.localScale.x;
    }
    void Update()
    {
        transform.localScale = Vector3.one * Mathfx.Berp(minScale, maxScale, time); //scales gameobject according to Berp Curve
        time += Time.deltaTime;
    }

    private void OnEnable() //ensures that gameobject is scaled to 0 onEnable
    {
        time = 0f;
    }

    public sealed class Mathfx //Follows Berp Curve
    {
        //Boing
        public static float Berp(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
            return start + (end - start) * value;
        }

        public static Vector2 Berp(Vector2 start, Vector2 end, float value)
        {
            return new Vector2(Berp(start.x, end.x, value), Berp(start.y, end.y, value));
        }

        public static Vector3 Berp(Vector3 start, Vector3 end, float value)
        {
            return new Vector3(Berp(start.x, end.x, value), Berp(start.y, end.y, value), Berp(start.z, end.z, value));
        }
    }
}