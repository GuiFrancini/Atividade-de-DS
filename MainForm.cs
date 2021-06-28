/*
 * Created by SharpDevelop.
 * User: Lider
 * Date: 02/06/2021
 * Time: 20:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Data;

namespace DS_atividade
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string conexao = "server=localhost;user ID =root; password = root; database = bd_loja";

		//Criando um método / função /
        public void listarFornecedores()
        {
            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

                
                string sql_select_fornecedores = "select * from tb_fornecedores";

                
                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_fornecedores, con);

                con.Open();
                executacmdMySql_select.ExecuteNonQuery();

                
                DataTable tabela_fornecedores = new DataTable();

                
                MySqlDataAdapter da_fornecedores = new MySqlDataAdapter(executacmdMySql_select);

                da_cliente.Fill(tabela_fornecedores);

                
                DgvListaCliente.DataSource = tabela_fornecedores;

                con.Close();

            }

            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        } 
		
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btncadastrar(object sender, EventArgs e)
		{
			
			try {
				
				
                MySqlConnection con = new MySqlConnection(conexao);

				  
                string nome, cpnj, email, telefone, celular, cep, endereco,numero, complemento, bairro, cidade, estado ;
                nome = txtnome.Text;
                cpnj = txtcpnj.Text;
                telefone = txttelefone.Text;
                email = txtemail.Text;
                celular = txtcelular.Text;
                cep = txtcep.Text;
                endereco = txtendereco.Text;
                numero = txtnumero.Text;
                complemento = txtcomplemento.Text;
                bairro = txtbairro.Text;
                cidade = txtcidade.Text;
                estado = txtestado.Text;

                
                string sql_insert = @"insert into tb_fornecedores (tb_fornecedores_nome, tb_fornecedores_cpnj,
                                     tb_fornecedores_email, tb_fornecedores_telefone, tb_fornecedores_celular,
                                     tb_fornecedores_cep, tb_fornecedores_endereco, tb_fornecedores_numero,
                                     tb_fornecedores_complemento, tb_fornecedores_bairro, tb_fornecedores_cidade,
                                     tb_fornecedores_estado )
                                         values (@nome, @cpnj, @telefone, @email, @celular, @cep, @endereco, @numero,
                                            @complemento, @bairro, @cidade, @estado )";

                
                MySqlCommand executacmdMySql_insert = new MySqlCommand(sql_insert, con);
                executacmdMySql_insert.Parameters.AddWithValue("@nome", nome);
                executacmdMySql_insert.Parameters.AddWithValue("@cpnj", cpnj);
                executacmdMySql_insert.Parameters.AddWithValue("@email", email);
                executacmdMySql_insert.Parameters.AddWithValue("@telefone", telefone);
                executacmdMySql_insert.Parameters.AddWithValue("@celular", celular);
                executacmdMySql_insert.Parameters.AddWithValue("@cep", cep);
                executacmdMySql_insert.Parameters.AddWithValue("@endereco", endereco);
                executacmdMySql_insert.Parameters.AddWithValue("@numero", numero);
                executacmdMySql_insert.Parameters.AddWithValue("@complemento", complemento);
                executacmdMySql_insert.Parameters.AddWithValue("@bairro", bairro); 
                executacmdMySql_insert.Parameters.AddWithValue("@cidade", cidade);
                executacmdMySql_insert.Parameters.AddWithValue("@estado", estado);

                
                con.Open();

                
                executacmdMySql_insert.ExecuteNonQuery();

               
                con.Close();

                MessageBox.Show("Cliente Cadastrado com Sucesso!");
				
					
			} catch (Exception erro) {
				
				MessageBox.Show("Aconteceu o erro: " + erro);
			}
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		   
            listarClientes();			
		}
		
		void Btnalterar(object sender, EventArgs e)
		{
			
            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

               
               
                string nome, cpnj, email, telefone, celular, cep, endereco,numero, complemento, bairro, cidade, estado ;
                int id;

                id = int.Parse(txtcodigo.Text);
                nome = txtnome.Text;
                cpnj = txtcpnj.Text;
                telefone = txttelefone.Text;
                email = txtemail.Text;
                celular = txtcelular.Text;
                cep = txtcep.Text;
                endereco = txtendereco.Text;
                numero = txtnumero.Text;
                complemento = txtcomplemento.Text;
                bairro = txtbairro.Text;
                cidade = txtcidade.Text;
                estado = txtestado.Text;
                

                
                string sql_uptade_cliente = @"update tb_cliente set tb_fornecedores_nome = @nome,
                                     tb_fornecedores_cpnj =  @cpnj,
                                     tb_fornecedores_email = @email,
                                     tb_fornecedores_telefone = @telefone,
                                     tb_fornecedores_celular = @celular,
                                     tb_fornecedores_cep = @cep,
                                     tb_fornecedores_endereco = @endereco,
                                     tb_fornecedores_numero = @numero,
                                     tb_fornecedores_complemento= @complemento,
                                     tb_fornecedores_bairro = @bairro,
                                     tb_fornecedores_cidade = @cidade,
                                     tb_fornecedores_estado = @estado

                                                                    where tb_cliente_id = @id";


                
                MySqlCommand executacmdMySql_uptade = new MySqlCommand(sql_uptade_cliente, con);

                executacmdMySql_uptade.Parameters.AddWithValue("@nome", nome);
                executacmdMySql_uptade.Parameters.AddWithValue("@cpnj", cpnj);
                executacmdMySql_uptade.Parameters.AddWithValue("@email", email);
                    executacmdMySql_uptade.Parameters.AddWithValue("@telefone", telefone);
                	executacmdMySql_uptade.Parameters.AddWithValue("@celular", celular);
                	executacmdMySql_uptade.Parameters.AddWithValue("@cep", cep);
                	executacmdMySql_uptade.Parameters.AddWithValue("@endereco", endereco);
                	executacmdMySql_uptade.Parameters.AddWithValue("@numero", numero);
                	executacmdMySql_uptade.Parameters.AddWithValue("@complemento", complemento);
                	executacmdMySql_uptade.Parameters.AddWithValue("@bairro", bairro);
                	executacmdMySql_uptade.Parameters.AddWithValue("@cidade", cidade);
                    executacmdMySql_uptade.Parameters.AddWithValue("@estado", estado);
                  executacmdMySql_uptade.Parameters.AddWithValue("@id", id);
                
                con.Open();

                
                executacmdMySql_uptade.ExecuteNonQuery();

                
                con.Close();
                MessageBox.Show("Dados do fornecedor alterados  com sucesso");

                
                listarClientes();
            }
            catch (Exception erro)
            {

                MessageBox.Show("aconteceu o erro: " + erro);
            }			
		}
		
		void BtnexcluirClick(object sender, EventArgs e)
		{
 
            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

               
                int id = int.Parse(txtcodigo.Text);

                
                string sql_delete_fornecedores = @"delete from tb_fornecedores where tb_fornecedores_id = @id";

                
                MySqlCommand executacmdMySql_delete = new MySqlCommand(sql_delete_fornecedores, con);
                executacmdMySql_delete.Parameters.AddWithValue("@id", id);

                
                con.Open();

               
                executacmdMySql_delete.ExecuteNonQuery();

                
                con.Close();
                MessageBox.Show("Cliente excluido com sucesso");

                
                listarClientes();

            }
            catch (Exception erro)
            {

                MessageBox.Show("aconteceu o erro: " + erro);
            }			
		}
		
		void DgvListaClienteCellClick(object sender, DataGridViewCellEventArgs e)
		{
			 
             txtnome.Text  = DgvListaCliente.CurrentRow.Cells[0].Value.ToString();
             txtcpnj.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txttelefone.Text  = DgvListaCliente.CurrentRow.Cells[2].Value.ToString();
             txtemail.Text  = DgvListaCliente.CurrentRow.Cells[3].Value.ToString();
             txtcelular.Text = DgvListaCliente.CurrentRow.Cells[4].Value.ToString();
             txtcep.Text = DgvListaCliente.CurrentRow.Cells[5].Value.ToString();
             txtendereco.Text = DgvListaCliente.CurrentRow.Cells[6].Value.ToString();
             txtnumero.Text = DgvListaCliente.CurrentRow.Cells[7].Value.ToString();
             txtcomplemento.Text = DgvListaCliente.CurrentRow.Cells[8].Value.ToString();
             txtbairro.Text = DgvListaCliente.CurrentRow.Cells[9].Value.ToString();
             txtcidade.Text = DgvListaCliente.CurrentRow.Cells[10].Value.ToString();
             txtestado.Text= DgvListaCliente.CurrentRow.Cells[11].Value.ToString();
                 
                
                
		}
	}
}

	
	
		
	

