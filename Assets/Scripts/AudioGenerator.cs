using System;
using System.Collections.Generic;
using ProceduralAudio.Waves;
using UnityEngine;

namespace ProceduralAudio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioGenerator : MonoBehaviour
    {
        [SerializeField] private WaveType waveType;
        [SerializeField] private float frequency = 440f; // A4
        [SerializeField] private int sampleRate = 48000;
        [SerializeField] private float amplitude = 0.2f;

        private readonly Dictionary<WaveType, IWave> _waves = new()
        {
            { WaveType.Sawtooth, new SawtoothWave() },
            { WaveType.Sine, new SineWave() },
            { WaveType.Square, new SquareWave() },
            { WaveType.Triangle, new TriangleWave() }
        };
        private int _time;
    
        private void OnAudioFilterRead(float[] data, int channels)
        {
            var wave = GetWave();
            var activeAmplitude = amplitude * wave.AmplitudeModifier;

            for (var i = 0; i < data.Length; i += channels, _time++)
            {
                if (_time >= sampleRate)
                    _time %= sampleRate;
            
                var sample = wave.GetSample(_time, sampleRate, frequency) * activeAmplitude;
                for (var j = 0; j < channels; j++)
                    data[i + j] = sample;
            }
        }

        private IWave GetWave()
        {
            if (!_waves.ContainsKey(waveType))
                throw new NotImplementedException();

            return _waves[waveType];
        }
    }
}
