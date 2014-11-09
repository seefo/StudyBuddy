﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy.Forms.Editors
{
	public partial class SetCreator : Form
	{
		public SetCreator()
		{
			InitializeComponent();

			String[] files = Directory.GetFiles("icons/");

			foreach (String file in files)
            {
				imageList1.Images.Add(Image.FromFile(file));
				Console.WriteLine(file);
				
			}

			this.listView1.View = View.LargeIcon;
			this.imageList1.ImageSize = new Size(74, 74);
			this.listView1.LargeImageList = this.imageList1;

			for(int i = 0; i < imageList1.Images.Count; i++)
			{
				ListViewItem item = new ListViewItem();
				item.ImageIndex = i;
				item.Text = files[i];
				listView1.Items.Add(item);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length == 0) MessageBox.Show("Please enter a name.");
			else if (textBox2.Text.Length == 0) MessageBox.Show("Please enter a description.");
			else
			{
				QuestionSet qs = new QuestionSet(textBox1.Text, textBox2.Text);
				qs.icon = Convert.ToInt32(listView1.SelectedItems[0].Text.Replace("icons/", "").Replace(".png", ""));

				StuddyBuddyForm.sets.Add(qs);
				StuddyBuddyForm.instance.populateForm();

				this.Close();
			}
		}
	}
}
