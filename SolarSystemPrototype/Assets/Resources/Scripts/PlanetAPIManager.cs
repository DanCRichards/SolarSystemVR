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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.le-systeme-solaire.net/rest/bodies/?filter[]=isPlanet,neq,false"));
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}
