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
            for (int CellsNumber = 0; CellsNumber * LinesSettings.CELLS_SIZE <  width; CellsNumber++)
            {
                field.DrawLine(LinesSettings.Instance.CellsColor, CellsNumber * LinesSettings.CELLS_SIZE, height, CellsNumber * LinesSettings.CELLS_SIZE, 0);
            }

            for (int CellsNumber = 0; CellsNumber * LinesSettings.CELLS_SIZE < height; CellsNumber++)
            {
                field.DrawLine(LinesSettings.Instance.CellsColor, 0, CellsNumber * LinesSettings.CELLS_SIZE, width, CellsNumber * LinesSettings.CELLS_SIZE);
            }
        }
    }
}
