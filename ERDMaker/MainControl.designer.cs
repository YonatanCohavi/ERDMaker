
namespace ERDMaker
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.loadEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.lst_entities = new System.Windows.Forms.CheckedListBox();
            this.txt_filterEntities = new System.Windows.Forms.TextBox();
            this.lst_selected = new System.Windows.Forms.ListBox();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_generateFields = new System.Windows.Forms.CheckBox();
            this.cb_generateOptionSets = new System.Windows.Forms.CheckBox();
            this.cb_generateRelationships = new System.Windows.Forms.CheckBox();
            this.gb_settings = new System.Windows.Forms.GroupBox();
            this.toolStripMenu.SuspendLayout();
            this.gb_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1,
            this.toolStripButton1,
            this.loadEntities,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStripMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1030, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 22);
            this.toolStripButton1.Text = "Close";
            this.toolStripButton1.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // loadEntities
            // 
            this.loadEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadEntities.Image = ((System.Drawing.Image)(resources.GetObject("loadEntities.Image")));
            this.loadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadEntities.Name = "loadEntities";
            this.loadEntities.Size = new System.Drawing.Size(78, 22);
            this.loadEntities.Text = "Load Entities";
            this.loadEntities.Click += new System.EventHandler(this.loadEntities_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(106, 22);
            this.toolStripButton2.Text = "Generate Diagram";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(82, 22);
            this.toolStripButton3.Text = "dbdiagram.io";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // lst_entities
            // 
            this.lst_entities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lst_entities.CheckOnClick = true;
            this.lst_entities.FormattingEnabled = true;
            this.lst_entities.Location = new System.Drawing.Point(7, 184);
            this.lst_entities.Name = "lst_entities";
            this.lst_entities.Size = new System.Drawing.Size(271, 289);
            this.lst_entities.TabIndex = 5;
            this.lst_entities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lst_entities_ItemCheck);
            // 
            // txt_filterEntities
            // 
            this.txt_filterEntities.Location = new System.Drawing.Point(7, 158);
            this.txt_filterEntities.Name = "txt_filterEntities";
            this.txt_filterEntities.Size = new System.Drawing.Size(271, 20);
            this.txt_filterEntities.TabIndex = 6;
            this.txt_filterEntities.TextChanged += new System.EventHandler(this.txt_filterEntities_TextChanged);
            // 
            // lst_selected
            // 
            this.lst_selected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lst_selected.FormattingEnabled = true;
            this.lst_selected.Location = new System.Drawing.Point(284, 184);
            this.lst_selected.Name = "lst_selected";
            this.lst_selected.Size = new System.Drawing.Size(272, 290);
            this.lst_selected.TabIndex = 7;
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(562, 184);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(457, 290);
            this.txt_result.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selected Entities";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "DBML";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "The Generated Diagram is designed to work with dbdiagram.io";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Entity Filter";
            // 
            // cb_generateFields
            // 
            this.cb_generateFields.AutoSize = true;
            this.cb_generateFields.Location = new System.Drawing.Point(16, 21);
            this.cb_generateFields.Name = "cb_generateFields";
            this.cb_generateFields.Size = new System.Drawing.Size(100, 17);
            this.cb_generateFields.TabIndex = 16;
            this.cb_generateFields.Text = "Generate Fields";
            this.cb_generateFields.UseVisualStyleBackColor = true;
            this.cb_generateFields.CheckedChanged += new System.EventHandler(this.cb_generateFields_CheckedChanged);
            // 
            // cb_generateOptionSets
            // 
            this.cb_generateOptionSets.AutoSize = true;
            this.cb_generateOptionSets.Location = new System.Drawing.Point(16, 44);
            this.cb_generateOptionSets.Name = "cb_generateOptionSets";
            this.cb_generateOptionSets.Size = new System.Drawing.Size(128, 17);
            this.cb_generateOptionSets.TabIndex = 17;
            this.cb_generateOptionSets.Text = "Generate Option Sets";
            this.cb_generateOptionSets.UseVisualStyleBackColor = true;
            this.cb_generateOptionSets.CheckedChanged += new System.EventHandler(this.cb_generateOptionSets_CheckedChanged);
            // 
            // cb_generateRelationships
            // 
            this.cb_generateRelationships.AutoSize = true;
            this.cb_generateRelationships.Location = new System.Drawing.Point(16, 67);
            this.cb_generateRelationships.Name = "cb_generateRelationships";
            this.cb_generateRelationships.Size = new System.Drawing.Size(136, 17);
            this.cb_generateRelationships.TabIndex = 18;
            this.cb_generateRelationships.Text = "Generate Relationships";
            this.cb_generateRelationships.UseVisualStyleBackColor = true;
            this.cb_generateRelationships.CheckedChanged += new System.EventHandler(this.cb_generateRelationships_CheckedChanged);
            // 
            // gb_settings
            // 
            this.gb_settings.Controls.Add(this.cb_generateOptionSets);
            this.gb_settings.Controls.Add(this.cb_generateRelationships);
            this.gb_settings.Controls.Add(this.cb_generateFields);
            this.gb_settings.Location = new System.Drawing.Point(7, 28);
            this.gb_settings.Name = "gb_settings";
            this.gb_settings.Size = new System.Drawing.Size(200, 100);
            this.gb_settings.TabIndex = 19;
            this.gb_settings.TabStop = false;
            this.gb_settings.Text = "Settings";
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_settings);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.lst_selected);
            this.Controls.Add(this.txt_filterEntities);
            this.Controls.Add(this.lst_entities);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MainControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1030, 498);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gb_settings.ResumeLayout(false);
            this.gb_settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton loadEntities;
        private System.Windows.Forms.CheckedListBox lst_entities;
        private System.Windows.Forms.TextBox txt_filterEntities;
        private System.Windows.Forms.ListBox lst_selected;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_generateFields;
        private System.Windows.Forms.CheckBox cb_generateOptionSets;
        private System.Windows.Forms.CheckBox cb_generateRelationships;
        private System.Windows.Forms.GroupBox gb_settings;
    }
}
