using System;
using WindowsInput;
using WindowsInput.Native;

namespace TaskOne.Utils
{
    public static class OpenFile
    {
        public static void Open()
        {
            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.TAB).Sleep(200);
            inputSimulator.Keyboard.TextEntry("avatar.png").Sleep(200);
            for (int i = 0; i < 5; i++)
            {
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.TAB).Sleep(200);
            }
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN).Sleep(200);
            inputSimulator.Keyboard.TextEntry(Environment.CurrentDirectory).Sleep(200);
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN).Sleep(200);
            for (int i = 0; i < 8; i++)
            {
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.TAB).Sleep(200);
            }
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN).Sleep(200);
        }
    }
}
