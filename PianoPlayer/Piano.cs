using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;


namespace PianoPlayer
{
    class Piano
    {
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        
        private static uint WM_KEYDOWN = 0x100, WM_KEYUP = 0x101;

        /// <summary>
        /// Use this method to send a key to the focused window 
        /// (key press without knowing/using the WindowHandle)
        /// 
        /// [DllImport("user32.dll")]
        /// private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        /// public const int KEYEVENTF_KEYDOWN = 0x0001; //Key down flag
        /// public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        /// 
        /// keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        /// keybd_event((byte)key, 0, KEYEVENTF_KEYDOWN, 0);
        /// </summary>
        
        private Process _pianoProcess;

        public Piano()
        {
            Process[] p = Process.GetProcessesByName("chrome");

            foreach (Process i in p)
            {
                if (i.MainWindowTitle != "" && i.MainWindowTitle.StartsWith("Piano"))
                    _pianoProcess = i;
            }

            string msg = _pianoProcess is null ? "Not connected" : "Connected";
            System.Windows.Forms.MessageBox.Show(msg);
        }

        public Piano(string roomID)
        {
            string url = $"https://www.multiplayerpiano.com/{roomID}";
            string chromeFileName = Environment.GetEnvironmentVariable("ProgramFiles(x86)") + @"\Google\Chrome\Application\chrome.exe";

            _pianoProcess = new Process();
            _pianoProcess.StartInfo = new ProcessStartInfo(chromeFileName, url);
            _pianoProcess.Start();
        }

        public void PlayNotes(params (Key, int)[] data)
        {
            //var notes = data.ToList().OrderBy(x => x.Item2).ToArray();

            var notes1 = data.ToList().Where(x => x.Item2 == -1).ToArray();
            var notes2 = data.ToList().Where(x => x.Item2 == 0).ToArray();
            var notes3 = data.ToList().Where(x => x.Item2 == 1).ToArray();


            // -1

            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)Key.ARROW_DOWN, IntPtr.Zero);
            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)Key.ARROW_DOWN, IntPtr.Zero);

            foreach (var n in notes1)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)n.Item1, IntPtr.Zero);
            }

            Thread.Sleep(1);

            foreach (var n in notes1)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)n.Item1, IntPtr.Zero);
            }

            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)Key.ARROW_UP, IntPtr.Zero);
            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)Key.ARROW_UP, IntPtr.Zero);

            Thread.Sleep(1);


            // 0

            foreach (var n in notes2)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)n.Item1, IntPtr.Zero);
            }

            Thread.Sleep(1);

            foreach (var n in notes2)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)n.Item1, IntPtr.Zero);
            }

            Thread.Sleep(1);


            // 1

            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)Key.ARROW_UP, IntPtr.Zero);
            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)Key.ARROW_UP, IntPtr.Zero);

            foreach (var n in notes3)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)n.Item1, IntPtr.Zero);
            }

            Thread.Sleep(1);

            foreach (var n in notes3)
            {
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)n.Item1, IntPtr.Zero);
            }

            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYDOWN, (IntPtr)Key.ARROW_DOWN, IntPtr.Zero);
            SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)Key.ARROW_DOWN, IntPtr.Zero);
        }

        public void FreeAllKeys()
        {
            foreach (Key k in Enum.GetValues(typeof(Key)))
                SendMessage(_pianoProcess.MainWindowHandle, WM_KEYUP, (IntPtr)k, IntPtr.Zero);
        }

        public void Focus()
        {
            Thread.Sleep(100);
            SetForegroundWindow(_pianoProcess.MainWindowHandle);
        }
    }
}
