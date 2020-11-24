using System;
using System.Collections.Generic;
using System.Linq;


namespace PianoPlayer
{
    class MusicLibrary
    {
        private Song faded = new Song(delay: 325, name: "Alan walker - faded")
            .AddNoteTracks(
                ("59795979W757W7577-9-7-9-48Y848Y8", -1),
                (Utils.nSpaces(32) + "7 7 7 9 + + + - 9 9 9 9 Y Y Y Y 7 7 7 9 + + + - 9 9 9 7 Y Y Y 5 ", 0),
                (Utils.nSpaces(32) + Utils.nSpaces(64) + " 77775789 7749       777Y  YY57  77775789 77-9       778     9999            9999            9999    789877  9999    778YYY7    ", 1)
            )
            .AddChordTrack(
                ("G       X       J       F       ", -1),
                ("J       G       2       N       ", -1),
                ("2       J       4       1       ", -1)
            );

        private Song rPhoneRingtone = new Song(delay: 150, name: "phone ringtone")
            .AddNoteTracks(
                ("I T T  ERTRT     IOP[ PIOP[]    ", 0)
            )
            .AddChordTrack(
                ("B" + Utils.nSpaces(31), -1),
                ("Q" + Utils.nSpaces(31), -1),
                ("E" + Utils.nSpaces(31), -1)
            );

        private Song tetris = new Song(delay: 175, name: "Tetris theme")
            .AddNoteTracks(
                ("T T WER EWQ QET REW WER T E Q Q    R YI UYT  ET REW WER T E Q Q   ", 1),
                ("  BTBTBTBTZQZQZQZQA1A1A1A1ZQZQZQZQVRVRVRVRCECECECEXWXWXWXWZQZQZ   ", 0)
            );


        public Song[] songs;

        public MusicLibrary()
        {
            songs = new Song[]
            {
                faded, rPhoneRingtone, tetris
            };
        }

    }
}
