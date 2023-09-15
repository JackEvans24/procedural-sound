using ProceduralAudio.Data;
using TMPro;
using UnityEngine;

namespace ProceduralAudio.UI
{
    public class PitchVisualiser : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pitchLabel;
        
        private AudioController _audioController = AudioController.Instance;

        private int _pitch;
        private Note _note;

        private void Awake()
        {
            _audioController.PitchChanged += UpdatePitch;
        }

        private void Start()
        {
            UpdatePitch(_audioController.Pitch);
        }

        private void OnDestroy()
        {
            _audioController.PitchChanged -= UpdatePitch;
        }

        public void ChangePitch(int semitones)
        {
            _audioController.SetPitch(_pitch + semitones);
        }

        private void UpdatePitch(int pitch)
        {
            if (pitch == _pitch)
                return;

            _pitch = pitch;
            _note = new Note(pitch);

            _pitchLabel.text = _note.ToString();
        }
    }
}