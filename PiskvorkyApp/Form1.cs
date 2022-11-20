using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PiskvorkyApp
{
	public partial class Form1 : Form
	{
		//btn. 4 * 4 is 5 * 5, max is 14, 12 (is 15, 13)
		private const int btSloupec = 12;
		private const int btRada = 12;
		//winN. 4 is 5, max is btSloupec(if <= btRada) || btRada(if <= btSloupec)
		private const int winNumber = 4;
		private const int btSize = 50;
		private string memory;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			GenerateGameBt(btSloupec, btRada, btSize);
			GenerateOtherComponents();
			CenterToScreen();
		}

		private void btStart_Click(object sender, EventArgs e)
		{
			Label lblHrac = (Label)Controls.Find("lblHrac", false).FirstOrDefault();
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			Button btStart = (Button)Controls.Find("btStart", false).FirstOrDefault();

			lblHrac.Text = txtHrac1.Text;
			btStart.Enabled = false;

			for (int k = 0; k <= btRada; k++)
			{
				for (int l = 0; l <= btSloupec; l++)
				{
					string name2 = String.Format("{0}_{1}", k, l);

					Button button1 = (Button)Controls.Find(name2, false).FirstOrDefault();
					button1.Enabled = true;
				}
			}
		}

		private void btReset_Click(object sender, EventArgs e)
		{
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();
			Button btSave = (Button)Controls.Find("btSave", false).FirstOrDefault();
			Button btStart = (Button)Controls.Find("btStart", false).FirstOrDefault();
			Button btReset = (Button)Controls.Find("btReset", false).FirstOrDefault();
			Button btReset2 = (Button)Controls.Find("btReset2", false).FirstOrDefault();
			Label lblHrac = (Label)Controls.Find("lblHrac", false).FirstOrDefault();

			lblHrac.Text = "...";

			txtHrac1.Text = null;
			txtHrac2.Text = null;
			txtHrac1.Enabled = true;
			txtHrac2.Enabled = true;
			txtHrac1.Visible = true;
			txtHrac2.Visible = true;

			btSave.Enabled = true;
			btStart.Enabled = false;

			btReset.Enabled = false;
			btReset2.Enabled = false;

			for (int x = 0; x <= btRada; x++)
			{
				for (int y = 0; y <= btSloupec; y++)
				{
					string nameXY = String.Format("{0}_{1}", x, y);

					Button button1 = (Button)Controls.Find(nameXY, false).FirstOrDefault();
					button1.Enabled = false;
					button1.BackColor = Color.FromKnownColor(KnownColor.Control);
					button1.BackgroundImage = null;
				}
			}
		}

		private void btReset2_Click(object sender, EventArgs e)
		{
			for (int q = 0; q <= btRada; q++)
			{
				for (int w = 0; w <= btSloupec; w++)
				{
					string nameQW = String.Format("{0}_{1}", q, w);

					Button button1 = (Button)Controls.Find(nameQW, false).FirstOrDefault();
					button1.Enabled = true;
					button1.BackColor = Color.FromKnownColor(KnownColor.Control);
					button1.BackgroundImage = null;
				}
			}

			Label lblHrac = (Label)Controls.Find("lblHrac", false).FirstOrDefault();
			TextBox TextHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			lblHrac.Text = TextHrac1.Text;
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();
			Button btSave = (Button)Controls.Find("btSave", false).FirstOrDefault();
			Button btStart = (Button)Controls.Find("btStart", false).FirstOrDefault();
			Button btReset = (Button)Controls.Find("btReset", false).FirstOrDefault();
			Button btReset2 = (Button)Controls.Find("btReset2", false).FirstOrDefault();

			txtHrac1.Enabled = false;
			txtHrac2.Enabled = false;

			txtHrac1.Visible = false;
			txtHrac2.Visible = false;

			btSave.Enabled = false;
			btStart.Enabled = true;

			btReset.Enabled = true;
			btReset2.Enabled = true;
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtHrac1_2_TextChanged(object sender, EventArgs e)
		{
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();
			Button btSave = (Button)Controls.Find("btSave", false).FirstOrDefault();

			if (txtHrac1.Text != txtHrac2.Text && !String.IsNullOrWhiteSpace(txtHrac1.Text) && !String.IsNullOrWhiteSpace(txtHrac2.Text))
			{
				btSave.Enabled = true;
			}
			else if (!(txtHrac1.Text != txtHrac2.Text && !String.IsNullOrWhiteSpace(txtHrac1.Text) && !String.IsNullOrWhiteSpace(txtHrac2.Text)))
			{
				btSave.Enabled = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Button clickedButton = (Button)sender;
			Button btBack = (Button)Controls.Find("btBack", false).FirstOrDefault();
			Label lblHrac = (Label)Controls.Find("lblHrac", false).FirstOrDefault();
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();

			int indexRada, indexSloupec;
			Int32.TryParse(clickedButton.Name.Split('_')[0], out indexRada);
			Int32.TryParse(clickedButton.Name.Split('_')[1], out indexSloupec);
			
			if (lblHrac.Text == txtHrac1.Text)
			{
				lblHrac.Text = txtHrac2.Text;
				clickedButton.BackColor = Color.Red;
				clickedButton.Enabled = false;
				clickedButton.BackgroundImage = Image.FromFile
				(@".\krizek_50x50.jpg");
				CheckWin(indexRada, indexSloupec, smer.vertikalne, 1);
				CheckWin(indexRada, indexSloupec, smer.horizontalne, 1);
				CheckWin(indexRada, indexSloupec, smer.diagonalneZPrava, 1);
				CheckWin(indexRada, indexSloupec, smer.diagonalneZLeva, 1);

				btBack.Enabled = true;
				memory = string.Format("{0}_{1}", indexRada, indexSloupec);
			}
			else if (lblHrac.Text == txtHrac2.Text)
			{
				lblHrac.Text = txtHrac1.Text;
				clickedButton.BackColor = Color.Blue;
				clickedButton.Enabled = false;
				clickedButton.BackgroundImage = Image.FromFile
				(@".\kolecko_50x50.jpg");
				CheckWin(indexRada, indexSloupec, smer.vertikalne, 2);
				CheckWin(indexRada, indexSloupec, smer.horizontalne, 2);
				CheckWin(indexRada, indexSloupec, smer.diagonalneZPrava, 2);
				CheckWin(indexRada, indexSloupec, smer.diagonalneZLeva, 2);

				btBack.Enabled = true;
				memory = string.Format("{0}_{1}", indexRada, indexSloupec);
			}
		}
		private void btBack_Click(object sender, EventArgs e)
		{
			Button btBack = (Button)Controls.Find("btBack", false).FirstOrDefault();
			Label lblHrac = (Label)Controls.Find("lblHrac", false).FirstOrDefault();
			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();

			btBack.Enabled = false;

			int indexRada, indexSloupec;
			Int32.TryParse(memory.Split('_')[0], out indexRada);
			Int32.TryParse(memory.Split('_')[1], out indexSloupec);

			string name = string.Format("{0}_{1}", indexRada, indexSloupec);
			Button button1 = (Button)Controls.Find(name, false).FirstOrDefault();
			button1.BackColor = Color.FromKnownColor(KnownColor.Control);
			button1.BackgroundImage = null;
			button1.Enabled = true;

			if (lblHrac.Text == txtHrac1.Text)
			{
				lblHrac.Text = txtHrac2.Text;
			}
			else if (lblHrac.Text == txtHrac2.Text)
			{
				lblHrac.Text = txtHrac1.Text;
			}

			memory = null;
		}
		private void GenerateGameBt(int btSloupec, int btRada, int btSize)
		{
			//set title
			Text = String.Format("Piskvorky: {0},{1}", btSloupec + 1, btRada + 1);

			//const int btSize2 = btSize * 2;

			int frSizeX = ((btSloupec + 1) * btSize) + 500;
			int frSizeY = ((btRada + 1) * btSize) + 80;
			Size = new Size(frSizeX, frSizeY);

			const int startPoseY = 10;
			int startPoseX = 400;

			for (int i = 0; i <= btRada; i++)
			{
				for (int j = 0; j <= btSloupec; j++)
				{
					string name = String.Format("{0}_{1}", i, j);

					if (j == 0 && i == 0)
					{
						AddButton(startPoseX, startPoseY, btSize, name);
					}
					else
					{
						int poseX = (j * btSize) + startPoseX;
						int poseY = (i * btSize) + startPoseY;

						AddButton(poseX, poseY, btSize, name);
					}

				}
			}
		}

		private void AddButton(int poseX, int poseY, int btSize, string name)
		{
			Button button1 = new Button();
			button1.Location = new Point(poseX, poseY);
			button1.Size = new Size(btSize, btSize);
			button1.Enabled = false;
			//button1.Text = name;
			button1.Name = name;
			button1.BackColor = Color.FromKnownColor(KnownColor.Control);

			button1.Click += new EventHandler(button1_Click);
			Controls.Add(button1);
		}

		private void GenerateOtherComponents()
		{
			//other stuff 
			//Buttons
			Button btStart = new Button();
			btStart.Name = "btStart";
			btStart.Location = new Point(10, 10);
			btStart.Size = new Size(100, 30);
			btStart.Text = "Začít hru";
			btStart.Enabled = false;

			Button btReset = new Button();
			btReset.Name = "btReset";
			btReset.Location = new Point(110, 10);
			btReset.Size = new Size(100, 30);
			btReset.Text = "Resetovat";
			btReset.Enabled = false;

			Button btReset2 = new Button();
			btReset2.Name = "btReset2";
			btReset2.Location = new Point(210, 10);
			btReset2.Size = new Size(200, 30);
			btReset2.Text = "Resetovat se stejnými hráči";
			btReset2.Enabled = false;

			Button btSave = new Button();
			btSave.Name = "btSave";
			btSave.Location = new Point(10, 130);
			btSave.Size = new Size(200, 30);
			btSave.Text = "Ulož zadané hráče";
			btSave.Enabled = false;

			Button btClose = new Button();
			btClose.Name = "btClose";
			btClose.Location = new Point(305, 130);
			btClose.Size = new Size(95, 30);
			btClose.Text = "Ukončit";
			btClose.Enabled = true;

			Button btBack = new Button();
			btBack.Name = "btBack";
			btBack.Location = new Point(210, 130);
			btBack.Size = new Size(95, 30);
			btBack.Text = "Krok Spět.";
			btBack.Enabled = false;

			btBack.Click += new EventHandler(btBack_Click);
			btStart.Click += new EventHandler(btStart_Click);
			btReset.Click += new EventHandler(btReset_Click);
			btReset2.Click += new EventHandler(btReset2_Click);
			btSave.Click += new EventHandler(btSave_Click);
			btClose.Click += new EventHandler(btClose_Click);

			Controls.Add(btStart);
			Controls.Add(btReset);
			Controls.Add(btReset2);
			Controls.Add(btSave);
			Controls.Add(btClose);
			Controls.Add(btBack);
			//TextBoxs
			TextBox txtHrac1 = new TextBox();
			txtHrac1.Name = "txtHrac1";
			txtHrac1.Location = new Point(110, 60);
			txtHrac1.Size = new Size(100, 30);

			TextBox txtHrac2 = new TextBox();
			txtHrac2.Name = "txtHrac2";
			txtHrac2.Location = new Point(110, 90);
			txtHrac2.Size = new Size(100, 30);

			txtHrac1.TextChanged += new EventHandler(txtHrac1_2_TextChanged);
			txtHrac2.TextChanged += new EventHandler(txtHrac1_2_TextChanged);

			Controls.Add(txtHrac1);
			Controls.Add(txtHrac2);
			//labes
			Label lblInfo1 = new Label();
			lblInfo1.Location = new Point(10, 60);
			lblInfo1.Text = "Hráč1:";

			Label lblInfo2 = new Label();
			lblInfo2.Location = new Point(10, 90);
			lblInfo2.Text = "Hráč2:";

			Label lblInfo3 = new Label();
			lblInfo3.Location = new Point(10, 40);
			lblInfo3.Text = "Na tahu je Hráč:";

			Label lblHrac = new Label();
			lblHrac.Name = "lblHrac";
			lblHrac.Location = new Point(110, 40);
			lblHrac.Text = "...";

			Controls.Add(lblInfo1);
			Controls.Add(lblInfo2);
			Controls.Add(lblInfo3);
			Controls.Add(lblHrac);
		}

		private enum smer 
		{ 
			vertikalne = 1,
			horizontalne = 2,
			diagonalneZPrava = 3,
			diagonalneZLeva = 4
		}

		private void CheckWin(int indexRada, int indexSloupec, smer smerHledani, int hracNumber)
		{
			//{rada}_{sloupec}
			Color hracBarva = hracNumber == 1 ? Color.Red : Color.Blue;
			bool nextWhile = false;
			int pluser = -1;
			int counter = 0;

			string bName;
			switch (smerHledani)
			{
				case smer.horizontalne:
					bName = string.Format("{0}_{1}", indexRada, indexSloupec - winNumber);
					break;

				case smer.vertikalne:
					bName = string.Format("{0}_{1}", indexRada - winNumber, indexSloupec);
					break;

				case smer.diagonalneZPrava:
					bName = string.Format("{0}_{1}", indexRada - winNumber, indexSloupec + winNumber);
					break;

				case smer.diagonalneZLeva:
					bName = string.Format("{0}_{1}", indexRada - winNumber, indexSloupec - winNumber);
					break;

				default:
					throw new Exception();
			}

			do
			{
				pluser++;

				int indexRadaInWhile, indexSloupecInWhile;
				Int32.TryParse(bName.Split('_')[0], out indexRadaInWhile);
				Int32.TryParse(bName.Split('_')[1], out indexSloupecInWhile);

				string nextBName;
				switch (smerHledani)
				{
					case smer.horizontalne:
						nextBName = string.Format("{0}_{1}", indexRadaInWhile, indexSloupecInWhile + pluser);
						break;

					case smer.vertikalne:
						nextBName = string.Format("{0}_{1}", indexRadaInWhile + pluser, indexSloupecInWhile);
						break;

					case smer.diagonalneZPrava:
						nextBName = string.Format("{0}_{1}", indexRadaInWhile + pluser, indexSloupecInWhile - pluser);
						break;

					case smer.diagonalneZLeva:
						nextBName = string.Format("{0}_{1}", indexRadaInWhile + pluser, indexSloupecInWhile + pluser);
						break;

					default:
						throw new Exception();
				}

				Button nextButton = (Button)Controls.Find(nextBName, false).FirstOrDefault();

				if (nextButton == null)
				{
					nextWhile = true;

					bool nextWhileFalseIf;
					switch (smerHledani)
					{
						case smer.horizontalne:
							nextWhileFalseIf = (indexSloupecInWhile + pluser) > 12 || (indexSloupecInWhile + pluser) > (indexSloupec + winNumber);
							break;

						case smer.vertikalne:
							nextWhileFalseIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						case smer.diagonalneZPrava:
							nextWhileFalseIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						case smer.diagonalneZLeva:
							nextWhileFalseIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						default:
							throw new Exception();
					}

					if (nextWhileFalseIf)
					{
						nextWhile = false;
					}
				}
				else
				{
					if (nextButton.BackColor == hracBarva)
					{
						counter++;
					}
					else if (nextButton.BackColor != hracBarva)
					{
						counter = 0;
					}

					if (counter >= 5)
					{
						Win(hracNumber);
						nextWhile = false;
					}
					else if (counter < 5)
					{
						nextWhile = true;
					}

					bool nextWhileIf;
					switch (smerHledani)
					{
						case smer.horizontalne:
							nextWhileIf = (indexSloupecInWhile + pluser) > 12 || (indexSloupecInWhile + pluser) > (indexSloupec + winNumber);
							break;

						case smer.vertikalne:
							nextWhileIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						case smer.diagonalneZPrava:
							nextWhileIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						case smer.diagonalneZLeva:
							nextWhileIf = (indexRadaInWhile + pluser) > 12 || (indexRadaInWhile + pluser) > (indexRada + winNumber);
							break;

						default:
							throw new Exception();
					}

					if (nextWhileIf)
					{
						nextWhile = false;
					}
				}

			} while (nextWhile == true);
		}

		private void Win(int Winner)
		{
			Button btBack = (Button)Controls.Find("btBack", false).FirstOrDefault();
			btBack.Enabled = false;

			for (int e = 0; e <= btRada; e++)
			{
				for (int n = 0; n <= btSloupec; n++)
				{
					string name2 = String.Format("{0}_{1}", e, n);

					Button button1 = (Button)Controls.Find(name2, false).FirstOrDefault();
					button1.Enabled = false;
				}
			}

			TextBox txtHrac1 = (TextBox)Controls.Find("txtHrac1", false).FirstOrDefault();
			TextBox txtHrac2 = (TextBox)Controls.Find("txtHrac2", false).FirstOrDefault();

			if (Winner == 1)
			{
				string msg1 = string.Format("Vyhrál hráč: {0}! Pro další hru použíte reset.", txtHrac1.Text);
				MessageBox.Show(msg1);
			}
			else if (Winner == 2)
			{
				string msg2 = string.Format("Vyhrál hráč: {0}! Pro další hru použíte reset.", txtHrac2.Text);
				MessageBox.Show(msg2);
			}
		}
	}
}