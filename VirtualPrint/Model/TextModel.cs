using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPrint.Model
{
    public class TextModel
    {
        private string content;
        private double xPosition;
        private double yPosition;

        public string Content
        {
            get { return content; }
        }

        public double Xposition
        {
            get { return xPosition; }
        }

        public double YPosition
        {
            get { return yPosition; }
        }

        public TextModel(string content, double xPosition, double yPosition)
        {
            this.content = content;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }
    }
}
