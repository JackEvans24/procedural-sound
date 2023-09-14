﻿using System;
using ProceduralAudio.Waves;

namespace ProceduralAudio
{
    public class AudioController
    {
        private static AudioController _instance;
        public static AudioController Instance => _instance ??= new AudioController();

        public Action<IWave> WaveChanged;
        public Action<float> FrequencyChanged;
        public Action<float> AmplitudeChanged;

        private IWave _wave;
        private float _frequency;
        private float _amplitude;
        
        private AudioController() { }

        public void SetWave(IWave wave)
        {
            if (_wave == wave)
                return;

            _wave = wave;
            WaveChanged?.Invoke(_wave);
        }

        public void SetFrequency(float frequency)
        {
            if (Math.Abs(_frequency - frequency) < float.Epsilon)
                return;

            _frequency = frequency;
            FrequencyChanged?.Invoke(_frequency);
        }

        public void SetAmplitude(float amplitude)
        {
            if (Math.Abs(_amplitude - amplitude) < float.Epsilon)
                return;

            _amplitude = amplitude;
            AmplitudeChanged?.Invoke(_amplitude);
        }
    }
}