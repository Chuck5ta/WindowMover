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

        Process[] ActiveWindowList;


        [DllImport("user32.dll")]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        public static IntPtr HWND_TOPMOST = (IntPtr)(-1);
        public static IntPtr HWND_TOP = (IntPtr)(0);
        



        public const int SWP_SHOWWINDOW = 0x0040;


        public Form1()
        {
            InitializeComponent();

            acquireScreenDetails();

        }


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

            //       cbmListOfScreens.Items.Add("AHHHHHHHH");
        } // END OF acquireScreenDetails()


        private void getProcesses()
        {
            Process[] processlist = Process.GetProcesses();

            ActiveWindowList = new Process[100];

            int idx = 0;
            foreach (Process process in processlist)
            {
                // store only the processes that are actually windows
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    ActiveWindowList[idx] = process; // store the window's process
                    cmbActiveWindows.Items.Add(process.MainWindowTitle);
                    idx++;
                }
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
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect); 

        private void btnMoveWindow_Click(object sender, EventArgs e)
        {
            // move the windows based on the idx of the window and the idx of the screen
            int iCurrentlySelectedWindow = cmbActiveWindows.SelectedIndex;
            int iCurrentlySelectedScreen = cmbAvailableScreens.SelectedIndex;

            // move the window to the screen

   //         if (ActiveWindowList[iCurrentlySelectedWindow] != null)
   //         {
                Process gameClientProc = ActiveWindowList[iCurrentlySelectedWindow];
                int bobo = gameClientProc.Id;
     //       }
     //       else
     //           MessageBox.Show("shit");

                RECT pRect;
                Size cSize = new Size();
                // get coordinates relative to window
                GetWindowRect(gameClientProc.MainWindowHandle, out pRect);

                cSize.Width = pRect.Right - pRect.Left;
                cSize.Height = pRect.Bottom - pRect.Top;

        //        SetWindowPos(gameClientProc.MainWindowHandle, HWND_TOP, realWorldScreens[iCurrentlySelectedScreen].screenTopLeftXCoord, realWorldScreens[iCurrentlySelectedScreen].screenTopLeftYCoord, cSize.Width, cSize.Height, SWP_SHOWWINDOW);
            
                SetWindowPos(gameClientProc.MainWindowHandle, HWND_TOP, 0, 0, cSize.Width, cSize.Height, SWP_SHOWWINDOW);
            

        }

        private void cmbAvailableScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Screen: " + cmbAvailableScreens.SelectedIndex.ToString());
        }

        private void cmbActiveWindows_Click(object sender, EventArgs e)
        {
            cmbActiveWindows.Items.Clear();
            getProcesses();
        }

    }
}
