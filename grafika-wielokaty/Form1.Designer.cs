namespace grafika_wielokaty
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NewPolygonButton = new System.Windows.Forms.Button();
            this.contextMenuStripVert = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDeleteVert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDegree = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteVertLimit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEdge = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddVert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemVerticalEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHorizontalEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClearEdgeLimit = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStripVert.SuspendLayout();
            this.contextMenuStripEdge.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 549);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 543);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // NewPolygonButton
            // 
            this.NewPolygonButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPolygonButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.NewPolygonButton.Location = new System.Drawing.Point(3, 3);
            this.NewPolygonButton.Name = "NewPolygonButton";
            this.NewPolygonButton.Size = new System.Drawing.Size(191, 41);
            this.NewPolygonButton.TabIndex = 1;
            this.NewPolygonButton.Text = "Nowy Wielokąt";
            this.NewPolygonButton.UseVisualStyleBackColor = true;
            this.NewPolygonButton.Click += new System.EventHandler(this.NewPolygonButton_Click);
            // 
            // contextMenuStripVert
            // 
            this.contextMenuStripVert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeleteVert,
            this.toolStripSeparator2,
            this.toolStripMenuItemDegree,
            this.toolStripMenuItemDeleteVertLimit});
            this.contextMenuStripVert.Name = "contextMenuStrip1";
            this.contextMenuStripVert.Size = new System.Drawing.Size(167, 76);
            // 
            // toolStripMenuItemDeleteVert
            // 
            this.toolStripMenuItemDeleteVert.AutoToolTip = true;
            this.toolStripMenuItemDeleteVert.Name = "toolStripMenuItemDeleteVert";
            this.toolStripMenuItemDeleteVert.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemDeleteVert.Text = "Usuń wierzchołek";
            this.toolStripMenuItemDeleteVert.ToolTipText = "Usuwa wybrany wierzchołek";
            this.toolStripMenuItemDeleteVert.Click += new System.EventHandler(this.toolStripMenuItemDeleteVert_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // toolStripMenuItemDegree
            // 
            this.toolStripMenuItemDegree.AutoToolTip = true;
            this.toolStripMenuItemDegree.Name = "toolStripMenuItemDegree";
            this.toolStripMenuItemDegree.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemDegree.Text = "Ustaw kąt";
            this.toolStripMenuItemDegree.ToolTipText = "Ustawia stały kąt dla wybranego wierzchołka";
            this.toolStripMenuItemDegree.Click += new System.EventHandler(this.toolStripMenuItemDegree_Click);
            // 
            // toolStripMenuItemDeleteVertLimit
            // 
            this.toolStripMenuItemDeleteVertLimit.AutoToolTip = true;
            this.toolStripMenuItemDeleteVertLimit.Name = "toolStripMenuItemDeleteVertLimit";
            this.toolStripMenuItemDeleteVertLimit.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemDeleteVertLimit.Text = "Usuń relacje";
            this.toolStripMenuItemDeleteVertLimit.ToolTipText = "Usuwa ograniczenie dla danego wierzchołka";
            this.toolStripMenuItemDeleteVertLimit.Click += new System.EventHandler(this.toolStripMenuItemDeleteVertLimit_Click);
            // 
            // contextMenuStripEdge
            // 
            this.contextMenuStripEdge.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddVert,
            this.toolStripSeparator1,
            this.toolStripMenuItemVerticalEdge,
            this.toolStripMenuItemHorizontalEdge,
            this.toolStripMenuItemClearEdgeLimit});
            this.contextMenuStripEdge.Name = "contextMenuStripEdge";
            this.contextMenuStripEdge.Size = new System.Drawing.Size(171, 98);
            // 
            // toolStripMenuItemAddVert
            // 
            this.toolStripMenuItemAddVert.AutoToolTip = true;
            this.toolStripMenuItemAddVert.Name = "toolStripMenuItemAddVert";
            this.toolStripMenuItemAddVert.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemAddVert.Text = "Dodaj wierzchołek";
            this.toolStripMenuItemAddVert.ToolTipText = "Dodaje nowy wierzchołek w środku wybranej krawędzi";
            this.toolStripMenuItemAddVert.Click += new System.EventHandler(this.toolStripMenuItemAddVert_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItemVerticalEdge
            // 
            this.toolStripMenuItemVerticalEdge.Name = "toolStripMenuItemVerticalEdge";
            this.toolStripMenuItemVerticalEdge.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemVerticalEdge.Text = "Pion";
            this.toolStripMenuItemVerticalEdge.ToolTipText = "Ustawia wybraną krawędź jako pionową";
            this.toolStripMenuItemVerticalEdge.Click += new System.EventHandler(this.toolStripMenuItemVerticalEdge_Click);
            // 
            // toolStripMenuItemHorizontalEdge
            // 
            this.toolStripMenuItemHorizontalEdge.Name = "toolStripMenuItemHorizontalEdge";
            this.toolStripMenuItemHorizontalEdge.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemHorizontalEdge.Text = "Poziom";
            this.toolStripMenuItemHorizontalEdge.ToolTipText = "Ustawia wybraną krawędź jako poziomą";
            this.toolStripMenuItemHorizontalEdge.Click += new System.EventHandler(this.toolStripMenuItemHorizontalEdge_Click);
            // 
            // toolStripMenuItemClearEdgeLimit
            // 
            this.toolStripMenuItemClearEdgeLimit.AutoToolTip = true;
            this.toolStripMenuItemClearEdgeLimit.Name = "toolStripMenuItemClearEdgeLimit";
            this.toolStripMenuItemClearEdgeLimit.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItemClearEdgeLimit.Text = "Usuń relacje";
            this.toolStripMenuItemClearEdgeLimit.ToolTipText = "Usuwa ograniczenia dla wybranej krawędzi";
            this.toolStripMenuItemClearEdgeLimit.Click += new System.EventHandler(this.toolStripMenuItemClearEdgeLimit_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.NewPolygonButton);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(628, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 95);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Nowe Koło";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Simple Wielokąt Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStripVert.ResumeLayout(false);
            this.contextMenuStripEdge.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NewPolygonButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripVert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteVert;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEdge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddVert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVerticalEdge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHorizontalEdge;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearEdgeLimit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDegree;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteVertLimit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
    }
}

