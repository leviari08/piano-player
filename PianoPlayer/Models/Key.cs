using System;
using System.Linq;


namespace PianoPlayer
{
    enum Key : byte
    {
        A = 65,
        Z = 90,
        S = 83,
        X = 88, 
        C = 67,
        F = 70,
        V = 86,
        G = 71,
        B = 66,
        N = 78,
        J = 74,
        M = 77,
        NUMBER_1 = 49,
        Q = 81,
        NUMBER_2 = 50,
        W = 87,
        E = 69,
        NUMBER_4 = 52,
        R = 82,
        NUMBER_5 = 53,
        T = 84,
        Y = 89,
        NUMBER_7 = 55,
        U = 85,
        NUMBER_8 = 56,
        I = 73,
        NUMBER_9 = 57,
        O = 79,
        P = 80,
        DASH = 189,
        OPEN_SQUARE_BRACKET = 219,
        PLUS = 187, // 187 is the '=' sign, but I chose to call it 'plus'
        CLOSE_SQUARE_BRACKET = 221,

        ARROW_UP = 38,
        ARROW_DOWN = 40,
        SPACE = 32
    }

    static class KeyUtils
    {
        private static Key[] keyOrder = { Key.A, Key.Z, Key.S, Key.X, Key.C, Key.F, Key.V, Key.G, Key.B, Key.N, Key.J, Key.M,
            Key.NUMBER_1, Key.Q, Key.NUMBER_2, Key.W, Key.E, Key.NUMBER_4, Key.R, Key.NUMBER_5, Key.T, Key.Y, Key.NUMBER_7, Key.U,
            Key.NUMBER_8, Key.I, Key.NUMBER_9, Key.O, Key.P, Key.DASH, Key.OPEN_SQUARE_BRACKET, Key.PLUS, Key.CLOSE_SQUARE_BRACKET };

        public static Key NextKey(Key k)
        {
            if (k == Key.SPACE)
                return Key.SPACE;

            if (k == Key.CLOSE_SQUARE_BRACKET)
                return Key.SPACE;

            int index = Array.IndexOf(keyOrder, k);

            return keyOrder[index + 1];
        }

        public static Key PrevKey(Key k)
        {
            if (k == Key.SPACE)
                return Key.SPACE;

            if (k == Key.A)
                return Key.SPACE;

            int index = Array.IndexOf(keyOrder, k);

            return keyOrder[index - 1];
        }

        public static Key CharToKey(char c)
        {
            Key[] keysArray = Enum.GetValues(typeof(Key)).Cast<Key>().ToArray();

            return c switch
            {
                '-' => Key.DASH,
                '[' => Key.OPEN_SQUARE_BRACKET,
                '=' => Key.PLUS, '+' => Key.PLUS,
                ']' => Key.CLOSE_SQUARE_BRACKET,
                char when int.TryParse(c.ToString(), out _) => (Key)(int.Parse(c.ToString()) + 48),
                _ => keysArray.First(k => (char)k == c)
            };
            
            /*
             * Special character => manual return 
             * Number => convert to int and return the value + 48
             * Other char => return the correct key
             */
        }

        public static Key[] StringToKeys(string s)
        {
            Key[] keyArray = new Key[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                keyArray[i] = CharToKey(s[i]);
            }

            return keyArray;
        }
    }

}
