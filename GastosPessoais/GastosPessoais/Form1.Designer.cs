namespace GastosPessoais
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lst = new System.Windows.Forms.ListBox();
            this.txtRotulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRem = new System.Windows.Forms.Button();
            this.btnRel = new System.Windows.Forms.Button();
            this.rdbReceita = new System.Windows.Forms.RadioButton();
            this.rdbDespesa = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblListCount = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lst
            // 
            this.Lst.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lst.FormattingEnabled = true;
            this.Lst.ItemHeight = 16;
            this.Lst.Location = new System.Drawing.Point(20, 39);
            this.Lst.Margin = new System.Windows.Forms.Padding(4);
            this.Lst.Name = "Lst";
            this.Lst.Size = new System.Drawing.Size(441, 180);
            this.Lst.TabIndex = 14;
            this.Lst.SelectedIndexChanged += new System.EventHandler(this.Lst_SelectedIndexChanged);
            this.Lst.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Lst_Format);
            this.Lst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lst_KeyDown);
            this.Lst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lst_MouseDown);
            // 
            // txtRotulo
            // 
            this.txtRotulo.BackColor = System.Drawing.SystemColors.Control;
            this.txtRotulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRotulo.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRotulo.Location = new System.Drawing.Point(11, 272);
            this.txtRotulo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRotulo.Name = "txtRotulo";
            this.txtRotulo.Size = new System.Drawing.Size(304, 23);
            this.txtRotulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 252);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Rótulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 252);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Valor";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.SystemColors.Control;
            this.txtValor.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(324, 272);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(132, 23);
            this.txtValor.TabIndex = 3;
            this.txtValor.TextChanged += new System.EventHandler(this.TxtValor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValor_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(11, 304);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.MinimumSize = new System.Drawing.Size(0, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(187, 304);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.MinimumSize = new System.Drawing.Size(0, 25);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "&Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnRem
            // 
            this.btnRem.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRem.Location = new System.Drawing.Point(363, 304);
            this.btnRem.Margin = new System.Windows.Forms.Padding(4);
            this.btnRem.MinimumSize = new System.Drawing.Size(0, 25);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(100, 28);
            this.btnRem.TabIndex = 8;
            this.btnRem.Text = "Re&mover";
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.BtnRem_Click);
            // 
            // btnRel
            // 
            this.btnRel.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRel.Location = new System.Drawing.Point(244, 340);
            this.btnRel.Margin = new System.Windows.Forms.Padding(4);
            this.btnRel.MinimumSize = new System.Drawing.Size(0, 25);
            this.btnRel.Name = "btnRel";
            this.btnRel.Size = new System.Drawing.Size(219, 28);
            this.btnRel.TabIndex = 10;
            this.btnRel.Text = "Relat&ório";
            this.btnRel.UseVisualStyleBackColor = true;
            this.btnRel.Click += new System.EventHandler(this.BtnRel_Click);
            // 
            // rdbReceita
            // 
            this.rdbReceita.AutoSize = true;
            this.rdbReceita.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbReceita.Location = new System.Drawing.Point(283, 228);
            this.rdbReceita.Margin = new System.Windows.Forms.Padding(4);
            this.rdbReceita.Name = "rdbReceita";
            this.rdbReceita.Size = new System.Drawing.Size(75, 20);
            this.rdbReceita.TabIndex = 4;
            this.rdbReceita.TabStop = true;
            this.rdbReceita.Text = "R&eceita";
            this.rdbReceita.UseVisualStyleBackColor = true;
            // 
            // rdbDespesa
            // 
            this.rdbDespesa.AutoSize = true;
            this.rdbDespesa.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDespesa.Location = new System.Drawing.Point(373, 228);
            this.rdbDespesa.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDespesa.Name = "rdbDespesa";
            this.rdbDespesa.Size = new System.Drawing.Size(82, 20);
            this.rdbDespesa.TabIndex = 5;
            this.rdbDespesa.TabStop = true;
            this.rdbDespesa.Text = "&Despesa";
            this.rdbDespesa.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(16, 224);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.MinimumSize = new System.Drawing.Size(250, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(250, 25);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "&Filtro";
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFilter.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(63, 7);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(205, 23);
            this.txtFilter.TabIndex = 12;
            this.txtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // lblListCount
            // 
            this.lblListCount.AutoSize = true;
            this.lblListCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblListCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblListCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblListCount.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListCount.Location = new System.Drawing.Point(278, 7);
            this.lblListCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListCount.MaximumSize = new System.Drawing.Size(181, 0);
            this.lblListCount.MinimumSize = new System.Drawing.Size(178, 25);
            this.lblListCount.Name = "lblListCount";
            this.lblListCount.Size = new System.Drawing.Size(178, 25);
            this.lblListCount.TabIndex = 13;
            this.lblListCount.Text = "re&gistrado(s)";
            this.lblListCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(11, 340);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizar.MinimumSize = new System.Drawing.Size(0, 25);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(219, 28);
            this.btnAtualizar.TabIndex = 9;
            this.btnAtualizar.Text = "A&tualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 374);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.lblListCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.rdbDespesa);
            this.Controls.Add(this.rdbReceita);
            this.Controls.Add(this.btnRel);
            this.Controls.Add(this.btnRem);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRotulo);
            this.Controls.Add(this.Lst);
            this.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos Pessoais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lst;
        private System.Windows.Forms.TextBox txtRotulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.Button btnRel;
        private System.Windows.Forms.RadioButton rdbReceita;
        private System.Windows.Forms.RadioButton rdbDespesa;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblListCount;
        private System.Windows.Forms.Button btnAtualizar;
    }
}

