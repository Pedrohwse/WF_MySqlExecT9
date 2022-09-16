using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_MySqlExecT9
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand command;
        MySqlDataReader reader;

        public Form1()
        {
            InitializeComponent();
            //Server = myServerAddress; Database = myDataBase; Uid = myUsername; Pwd = myPassword
            con = new MySqlConnection("Server=localhost;Database=pizzeriadb;Uid=root;Pwd=;SslMode=none");
        }


        private void btnBuscarDados_Click(object sender, EventArgs e)
        {
            

            List<Cliente> listaClientes = new List<Cliente>();

            
            command = new MySqlCommand();
            
            con.Open();
            
            command.Connection = con;
            command.CommandText = "SELECT * FROM cliente";
            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();

                cliente.id = reader["id"].ToString();
                cliente.nome_completo = reader["nome_completo"].ToString();
                cliente.data_nascimento = reader["data_nascimento"].ToString();
                cliente.telefone = reader["telefone"].ToString();
                cliente.ddd = reader["ddd"].ToString();
                cliente.endereco = reader["endereco"].ToString();
                cliente.complemento = reader["complemento"].ToString();
                cliente.cep = reader["cep"].ToString();
                cliente.numero = reader["numero"].ToString();

                listaClientes.Add(cliente);
            }

            
            foreach (var cliente in listaClientes)
            {
                ListViewItem item = new ListViewItem(cliente.id);
                
                item.SubItems.Add(cliente.nome_completo);
                item.SubItems.Add(cliente.data_nascimento);
                item.SubItems.Add(cliente.telefone);
                item.SubItems.Add(cliente.ddd);
                item.SubItems.Add(cliente.endereco);
                item.SubItems.Add(cliente.complemento);
                item.SubItems.Add(cliente.cep);
                item.SubItems.Add(cliente.numero);


                listView1.Items.Add(item);
            }


            con.Close();
        }

        private void listBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    class Cliente
    {

        public string id { get; set; }
        public string nome_completo { get; set; }
        public string data_nascimento { get; set; }
        public string telefone { get; set; }
        public string ddd { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string numero { get; set; }
    }
}
