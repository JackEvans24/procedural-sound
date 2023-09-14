using System;
using System.Collections.Generic;
using ProceduralAudio.Waves;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ProceduralAudio.Utility
{
    public class UserAudioTool : MonoBehaviour
    {
        [SerializeField] private WaveType waveType;
        [SerializeField] private float frequency = 440f; // A4
        [SerializeField] private float amplitude = 0.2f;
        
        private AudioController _audioController = AudioController.Instance;

        private readonly Dictionary<WaveType, IWave> _waves = new()
        {
            { WaveType.Sawtooth, new SawtoothWave() },
            { WaveType.Sine, new SineWave() },
            { WaveType.Square, new SquareWave() },
            { WaveType.Triangle, new TriangleWave() }
        };

        private bool _initialised;

        private void Start()
        {
            UpdateValues();
            _initialised = true;
        }

        private void OnValidate()
        {
            if (!_initialised)
                return;
            UpdateValues();
        }

        public void UpdateValues()
        {
            _audioController.SetWave(GetWave());
            _audioController.SetFrequency(frequency);
            _audioController.SetAmplitude(amplitude);
        }

        private IWave GetWave()
        {
            if (!_waves.ContainsKey(waveType))
                throw new NotImplementedException();

            return _waves[waveType];
        }
    }
}