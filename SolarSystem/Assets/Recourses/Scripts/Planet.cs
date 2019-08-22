using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public string name; 
    public string englishName;
    public bool isPlanet;
    public ArrayList moons;
    public double semiMajorAxis; // half the distance of the majror axis. Also distance from planet to focus
    public double perihelion; // closest point to sun
    public double aphelion; // furthest point from sun
    public double eccentricity; // the curviness of an eclipse!? 
    public double inclination; // angle
    public ArrayList mass;
    public ArrayList vol;
    public double density;
    public double gravity;
    public double escape;
    public double meanRadius;
    public double equaRadius;
    public double polarRadius;
    public double flattening;
    public double dimension;
    public double sideralOrbit;
    public double sideralRotation;
    public string aroundPlanet;
    public string discoveredBy;
    public string discoveryDate;
    public string alternativeName;
    public string rel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
