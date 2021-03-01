using EvilInfo.Presenter.Utils;
using System;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	public partial class MinionMainMenuForm : Form
	{
		public MinionMainMenuForm()
		{
			InitializeComponent();
		}

		private void MinionMainMenuForm_Load(object sender, EventArgs e)
		{

		}

		private void MinionMainMenuForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			var homeForm = FormFactory.GetFormInstance<HomeForm>();
			homeForm.Show();
		}
	}
}
