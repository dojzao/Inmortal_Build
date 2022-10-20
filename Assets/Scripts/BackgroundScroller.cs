using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollspeed = 0.5f;
    public static int playermov = 0;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        if(playermov == 1){
            offset += (Time.deltaTime * scrollspeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset,0));
        }else if (playermov == 2){

            offset -= (Time.deltaTime * scrollspeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset,0));
        }
        
    }
}
