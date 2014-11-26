
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Slide08
{
	public class Program
	{

        static TextBox textBox;

        static void ButtonPressed(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text + (sender as Button).Text;
        }

		static void Main()
		{

            var form = new Form();
            textBox = new TextBox
            {
                Width = form.ClientSize.Width,
                Height = 20
            };
            form.Controls.Add(textBox);

            var symbols = new[,] { { "7", "4", "1", "*" }, { "8", "5", "2", "0" }, { "9", "6", "3", "#" } };

            var size = new Size(form.ClientSize.Width / symbols.GetLength(0), (form.ClientSize.Height - textBox.Height) / symbols.GetLength(1));

            for(int x=0;x<symbols.GetLength(0);x++)
                for (int y = 0; y < symbols.GetLength(1); y++)
                {
                    var button = new Button
                    {
                        Left = size.Width * x,
                        Top = textBox.Height + size.Height * y,
                        Size = size,
                        Text = symbols[x, y]
                    };
                    var newX = x; // Замыкание!
                    var newY = y;
                    //button.Click += (s, a) => textBox.Text = textBox.Text + symbols[newX, newY]; //Но раньше лямбд не было...
                    button.Click += ButtonPressed;
                    form.Controls.Add(button);
                }
            Application.Run(form);

		}
	}
}