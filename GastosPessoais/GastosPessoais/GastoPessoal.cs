using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GastosPessoais
{
    /// <summary>
    /// Valores padrão para a tipagem da classe AtividadeFinanceiraEntity.
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// Valor positivo, representa entrada de valores.
        /// </summary>
        Receita,
        /// <summary>
        /// Valor negativo, representa saida de valores.
        /// </summary>
        Despesa
    }
    /// <summary>
    /// Classe que representa despesas e receitas pessoais de maneira genérica,
    /// para controle das economias pessoais.
    /// </summary>
    public class AtividadeFinanceiraEntity
    {
        private int id;
        /// <summary>
        /// Identificador de registro no banco de dados.
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string rotulo;
        /// <summary>
        /// Nome de refêrencia.
        /// </summary>
        public string Rotulo
        {
            get { return rotulo; }
            set { rotulo = value; }
        }
        private decimal valor;
        /// <summary>
        /// Valor positivo ou negativo.
        /// </summary>
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private Type tipo;
        /// <summary>
        /// Tipo.
        /// </summary>
        public Type Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string dataHora;
        /// <summary>
        /// Data e hora de registro.
        /// </summary>
        public string DataHora
        {
            get { return dataHora; }
            set { dataHora = value; }
        }
        private string ultimaAtualizacao;
        /// <summary>
        /// Data e hora da última modificação no registro.
        /// </summary>
        public string UltimaAtualizacao
        {
            get { return ultimaAtualizacao; }
            set { ultimaAtualizacao = value; }
        }
    }
    /// <summary>
    /// Classe auxiliar com os métodos CRUD
    /// </summary>
    public class GastoPessoal : AtividadeFinanceiraEntity, IFileHandle<GastoPessoal>
    {
        private Arquivo _fh = null;
        public GastoPessoal()
        {
            _fh = new Arquivo("gastos_pessoais");
        }
        ///// <summary>
        ///// Localiza um registro
        ///// </summary>
        ///// <param name="id">Identificador de registro</param>
        ///// <returns></returns>
        public GastoPessoal Buscar(int id)
        {
            return Listar().Where(n => n.ID == id).FirstOrDefault();
        }
        ///// <summary>
        ///// Remove um registro em um arquivo json usado como banco de dados.
        ///// </summary>
        public void Deletar()
        {
            var ls = Listar();
            var entity = ls.Where(n => n.ID == this.ID).FirstOrDefault();
            if (entity != null)
            {
                ls.Remove(entity);
                var json = JsonConvert.SerializeObject(ls);
                _fh.WriteFile(json);
            }
        }
        ///// <summary>
        ///// Modifica os dados de um registro em um arquivo json usado como banco de dados.
        ///// </summary>
        public void Editar()
        {
            var ls = Listar();
            var entity = ls.Where(n => n.ID == this.ID).FirstOrDefault();
            if (entity != null)
            {
                ls.Remove(entity);
                entity.Rotulo = this.Rotulo;
                entity.Tipo = this.Tipo;
                var date = DateTime.Now;
                entity.UltimaAtualizacao = date.ToShortDateString() + "_" + date.ToShortTimeString();
                entity.Valor = this.Valor;
                ls.Add(entity);
                _fh.WriteFile(JsonConvert.SerializeObject(ls.OrderBy(n => n.ID)));
            }
        }
        ///// <summary>
        ///// Carrega todos os registros armazenados em um arquivo json usado como banco de dados.
        ///// </summary>
        ///// <returns></returns>
        public List<GastoPessoal> Listar()
        {
            var ls = JsonConvert.DeserializeObject<List<GastoPessoal>>(_fh.ReadFile());
            return ls ?? new List<GastoPessoal>();
        }
        ///// <summary>
        ///// Armazena os dados em um arquivo json usado como banco de dados.
        ///// </summary>
        public void Salvar()
        {
            this.ID = UltimoRegistro() + 1;
            var ls = Listar();
            var date = DateTime.Now;
            this.DataHora = date.ToShortDateString() + "_" + date.ToShortTimeString();
            ls.Add(this);
            _fh.WriteFile(JsonConvert.SerializeObject(ls));
        }
        ///// <summary>
        ///// Pega o último identificador registrado.
        ///// </summary>
        ///// <returns></returns>
        public int UltimoRegistro()
        {
            return Listar()?.LastOrDefault()?.ID ?? 0;
        }
    }
    public interface IFileHandle<T> where T : new()
    {
        int UltimoRegistro();
        void Salvar();
        void Editar();
        void Deletar();
        T Buscar(int id);
        List<T> Listar();
    }
    /// <summary>
    /// Classe para manipulação de arquivos
    /// </summary>
    class Arquivo
    {
        private string nome;
        private string _caminho;
        public Arquivo(string fileName)
        {
            nome = fileName + ".json";
            _caminho = GetResource(nome);
        }
        /// <summary>
        /// Retorna o caminho de um arquivo do diretorio /bin/debug/
        /// </summary>
        /// <param name="nome_arquivo"></param>
        /// <returns></returns>
        private static string GetResource(string nome_arquivo)
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/" + nome_arquivo;
        }
        /// <summary>
        /// Lê o arquivo Json (e cria o arquivo se não existir).
        /// </summary>
        /// <returns></returns>
        public string ReadFile()
        {

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Dispose();
            }
            string json = string.Empty;
            using (var sr = new StreamReader(_caminho))
            {
                json = sr.ReadToEnd();
                sr.Dispose();
            }
            return json;
        }
        /// <summary>
        /// Escreve o arquivo Json (e cria o arquivo se não existir).
        /// </summary>
        /// <param name="json">string Json</param>
        public void WriteFile(string json)
        {
            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Dispose();
            }
            using (var sw = new StreamWriter(_caminho))
            {
                sw.Write(json);
                sw.Dispose();
            }
        }
    }
    /// <summary>
    /// Classe com metodos de extensão
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Calcula a soma total dos valores armazenados.
        /// </summary>
        /// <param name="historico">Lista de registros</param>
        /// <param name="tipo">Especifica qual tipo de calculo será feito 
        /// (Despesa = despesa bruta, Receita = receita bruta, Null = receita liquida).</param>
        /// <returns></returns>
        public static decimal Calcular(this ICollection<GastoPessoal> historico, Type? tipo = null)
        {
            decimal total = 0;
            IEnumerable<GastoPessoal> aux = null;

            switch (tipo)
            {
                case Type.Despesa:
                    aux = historico.Where(n => n.Tipo == Type.Despesa);
                    break;
                case Type.Receita:
                    aux = historico.Where(n => n.Tipo == Type.Receita);
                    break;
                default:
                    aux = historico;
                    break;
            }
            foreach (var item in aux)
            {
                if (item.Valor > 0)
                    if (item.Tipo == Type.Despesa)
                        total -= item.Valor;

                total += item.Valor;
            }

            return total;
        }
        /// <summary>
        /// Verifica um char existe dentro de uma cadeia de caracteres
        /// </summary>
        /// <param name="str">Cadeia de caracteres</param>
        /// <param name="keychar">retorna a posição em que a vírgula irá separar as casas decimais</param>
        /// <param name="condicao">char que eu quero verificar</param>
        /// <returns></returns>
        private static bool _verificaSeExiste(string str, ref char keychar, char condicao)
        {
            if (str.IndexOf(condicao) > -1)
            {
                keychar = condicao;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Formata o texto para "999,99" ou "-999,99"
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="e"></param>
        public static void FormatTextToBRL(this System.Windows.Forms.TextBox txt, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Verifica se é a tecla pressionada é uma tecla de controle, um digito, um sinal de menos ou uma vírgula
            if (!char.IsControl(e.KeyChar)
                     && !char.IsDigit(e.KeyChar)
                     && e.KeyChar != '-'
                     && e.KeyChar != ',') e.Handled = true;

            //Verifica se a vírgula foi pressionada
            char separador = 's';
            if (e.KeyChar == ',')
            {
                // Não aceita se a vírgula estiver no início da string
                if (txt.Text.Length == 0) e.Handled = true;
                // Não aceita se a vírgula estiver no início da string
                if (txt.SelectionStart == 0) e.Handled = true;
                // Verifica se a vírgula já existe
                if (_verificaSeExiste(txt.Text, ref separador, ',')) e.Handled = true;
                //Verifica se a vírgula está no meio de um número e depois se está em um número maior que 99
                if (txt.SelectionStart != txt.Text.Length && e.Handled == false)
                {
                    //Verifica se a vírgula não está no meio
                    string strPosVirgula = txt.Text.Substring(txt.SelectionStart);

                    if (strPosVirgula.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }

            //Verifica se o menos foi pressionado
            if (e.KeyChar == '-')
            {
                // Aceita apenas se estiver no início da string
                if (txt.Text.Length > 0) e.Handled = true;
                // Aceita apenas se estiver no início da string
                if (txt.SelectionStart > 0) e.Handled = true;
                // Verifica se já existe
                if (_verificaSeExiste(txt.Text, ref separador, '-')) e.Handled = true;
            }
            //Verifica se um número foi pressionado

            if (Char.IsDigit(e.KeyChar))
            {
                //Verifica se a virgula não existe
                if (_verificaSeExiste(txt.Text, ref separador, ','))
                {
                    int sepratorPosition = txt.Text.IndexOf(separador);
                    string afterSepratorString = txt.Text.Substring(sepratorPosition + 1);
                    if (txt.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }
    }
}
