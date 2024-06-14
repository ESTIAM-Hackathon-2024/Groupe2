using UnityEngine;

public class FlameEffect : MonoBehaviour
{
    public ParticleSystem flameParticleSystem;

    public void Start()
    {
        if (flameParticleSystem == null)
        {
            flameParticleSystem = gameObject.AddComponent<ParticleSystem>();
            var main = flameParticleSystem.main;
            main.loop = true;
            main.startLifetime = 0.5f; 
            main.startSpeed = 0.2f; 
            main.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
    }

    void Update()
    {
    }
}
