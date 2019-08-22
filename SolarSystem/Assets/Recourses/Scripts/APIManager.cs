﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;

public class APIManager : MonoBehaviour
{
   
   void GetPlanets()
        {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://api.le-systeme-solaire.net/rest/bodies/"));
          HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          StreamReader reader = new StreamReader(response.GetResponseStream());
          string jsonResponse = reader.ReadToEnd();
          Debug.Log(jsonResponse);
      
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
