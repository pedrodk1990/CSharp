using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GastosPessoais
{
    public partial class Form1 : Form
    {
        private BindingList<GastoPessoal> _list = null;
        private GastoPessoal _selected = null;

        public Form1()
        {
            InitializeComponent();
            txtRotulo.Focus();
            txtFilter.GotFocus += GotFocus;
            txtRotulo.GotFocus += GotFocus;
            txtValor.GotFocus += GotFocus;
            txtFilter.LostFocus += LostFocus;
            txtRotulo.LostFocus += LostFocus;
            txtValor.LostFocus += LostFocus;
            UpdateList();
        }

        //Tratamento de Erros
        private void Erro(string content, string title)
        {
            MessageBox.Show(this, content, title,
                MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.ServiceNotification);
        }

        //Manipulador: Lista
        /// <summary>
        /// Atualiza a lista 
        /// </summary>
        /// <param name="LstFiltered"></param>
        private void UpdateList(BindingList<GastoPessoal> LstFiltered = null)
        {
            Cursor = Cursors.WaitCursor;
            _list = new BindingList<GastoPessoal>(new GastoPessoal().Listar());
            var aux = LstFiltered ?? _list;
            Lst.DataSource = aux;
            Lst.DisplayMember = "Rotulo";
            Lst.ValueMember = "ID";
            lblListCount.Text = aux.Count() + " re&gistro(s)";
            var total = aux.Calcular();
            var color = SystemColors.ControlText;
            lblTotal.Text = "Total: " + total.ToString("C");
            if (total < 0)
            {
                color = Color.Red;
            }
            else if (total > 0)
            {
                color = Color.Green;
            }
            lblTotal.ForeColor = color;
            ClearForm();
            Lst.SelectedItem = null;
            if (LstFiltered?.Count == 1)
            {
                Lst.SelectedItem = Lst.Items[0];
                _selected = aux[0];
                ToForm();
            }
            Cursor = Cursors.Default;
        }

        //Manipulador: Botão
        /// <summary>
        /// false: habilita apenas o botao adcionar.True:
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtons(bool enable)
        {
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = enable;
            btnRem.Enabled = enable;
            btnRel.Enabled = (_list != null && _list.Count > 0) ? true : false;
            rdbReceita.Checked = false;
            rdbDespesa.Checked = false;
        }

        //Manipulador: Formulário
        /// <summary>
        /// Limpa o formulário
        /// </summary>
        private void ClearForm()
        {
            _selected = null;
            ToForm();
            EnableButtons(false);
        }
        /// <summary>
        /// Preenche o formulário com a entidade selecionada
        /// </summary>
        private void ToForm()
        {
            txtRotulo.Text = _selected?.Rotulo ?? string.Empty;
            txtValor.Text = _selected?.Valor.ToString() ?? string.Empty;
            if (_selected != null)
                if (_selected.Tipo == Type.Despesa)
                    rdbDespesa.Checked = true;
                else if (_selected.Tipo == Type.Receita)
                    rdbReceita.Checked = true;

        }
        /// <summary>
        /// Cria uma nova entidade a partir do formulário
        /// </summary>
        /// <returns></returns>
        private GastoPessoal FromForm()
        {
            var aux = _selected ?? new GastoPessoal();
            aux.Rotulo = txtRotulo.Text;
            aux.Valor = decimal.Parse(string.IsNullOrEmpty(txtValor.Text) ? "0" : txtValor.Text);
            if (aux.Valor > 0)
            {
                aux.Tipo = rdbDespesa.Checked ? Type.Despesa : rdbReceita.Checked ? Type.Receita : Type.Despesa;
            }
            return aux;
        }

        //Evento: TextBox
        /// <summary>
        /// Troca a cor de fundo do elemento que chamar este evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void LostFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            txt.BackColor = SystemColors.Control;
        }
        /// <summary>
        /// Troca a cor de fundo do elemento que chamar este evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void GotFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            txt.BackColor = SystemColors.Window;
        }
        /// <summary>
        /// Filtra a lista a cada letra digitada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var text = sender as TextBox;
            if (text.Text.Length == 0)
            {
                UpdateList();
            }
            else
            {
                var aux = _list.Where(n => n.Rotulo.ToLower().Contains(text.Text.ToLower()) ||
                n.Tipo.ToString("G").ToLower().Contains(text.Text.ToLower()));
                var listaux = new BindingList<GastoPessoal>(aux.ToList());
                UpdateList(listaux);
            }
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Pressione 'ESC' para limpar a caixa de texto de filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Escape)
            {
                (sender as TextBox).Clear();
            }
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Define o tipo verificando se existe o sinal de menos no texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            decimal aux = 0m;
            if (txt.Text.Length > 0 && txt.Text[0] != '-')
            {
                aux = decimal.Parse(string.IsNullOrEmpty(txt.Text) ? "0" : txt.Text);
            }
            if (aux <= 0)
            {
                rdbDespesa.Checked = true;
                rdbReceita.Checked = false;
            }
            else
            {
                rdbReceita.Checked = true;
                rdbDespesa.Checked = false;
            }
        }
        /// <summary>
        /// Aplica o formato monetário na cadeia de caracteres de entrada com duas casas decimais(-333,33)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as TextBox;
            txt.FormatTextToBRL(e);
        }

        //Evento: Lista
        /// <summary>
        /// Formata a visualização dos itens da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lst_Format(object sender, ListControlConvertEventArgs e)
        {
            var aux = e.ListItem as AtividadeFinanceiraEntity;
            e.Value = $"{aux.DataHora}\t{(aux.Tipo == Type.Despesa ? "-" : "+")}  {aux.Rotulo}: {aux.Valor.ToString("C")}";

        }
        /// <summary>
        /// Seleciona um item da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lst = (sender as ListBox);
            _selected = (lst.SelectedItem as GastoPessoal);
            if (_selected != null)//se faz necessário por causa da ordem de execução dos eventos
            {
                EnableButtons(true);
                ToForm();
            }
        }
        /// <summary>
        /// Clique no espaço vazio da lista para limpar a seleção da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lst_MouseDown(object sender, MouseEventArgs e)
        {
            var pt = new Point(e.X, e.Y);
            var ls = sender as ListBox;
            int index = ls?.IndexFromPoint(pt) ?? -1;

            if (index <= -1 && ls != null)
            {
                ls.SelectedItems.Clear();
                ClearForm();
            }
        }
        /// <summary>
        /// Pressione 'ESC' para limpar a seleção da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lst_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.KeyCode == Keys.Escape)
            {
                var ls = sender as ListBox;
                ls.SelectedItems.Clear();
                ClearForm();
            }
            Cursor = Cursors.Default;
        }

        //Evento: Botão
        /// <summary>
        /// Registra um novo elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var a = FromForm();
            if (a == null) { Erro("Ocorreu um erro inesperado.", "Erro"); return; }
            if (string.IsNullOrEmpty(a.Rotulo)) { Erro("Escreva um nome para o Rótulo", "Erro"); txtRotulo.Focus(); return; }
            a.Salvar();
            UpdateList();
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Edita um item da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_selected == null) { Erro("Escolha um item da lista", "Erro"); Lst.Focus(); return; }
            Cursor = Cursors.WaitCursor;
            FromForm();
            _selected.Editar();
            EnableButtons(false);
            UpdateList();
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Deleta um item da lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRem_Click(object sender, EventArgs e)
        {
            if (_selected == null) { Erro("Escolha um item da lista", "Erro"); Lst.Focus(); return; }
            Cursor = Cursors.WaitCursor;
            _selected.Deletar();
            UpdateList();
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Atualiza a lista ao pressionar o botão
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            UpdateList();
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Abre a janela do relatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRel_Click(object sender, EventArgs e)
        {
            var rpv = new Report(_list.ToList());
            rpv.Show();
        }

    }
}
