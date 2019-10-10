using UnityEngine;
using ApiManager;
using APIObjects;
using TMPro;

public class getPlanetInfo : MonoBehaviour
{
    public string planet;
    public TextMeshPro planetTitle;
    public TextMeshPro latinName;
    public TextMeshPro discoveredBy;
    public TextMeshPro discoveryDate;
    public TextMeshPro generalInfo;
    public GameObject hammer;


    void Start()
       {
        Body bd = APIManager.getPlanetInfo(planet);
        // Earth information here. 
        Debug.Log("English Name next");
        Debug.Log(bd.EnglishName);
        planetTitle.text = bd.EnglishName;
        latinName.text = bd.Name;
        discoveredBy.text = bd.DiscoveredBy;
        discoveryDate.text = bd.DiscoveryDate;
        foreach(Moon mn in bd.Moons)
        {
            generalInfo.text = generalInfo.text + "\n" + mn.MoonMoon;
        }


        hammer.GetComponent<ConstantForce>().force = new Vector3(0f, -(float)bd.Gravity, 0f);            
            
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
