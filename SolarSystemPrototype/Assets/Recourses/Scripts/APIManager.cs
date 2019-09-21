using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using Newtonsoft.Json;
using APIObjects;
using TMPro;

public class APIManager : MonoBehaviour
{

    public GameObject planetList;
    public GameObject earth;
    public GameObject mars;
    public GameObject neptune;
    public GameObject saturn;
    public GameObject jupiter;
    public GameObject uranus;
    public GameObject venus;
    public GameObject mercury;
    private List<GameObject> solarSystem; 
   
   void GetPlanets()
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.le-systeme-solaire.net/rest/bodies/?filter[]=isPlanet,neq,false"));
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          StreamReader reader = new StreamReader(response.GetResponseStream());
          string jsonResponse = reader.ReadToEnd();
          Debug.Log(jsonResponse);
          var bodies = Bodies.FromJson(jsonResponse);

        Debug.Log(bodies.BodiesBodies[0].Name);

        for(int i = 0; i <= bodies.BodiesBodies.Count; i++)
        {
            int j = 0; 
            if (bodies.BodiesBodies[i + 1].EnglishName.Contains("Eris") || bodies.BodiesBodies[i + 1].EnglishName.Contains("Haumea") || bodies.BodiesBodies[i + 1].EnglishName.Contains("Makemake"))
            {
                continue;
            }
            else
            {
                var newCube = (GameObject)Instantiate(planetList, new Vector3(-1, (i * 0.5f) + 1, 4), Quaternion.identity);
                newCube.GetComponent<TextMeshPro>().text = bodies.BodiesBodies[i + 1].EnglishName;
            }
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        GetPlanets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
