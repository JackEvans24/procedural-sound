namespace ProceduralAudio.Data
{
    public class Note
    {
        public int Octave;
        public string Pitch;

        public Note(int pitch)
        {
            var adjustedPitch = pitch - 1;
            
            var rawOctave = adjustedPitch / 12;
            var rawNote = adjustedPitch % 12;

            Octave = rawNote > 2 ? rawOctave + 1 : rawOctave;
            Pitch = _notes[rawNote];
        }

        public override string ToString() => $"{Pitch}<sup>{Octave}</sup>";

        private readonly string[] _notes = {
            "A",
            "A#",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"
        };
    }
}