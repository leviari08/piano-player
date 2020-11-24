using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace PianoPlayer
{
    public partial class MainForm : Form
    {
        private Piano _piano;
        private MusicLibrary _musicLibrary;
        private Song _currentSong;
        private bool abortThread = false;

        public MainForm()
        {
            InitializeComponent();
            _musicLibrary = new MusicLibrary();

            cmboxSongs.Items.AddRange(_musicLibrary.songs.Select(x => x.name).ToArray());
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            string roomID = txtRoomID.Text;

            if (string.IsNullOrEmpty(roomID))
                _piano = new Piano();
            else
                _piano = new Piano(roomID);
        }

        private void butPlay_Click(object sender, EventArgs e)
        {
            string songName = cmboxSongs.SelectedItem.ToString();
            MessageBox.Show(songName);
            _currentSong = _musicLibrary.songs.First(x => x.name == songName);

            Thread.Sleep(1000);
            _piano.Focus();

            Thread _musicThread = new Thread(() =>
            {
                abortThread = false;

                var musicTracks = new List<Track>();

                musicTracks = musicTracks.Concat(_currentSong.noteTracks).ToList();
                foreach (ChordTrack cTrack in _currentSong.chordTracks)
                {
                    musicTracks = musicTracks.Concat(cTrack.chordList).ToList();
                }

                for (int i = 0; i < musicTracks.Max(m => m.noteList.Length); i++)
                {
                    if (abortThread)
                        return;

                    (Key, int)[] notesToPlay = new (Key, int)[musicTracks.Count];

                    for (int j = 0; j < musicTracks.Count; j++)
                    {
                        notesToPlay[j] = (musicTracks[j].noteList[i % musicTracks[j].noteList.Length], musicTracks[j].octaves);
                    }

                    _piano.PlayNotes(notesToPlay);

                    Thread.Sleep(_currentSong.delay);
                }

                _piano.FreeAllKeys();
            });

            _musicThread.Start();
        }

        private void butTransposition_Click(object sender, EventArgs e)
        {
            var musicTracks = new List<Track>();

            musicTracks = musicTracks.Concat(_currentSong.noteTracks).ToList();
            foreach (ChordTrack cTrack in _currentSong.chordTracks)
            {
                musicTracks = musicTracks.Concat(cTrack.chordList).ToList();
            }

            foreach (Track track in musicTracks)
                foreach (Key key in track.noteList)
                {
                    if (key == Key.CLOSE_SQUARE_BRACKET && ((Button)sender).Name == "butUp")
                        return;

                    if (key == Key.A && ((Button)sender).Name == "butDown")
                        return;
                }

            for (int i = 0; i < musicTracks.Count; i++)
            {
                for (int j = 0; j < musicTracks[i].noteList.Length; j++)
                {
                    Key k = musicTracks[i].noteList[j];

                    if (((Button)sender).Name == "butUp")
                        musicTracks[i].noteList[j] = KeyUtils.NextKey(k);

                    if (((Button)sender).Name == "butDown")
                        musicTracks[i].noteList[j] = KeyUtils.PrevKey(k);

                    //musicTracks[i].noteList[j] = (((Button)sender).Name == "butUp") ? KeyUtils.NextKey(k) : KeyUtils.PrevKey(k);
                }
            }

            int transposition = int.Parse(lblTransposition.Text);

            if (((Button)sender).Name == "butUp")
                transposition++;

            if (((Button)sender).Name == "butDown")
                transposition--;

            //transposition += (((Button)sender).Name == "butUp") ? 1 : -1;

            lblTransposition.Text = transposition.ToString();

            _piano.Focus();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            abortThread = true;
        }
    }
}
