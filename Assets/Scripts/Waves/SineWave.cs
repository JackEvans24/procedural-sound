using UnityEngine;

namespace ProceduralAudio.Waves
{
    public class SineWave : IWave
    {
        public float AmplitudeModifier => 1f;
        
        public float GetSample(float time, float sampleRate, float frequency)
            => Mathf.Sin(2 * Mathf.PI * time / sampleRate * frequency);
    }
}