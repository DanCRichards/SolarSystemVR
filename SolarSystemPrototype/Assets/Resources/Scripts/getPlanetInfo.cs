using UnityEngine;
using ApiManager;
using APIObjects;

public class getPlanetInfo : MonoBehaviour
{
    public string planet;
    // Start is called before the first frame update
    void Start()
    {
        Body bd = APIManager.getPlanetInfo("Earth");
        // Earth information here. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
