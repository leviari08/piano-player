using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoPlayer
{
    class Song
    {
        public List<Track> noteTracks { get; } = new List<Track>();
        public List<ChordTrack> chordTracks { get; } = new List<ChordTrack>();
        public int delay { get; }
        public string name { get; }

        public Song(int delay, string name)
        {
            this.delay = delay;
            this.name = name;
        }

        public Song AddNoteTracks(params (string, int)[] data)
        {
            noteTracks.AddRange(data.Select(x => new Track(x.Item1, x.Item2)));
            return this;
            //foreach ((string, int) x in data)
            //{
            //    noteTracks.Add(new Track(x.Item1, x.Item2));
            //}
        }

        public Song AddChordTrack(params (string, int)[] data)
        {
            Track[] tracks = data.Select(x => new Track(x.Item1, x.Item2)).ToArray();
            chordTracks.Add(new ChordTrack(tracks));
            return this;
        }

    }

    class Track
    {
        public int octaves { get; }
        public Key[] noteList { get; }

        public Track(Key[] keys, int o = 0)
        {
            octaves = o;
            noteList = keys;
        }

        public Track(string keys, int o = 0)
        {
            octaves = o;
            noteList = KeyUtils.StringToKeys(keys);
        }
    }

    class ChordTrack
    {
        public List<Track> chordList { get; }

        public ChordTrack(Track[] chords)
        {
            chordList = new List<Track>();

            chordList = chords.Select(t => t).ToList();
        }
    }
}
