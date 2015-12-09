using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices; // used for mouse detection and WINAPI functions

using System.Diagnostics; // required for access to the list of processes

namespace WindowRearranger
{
    public partial class Form1 : Form
    {
        private int totalNumberOfScreens;
        private string[] screenName;
        private Rectangle[] screenBounds;

        private List<RealWorldScreen> realWorldScreens;

        private int index;

        private IntPtr[] ActiveWindowListHandles;

        public Form1()
        {
            InitializeComponent();
            acquireScreenDetails(); // how many screens do we have available
        }

        /*
         * This information acquired by this function is not actually made use as yet. 
         */
        private void acquireScreenDetails()
        {
            totalNumberOfScreens = 0;

            // acquire and output the info on all connected screens
            foreach (var screen in Screen.AllScreens)
            {
                totalNumberOfScreens++; // increment the total # of screens
            }

            // These 2 hold details of the real world screens/monitors
            screenName = new string[totalNumberOfScreens];
            screenBounds = new Rectangle[totalNumberOfScreens];
            // This will hold details of each screen layout on the screen panel within the GUI
            // This does not translate the details to that of the real world screens

            realWorldScreens = new List<RealWorldScreen>();

            int index = 0;
            foreach (var screen in Screen.AllScreens)
            {
                // add screen to conbobox
                cmbAvailableScreens.Items.Add(screen.DeviceName);

                // these represent the actual screen dimensions
                // used to work out which config screen represent what real world screen
                RealWorldScreen realScreen = new RealWorldScreen();
                realWorldScreens.Add(realScreen);

                realWorldScreens[index].screenName = screen.DeviceName;
                realWorldScreens[index].screenHeight = screenBounds[index].Height;
                realWorldScreens[index].screenWidth = screenBounds[index].Width;
                realWorldScreens[index].screenTopLeftXCoord = screenBounds[index].X;
                realWorldScreens[index].screenTopLeftYCoord = screenBounds[index].Y;
                realWorldScreens[index].currentlyAssignedToConfigScreen = index;

                index++;
            }
        } 

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /*
         * ===========================================
         * Move the selected window to the main screen
         * ===========================================
         */

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private static IntPtr HWND_TOPMOST = (IntPtr)(-1); // this is not used here
        private static IntPtr HWND_TOP = (IntPtr)(0);      // this is used

        private const int SWP_SHOWWINDOW = 0x0040;

        private void btnMoveWindow_Click(object sender, EventArgs e)
        {
            // move the windows based on the idx of the window and the idx of the screen
            int iCurrentlySelectedWindow = cmbActiveWindows.SelectedIndex;
            int iCurrentlySelectedScreen = cmbAvailableScreens.SelectedIndex;

            // move the window to the screen
            RECT pRect;
            Size cSize = new Size();
            // get coordinates relative to window
            GetWindowRect(ActiveWindowListHandles[iCurrentlySelectedWindow], out pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            // move the window
            SetWindowPos(ActiveWindowListHandles[iCurrentlySelectedWindow], HWND_TOP, 0, 0, cSize.Width, cSize.Height, SWP_SHOWWINDOW);            

        }

        private void cmbAvailableScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Screen: " + cmbAvailableScreens.SelectedIndex.ToString());
        }

        private void cmbActiveWindows_Click(object sender, EventArgs e)
        {
            index = 0;
            cmbActiveWindows.Items.Clear();
            getActiveWindows();
        }


        /*
         * ==============================================================
         * EnumWindows used to acquire the Handle of all existing windows
         * see:
         * https://code.msdn.microsoft.com/windowsapps/Enumerate-top-level-9aa9d7c1/sourcecode?fileId=44683&pathId=1184961558
         * https://code.msdn.microsoft.com/windowsapps/Enumerate-top-level-9aa9d7c1
         * ==============================================================
         */

        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);

        private bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            int size = GetWindowTextLength(hWnd);
            if (size++ > 0 && IsWindowVisible(hWnd))
            {
                // add window to combobox
                StringBuilder sb = new StringBuilder(size); 
                GetWindowText(hWnd, sb, size);
                cmbActiveWindows.Items.Add(sb);
                ActiveWindowListHandles[index] = hWnd;
                index++;
            }
            return true;
        } 
        private void getActiveWindows()
        {
            ActiveWindowListHandles = new IntPtr[100];
            EnumWindows(new EnumWindowsProc(EnumTheWindows), IntPtr.Zero); 
        }

    }
}
