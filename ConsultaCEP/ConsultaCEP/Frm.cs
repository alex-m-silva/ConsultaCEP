using System;
using System.Windows.Forms;
using Correios;

namespace ConsultaCEP
{
    public partial class Frm : Form
    {
        public Frm()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCEP.Text))
                {
                    MessageBox.Show("O campo cep está vazio!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CorreiosApi cep = new CorreiosApi();
                var returnCep = cep.consultaCEP(txtCEP.Text);

                if (returnCep == null)
                {
                    MessageBox.Show("Não foi possivel encontrar o cep!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtCep2.Text= txtCEP.Text;
                txtUf.Text = returnCep.uf;
                txtCidade.Text = returnCep.cidade;
                txtBairro.Text = returnCep.bairro;
                txtEnd.Text = returnCep.end;
                txtCEP.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCEP.Clear();
            }
        }
    }
}
