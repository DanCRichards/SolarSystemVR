using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using APIObjects;
using TMPro;

namespace ApiManager
{

    public class APIManager : MonoBehaviour
    {

        public static Bodies bodies;

        void GetPlanets()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.le-systeme-solaire.net/rest/bodies/"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            Debug.Log(jsonResponse);
            bodies = Bodies.FromJson(jsonResponse);

            Debug.Log(bodies.BodiesBodies[0].Name);


        }
        // Start is called before the first frame update
        void Start()
        {
            GetPlanets();
        }


        public static Body getPlanetInfo(string planet)
        {
            // Should look into actually returning object! 

            foreach(Body bd in bodies.BodiesBodies)
            {
                if (bd.EnglishName == planet)
                {
                    return bd;
                }
            }
            return new Body(); // Not good programming. Should actually do something else. 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
