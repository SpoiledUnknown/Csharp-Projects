using System;
using System.Collections.Generic;
using OpenTK.Windowing.Common;
using BasicTK_2D_Renderer;
using BasicTK_2D_Renderer.Src;
using OpenTK.Mathematics;


const string title = "BasicTK - 2D Renderer";
const int windowHeight = 480, windowWidth = 854;
const VSyncMode syncMode = VSyncMode.On;
const WindowState winState = WindowState.Maximized;
const WindowBorder border = WindowBorder.Resizable;

const int boxCount = 10000;
List<Box> boxList = new List<Box>();

for (int i = 0; i < boxCount; i++)
{
    Random rand = new Random();
    int w = rand.Next(32, 128);
    int h = rand.Next(32, 128);
    int x = rand.Next(0, windowWidth - w);
    int y = rand.Next(0, windowHeight - h);

    float r = (float)rand.NextDouble();
    float g = (float)rand.NextDouble();
    float b = (float)rand.NextDouble();

    boxList.Add(new Box(h, w, x, y, new Color4(r, g, b, 1f)));
}

Game game = new Game(title, windowHeight, windowWidth, boxList, syncMode, winState, border);
game.Run();