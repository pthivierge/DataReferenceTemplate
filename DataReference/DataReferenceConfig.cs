using System;
using System.Globalization;
using System.Windows.Forms;


namespace OSIsoft.AF.Asset.DataReference
{	
	internal class DataReferenceConfigUI : System.Windows.Forms.Form
	{
		private AFDataReference dataReference=null;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

//'<filename:Constructor>
public DataReferenceConfigUI(AFDataReference dataReference, bool bReadOnly) : base()
{
	// Required for Windows Form Designer support
	InitializeComponent();
   

	// save for persistence
	this.dataReference = dataReference;

	if (bReadOnly)
	{
		btnOK.Visible = false;
		btnOK.Enabled = false;
		btnCancel.Left = (btnOK.Left + btnCancel.Left) / 2;
		btnCancel.Text = "Close";
		this.AcceptButton = btnCancel;

		// Set ReadOnly stuff
		// txtMW.ReadOnly = true;
	}

	// Initialize the text field(s) of the Configuration Dialog
	// this.txtMW.Text = dataReference.MolecularWeight.ToString(CultureInfo.CurrentCulture);
}
//'</filename:Constructor>



/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override void Dispose( bool disposing )
{
	if( disposing )
	{
		if(components != null)
		{
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataReferenceConfigUI));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // DataReferenceConfigUI
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataReferenceConfigUI";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

		}
		#endregion

private void btnOK_Click(object sender, System.EventArgs e)
{
	// save the settings
	if (!GetValuesFromForm())
	{
		// don't close if validation error
		DialogResult = DialogResult.None;
	}
}

//'<filename:GetValuesFromForm>
private bool GetValuesFromForm()
{
	try
	{
	    string configuration;
			
		try
		{
            // configuration="something"
		}
		catch
		{
			
			MessageBox.Show("configuration error");
			return false;
		}
			
		//dataReference.something = configuration;
	}
	catch (Exception ex)
	{
		MessageBox.Show(String.Format(CultureInfo.CurrentCulture, "Unable to apply changes: {0}", ex.Message), "Error");
		return false;
	}
	return true;
}
//'</filename:GetValuesFromForm>
}
}
