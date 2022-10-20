using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Piskvorky_3x3_App
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void btStart_Click(object sender, EventArgs e)
		{
			btReset.Enabled = true;
			btStart.Enabled = false;

			txtHr1.Enabled = true;
			txtHr2.Enabled = true;

			btUloz.Enabled = false;

			txtHr1.Visible = true;
			txtHr2.Visible = true;

			lbl2.Visible = true;
			lbl3.Visible = true;

			btUloz.Visible = true;

			bt1.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt2.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt3.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt4.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt5.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt6.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt7.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt8.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt9.BackColor = Color.FromKnownColor(KnownColor.Control);
		}
		private void btReset_Click(object sender, EventArgs e)
		{
			txtHr1.Enabled = true;
			txtHr2.Enabled = true;

			txtHr1.Visible = true;
			txtHr2.Visible = true;

			lbl2.Visible = true;
			lbl3.Visible = true;

			bt1.Enabled = false;
			bt2.Enabled = false;
			bt3.Enabled = false;
			bt4.Enabled = false;
			bt5.Enabled = false;
			bt6.Enabled = false;
			bt7.Enabled = false;
			bt8.Enabled = false;
			bt9.Enabled = false;

			bt1.BackgroundImage = null;
			bt2.BackgroundImage = null;
			bt3.BackgroundImage = null;
			bt4.BackgroundImage = null;
			bt5.BackgroundImage = null;
			bt6.BackgroundImage = null;
			bt7.BackgroundImage = null;
			bt8.BackgroundImage = null;
			bt9.BackgroundImage = null;

			bt1.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt2.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt3.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt4.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt5.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt6.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt7.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt8.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt9.BackColor = Color.FromKnownColor(KnownColor.Control);

			string Hrac1 = "";
			string Hrac2 = "";

			txtHr1.Text = "";
			txtHr2.Text = "";

			lblVyherce.Text = "";
			lblHrac.Text = "";
			lblInfo2.Text = "";
			
			btReset2.Enabled = false;
		}
		private void btReset2_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			txtHr1.Enabled = false;
			txtHr2.Enabled = false;

			txtHr1.Visible = false;
			txtHr2.Visible = false;

			lbl2.Visible = false;
			lbl3.Visible = false;

			bt1.Enabled = true;
			bt2.Enabled = true;
			bt3.Enabled = true;
			bt4.Enabled = true;
			bt5.Enabled = true;
			bt6.Enabled = true;
			bt7.Enabled = true;
			bt8.Enabled = true;
			bt9.Enabled = true;

			bt1.BackgroundImage = null;
			bt2.BackgroundImage = null;
			bt3.BackgroundImage = null;
			bt4.BackgroundImage = null;
			bt5.BackgroundImage = null;
			bt6.BackgroundImage = null;
			bt7.BackgroundImage = null;
			bt8.BackgroundImage = null;
			bt9.BackgroundImage = null;

			bt1.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt2.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt3.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt4.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt5.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt6.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt7.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt8.BackColor = Color.FromKnownColor(KnownColor.Control);
			bt9.BackColor = Color.FromKnownColor(KnownColor.Control);

			lblVyherce.Text = "";
			lblHrac.Text = Hrac1;
			lblInfo2.Text = "";
		}
		private void btClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void btUloz_Click(object sender, EventArgs e)
		{
			txtHr1.Enabled = false;
			txtHr2.Enabled = false;

			btUloz.Enabled = false;

			txtHr1.Visible = false;
			txtHr2.Visible = false;

			lbl2.Visible = false;
			lbl3.Visible = false;

			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			bt1.Enabled = true;
			bt2.Enabled = true;
			bt3.Enabled = true;
			bt4.Enabled = true;
			bt5.Enabled = true;
			bt6.Enabled = true;
			bt7.Enabled = true;
			bt8.Enabled = true;
			bt9.Enabled = true;

			if (Hrac1 != "" || Hrac2 != "") 
			{
				btReset2.Enabled = true;
			}
			
			lbl1.Visible = true;
			lblHrac.Text = Hrac1;
		}
		private void txtHr1_TextChanged(object sender, EventArgs e)
		{
			if (txtHr1.Text == "" || txtHr2.Text == "")
			{
				btUloz.Enabled = false;
			}
			else
			{
				if (txtHr1.Text == txtHr2.Text)
				{
					btUloz.Enabled = false;
				}
				else
				{
					btUloz.Enabled = true;
				}
			}
		}
		private void txtHr2_TextChanged(object sender, EventArgs e)
		{
			if (txtHr1.Text == "" || txtHr2.Text == "")
			{
				btUloz.Enabled = false;
			}
			else
			{
				if (txtHr1.Text == txtHr2.Text)
				{
					btUloz.Enabled = false;
				}
				else
				{
					btUloz.Enabled = true;
				}
			}
		}
		private void bt1_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt1.BackColor = Color.Blue;
				bt1.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt1.BackColor = Color.Red;
				bt1.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt1.Enabled = false;
			Vyhra();
		}
		private void bt2_Click_1(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt2.BackColor = Color.Blue;
				bt2.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt2.BackColor = Color.Red;
				bt2.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt2.Enabled = false;
			Vyhra();
		}
		private void bt3_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt3.BackColor = Color.Blue;
				bt3.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt3.BackColor = Color.Red;
				bt3.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt3.Enabled = false;
			Vyhra();
		}

		private void bt4_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt4.BackColor = Color.Blue;
				bt4.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt4.BackColor = Color.Red;
				bt4.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt4.Enabled = false;
			Vyhra();
		}

		private void bt5_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt5.BackColor = Color.Blue;
				bt5.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt5.BackColor = Color.Red;
				bt5.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt5.Enabled = false;
			Vyhra();
		}

		private void bt6_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt6.BackColor = Color.Blue;
				bt6.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt6.BackColor = Color.Red;
				bt6.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt6.Enabled = false;
			Vyhra();
		}

		private void bt7_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt7.BackColor = Color.Blue;
				bt7.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt7.BackColor = Color.Red;
				bt7.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt7.Enabled = false;
			Vyhra();
		}

		private void bt8_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt8.BackColor = Color.Blue;
				bt8.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt8.BackColor = Color.Red;
				bt8.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt8.Enabled = false;
			Vyhra();
		}

		private void bt9_Click(object sender, EventArgs e)
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;

			if (lblHrac.Text == Hrac1)
			{
				bt9.BackColor = Color.Blue;
				bt9.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\kolecko.jpg");
			}
			else
			{
				bt9.BackColor = Color.Red;
				bt9.BackgroundImage = Image.FromFile
				(@"C:\Users\matej\Documents\programy ze studia\Piskvorky_3x3_App\Piskvorky_3x3_App\bin\Debug\krizek.jpg");
			}

			if (lblHrac.Text == Hrac1)
			{
				lblHrac.Text = Hrac2;
			}
			else
			{
				lblHrac.Text = Hrac1;
			}
			bt9.Enabled = false;
			Vyhra();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
		private void Vyhra()
		{
			string Hrac1 = txtHr1.Text;
			string Hrac2 = txtHr2.Text;
			if (((bt3.BackColor == Color.Blue && bt6.BackColor == Color.Blue && bt9.BackColor == Color.Blue) 
				|| (bt2.BackColor == Color.Blue && bt5.BackColor == Color.Blue && bt8.BackColor == Color.Blue) 
				|| (bt1.BackColor == Color.Blue && bt4.BackColor == Color.Blue && bt7.BackColor == Color.Blue)) 
				|| ((bt1.BackColor == Color.Blue && bt2.BackColor == Color.Blue && bt3.BackColor == Color.Blue) 
				|| (bt6.BackColor == Color.Blue && bt5.BackColor == Color.Blue && bt4.BackColor == Color.Blue) 
				|| (bt7.BackColor == Color.Blue && bt8.BackColor == Color.Blue && bt9.BackColor == Color.Blue)) 
				|| (bt7.BackColor == Color.Blue && bt5.BackColor == Color.Blue && bt3.BackColor == Color.Blue) 
				|| (bt9.BackColor == Color.Blue && bt5.BackColor == Color.Blue && bt1.BackColor == Color.Blue))
			{
				 lblInfo2.Text = "Výherce";
				 lblVyherce.Text = Hrac1;

				btReset.Enabled = true;

				bt1.Enabled = false;
				bt2.Enabled = false;
				bt3.Enabled = false;
				bt4.Enabled = false;
				bt5.Enabled = false;
				bt6.Enabled = false;
				bt7.Enabled = false;
				bt8.Enabled = false;
				bt9.Enabled = false;
			}
			else if (((bt3.BackColor == Color.Red && bt6.BackColor == Color.Red && bt9.BackColor == Color.Red)
				    || (bt2.BackColor == Color.Red && bt5.BackColor == Color.Red && bt8.BackColor == Color.Red)
				    || (bt1.BackColor == Color.Red && bt4.BackColor == Color.Red && bt7.BackColor == Color.Red))
				    || ((bt1.BackColor == Color.Red && bt2.BackColor == Color.Red && bt3.BackColor == Color.Red)
				    || (bt6.BackColor == Color.Red && bt5.BackColor == Color.Red && bt4.BackColor == Color.Red)
				    || (bt7.BackColor == Color.Red && bt8.BackColor == Color.Red && bt9.BackColor == Color.Red))
				    || (bt7.BackColor == Color.Red && bt5.BackColor == Color.Red && bt3.BackColor == Color.Red)
				    || (bt9.BackColor == Color.Red && bt5.BackColor == Color.Red && bt1.BackColor == Color.Red))
			     {
				      lblInfo2.Text = "Výherce";
				      lblVyherce.Text = Hrac2;

				      btReset.Enabled = true;

				      bt1.Enabled = false;
				      bt2.Enabled = false;
				      bt3.Enabled = false;
				      bt4.Enabled = false;
				      bt5.Enabled = false;
				      bt6.Enabled = false;
				      bt7.Enabled = false;
				      bt8.Enabled = false;
				      bt9.Enabled = false;
			     }
			     else if (((bt1.BackColor == Color.Red || bt1.BackColor == Color.Blue) &&
						 ( bt2.BackColor == Color.Red || bt2.BackColor == Color.Blue) &&
						 ( bt3.BackColor == Color.Red || bt3.BackColor == Color.Blue) &&
						 ( bt4.BackColor == Color.Red || bt4.BackColor == Color.Blue) &&
						 ( bt5.BackColor == Color.Red || bt5.BackColor == Color.Blue) &&
						 ( bt6.BackColor == Color.Red || bt6.BackColor == Color.Blue) &&
						 ( bt7.BackColor == Color.Red || bt7.BackColor == Color.Blue) &&
						 ( bt8.BackColor == Color.Red || bt8.BackColor == Color.Blue) &&
						 ( bt9.BackColor == Color.Red || bt9.BackColor == Color.Blue)))
					  {
				          lblVyherce.Text = "remíza";
			          }
		}
	}
}
