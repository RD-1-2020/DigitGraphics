using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitGraphics.Utils
{
    static class DrawTools
    {
        public static void drawField(Graphics field, int width, int height)
        {
            field.Clear(Color.White);
            for (int CellsNumber = 0; CellsNumber * Settings.CELLS_SIZE <  width; CellsNumber++)
            {
                field.DrawLine(Settings.Instance.CellsColor, CellsNumber * Settings.CELLS_SIZE, height, CellsNumber * Settings.CELLS_SIZE, 0);
            }

            for (int CellsNumber = 0; CellsNumber * Settings.CELLS_SIZE < height; CellsNumber++)
            {
                field.DrawLine(Settings.Instance.CellsColor, 0, CellsNumber * Settings.CELLS_SIZE, width, CellsNumber * Settings.CELLS_SIZE);
            }
        }
    }
}
