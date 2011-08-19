namespace CourseSmartRipper
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.labelBookNumber = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxBookNumber = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.labelStartingPage = new System.Windows.Forms.Label();
			this.textBoxStartingPage = new System.Windows.Forms.TextBox();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelDownloadCounter = new System.Windows.Forms.Label();
			this.textBoxDownloadCounter = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanel1.Controls.Add(this.labelUsername, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPassword, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelBookNumber, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBoxBookNumber, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBoxUsername, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxOutput, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.buttonStart, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelStartingPage, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.textBoxStartingPage, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelDownloadCounter, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.textBoxDownloadCounter, 1, 6);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 241);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// labelUsername
			// 
			this.labelUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(3, 0);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(94, 26);
			this.labelUsername.TabIndex = 0;
			this.labelUsername.Text = "Username";
			this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelPassword
			// 
			this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(3, 26);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(94, 26);
			this.labelPassword.TabIndex = 1;
			this.labelPassword.Text = "Password";
			this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelBookNumber
			// 
			this.labelBookNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelBookNumber.AutoSize = true;
			this.labelBookNumber.Location = new System.Drawing.Point(3, 52);
			this.labelBookNumber.Name = "labelBookNumber";
			this.labelBookNumber.Size = new System.Drawing.Size(94, 26);
			this.labelBookNumber.TabIndex = 2;
			this.labelBookNumber.Text = "Book #";
			this.labelBookNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword.Location = new System.Drawing.Point(103, 29);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(274, 20);
			this.textBoxPassword.TabIndex = 2;
			this.textBoxPassword.Text = "wguzQ6w6fo";
			// 
			// textBoxBookNumber
			// 
			this.textBoxBookNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxBookNumber.Location = new System.Drawing.Point(103, 55);
			this.textBoxBookNumber.Name = "textBoxBookNumber";
			this.textBoxBookNumber.Size = new System.Drawing.Size(274, 20);
			this.textBoxBookNumber.TabIndex = 3;
			this.textBoxBookNumber.Text = "9780136037408";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(103, 3);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(274, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.Text = "micah@zoltu.net";
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxOutput, 2);
			this.textBoxOutput.Location = new System.Drawing.Point(3, 136);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.ReadOnly = true;
			this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxOutput.Size = new System.Drawing.Size(374, 76);
			this.textBoxOutput.TabIndex = 7;
			this.textBoxOutput.TabStop = false;
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Location = new System.Drawing.Point(103, 107);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(274, 23);
			this.buttonStart.TabIndex = 5;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// labelStartingPage
			// 
			this.labelStartingPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelStartingPage.AutoSize = true;
			this.labelStartingPage.Location = new System.Drawing.Point(3, 78);
			this.labelStartingPage.Name = "labelStartingPage";
			this.labelStartingPage.Size = new System.Drawing.Size(94, 26);
			this.labelStartingPage.TabIndex = 9;
			this.labelStartingPage.Text = "Starting Page";
			this.labelStartingPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxStartingPage
			// 
			this.textBoxStartingPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxStartingPage.Location = new System.Drawing.Point(103, 81);
			this.textBoxStartingPage.Name = "textBoxStartingPage";
			this.textBoxStartingPage.Size = new System.Drawing.Size(274, 20);
			this.textBoxStartingPage.TabIndex = 4;
			this.textBoxStartingPage.Text = "toc01";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
			// 
			// labelDownloadCounter
			// 
			this.labelDownloadCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDownloadCounter.AutoSize = true;
			this.labelDownloadCounter.Location = new System.Drawing.Point(3, 215);
			this.labelDownloadCounter.Name = "labelDownloadCounter";
			this.labelDownloadCounter.Size = new System.Drawing.Size(94, 26);
			this.labelDownloadCounter.TabIndex = 10;
			this.labelDownloadCounter.Text = "Dowload Counter";
			this.labelDownloadCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxDownloadCounter
			// 
			this.textBoxDownloadCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDownloadCounter.Location = new System.Drawing.Point(103, 218);
			this.textBoxDownloadCounter.Name = "textBoxDownloadCounter";
			this.textBoxDownloadCounter.Size = new System.Drawing.Size(274, 20);
			this.textBoxDownloadCounter.TabIndex = 11;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(404, 265);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FormMain";
			this.Text = "CourseSmart Ripper";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Label labelBookNumber;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxBookNumber;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxOutput;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelStartingPage;
		private System.Windows.Forms.TextBox textBoxStartingPage;
		private System.Windows.Forms.Label labelDownloadCounter;
		private System.Windows.Forms.TextBox textBoxDownloadCounter;


	}
}
