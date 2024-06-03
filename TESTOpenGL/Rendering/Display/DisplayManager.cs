using GLFW;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using static TESTOpenGL.OpenGL.GL;
using System.Drawing;

namespace TESTOpenGL.Rendering.Display
{
    static class DisplayManager
    {
        public static Window Window { get; set; }
        public static Vector2 WindowsSize { get; set; }
         
        public static void CreateWindow(int width, int height, string title)
        {
            WindowsSize = new Vector2(width, height);

            Glfw.Init();

            //opengl 3.3 core profile
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            // width and height for the initial window
            // resizable or not
            // fix so it is in the middle of the screen
            // and a bit of other stuff

            Window = Glfw.CreateWindow(width, height, title, GLFW.Monitor.None, Window.None);

            if (Window == Window.None)
            {
                // error
                return;
            }

            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - width ) / 2;
            int y = (screen.Height - height) / 2;
            Glfw.SetWindowPosition(Window, x, y);

            Glfw.MakeContextCurrent(Window);
            Import(Glfw.GetProcAddress);

            glViewport(0, 0, width, height);
            Glfw.SwapInterval(0); //Vsync is off
        }

        public static void CloseWindow()
        {
            Glfw.Terminate();
        }
    }
}
