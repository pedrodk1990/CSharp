using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GastosPessoais
{
    public partial class Report : Form
    {
        private List<GastoPessoal> _lista = null;

        public Report(List<GastoPessoal> lista)
        {
            _lista = lista;
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("Data", DateTime.Now.ToLongDateString());
            parameters[1] = new ReportParameter("Total", _lista.Calcular().ToString());
            parameters[2] = new ReportParameter("Despesa", _lista.Calcular(Type.Despesa).ToString());
            parameters[3] = new ReportParameter("Receita", _lista.Calcular(Type.Receita).ToString());

            this.rpv.LocalReport.SetParameters(parameters);
            this.rpv.LocalReport.DataSources.ElementAt(0).Value = _lista;
            this.rpv.RefreshReport();
        }
    }
}
