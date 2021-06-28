/*
 * Created by SharpDevelop.
 * User: Lider
 * Date: 02/06/2021
 * Time: 22:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Data;


namespace DS_funcionarios
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		        string conexao = "server=localhost;user ID =root; password = root; database = bd_loja";

        
        public void listarFuncionarios()
        {
            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

                
                string sql_select_funcionarios = "select * from tb_funcionarios";

                
                MySqlCommand executacmdMySql_select = new MySqlCommand(sql_select_funcionarios, con);

                con.Open();
                executacmdMySql_select.ExecuteNonQuery();

                
                DataTable tabela_funcionarios = new DataTable();

                
                MySqlDataAdapter da_funcionarios = new MySqlDataAdapter(executacmdMySql_select);

                da_cliente.Fill(tabela_funcionarios);

                
                DgvListaCliente.DataSource = tabela_funcionarios;

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
		
		void btncadastrar(object sender, EventArgs e)
			
		{
	    try {
                
                
                MySqlConnection con = new MySqlConnection(conexao);

                  
                string nome, rg, cpf, email, senha, cargo,
                nivel_de_acesso, telefone, celular, cep,
                endereco, numero, complemento, bairro, cidade, estado ;
                
                nome = txtnome.Text;
                rg = txtrg.Text;
                cpf = txtcpf.Text;
                senha = txtsenha.Text;
                cargo = txtcargo.Texto;
                nivel_de_acesso = txtnacesso.Text;
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

                
                string sql_insert = @"insert into tb_funcionarios (tb_funcionarios_nome, 
                                      tb_funcionarios_rg, tb_funcionarios_cpf, tb_funcionarios_email,
                                      tb_funcionarios_senha, tb_funcionarios_cargo, tb_funcionarios_nivel_de_acesso,
                                      tb_funcionarios_telefone, tb_funcionarios_celular, tb_funcionarios_cep,
                                      tb_funcionarios_endereco, tb_funcionarios_numero, tb_funcionarios_complemento, 
                                      tb_funcionarios_bairro, tb_funcionarios_cidade, tb_funcionarios_estado                           tb_fornecedores_cpnj,
                                      )
                                         values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_de_acesso, 
                                          @telefone, @celular, @cep, @endereco, @numero,
                                            @complemento, @bairro, @cidade, @estado )";

                
                MySqlCommand executacmdMySql_insert = new MySqlCommand(sql_insert, con);
                executacmdMySql_insert.Parameters.AddWithValue("@nome", nome);
                executacmdMySql_insert.Parameters.AddWithValue("@rg", rg);
                executacmdMySql_insert.Parameters.AddWithValue("@cpf", cpf);
                executacmdMySql_insert.Parameters.AddWithValue("@email", email);
                executacmdMySql_insert.Parameters.AddWithValue("@senha",senha);
                executacmdMySql_insert.Parameters.AddWithValue("@cargo",cargo);
                executacmdMySql_insert.Parameters.AddWithValue("@nivel_de_acesso",nivel_de_acesso);
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

                MessageBox.Show("Cliente Cadastrado com sucesso");
                
                    
            } catch (Exception erro) {
                
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        
        void MainFormLoad(object sender, EventArgs e)
        {
           
            listarClientes();            
        

		}
        
		void btnalterar(object sender, EventArgs e)
			
		{
	            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

               
               
                string nome, rg, cpf, email, senha, cargo, nivel_de_acesso, telefone, celular, cep, endereco,numero, complemento, bairro, cidade, estado ;
                int id;

                id = int.Parse(txtcodigo.Text);
                nome = txtnome.Text;
                rg = txtrg.Text;
                cpf = txtcpf.Text;
                email = txtemail.Text;
                senha = txtsenha.Text;
                cargo = txtcargo.Text;
                nivel_de_acesso = txtnacesso.Text;
                telefone = txttelefone.Text;               
                celular = txtcelular.Text;
                cep = txtcep.Text;
                endereco = txtendereco.Text;
                numero = txtnumero.Text;
                complemento = txtcomplemento.Text;
                bairro = txtbairro.Text;
                cidade = txtcidade.Text;
                estado = txtestado.Text;
                

                
                string sql_uptade_funcionarios = @"update tb_funcionarios set tb_funcionarios_nome = @nome,
                                      tb_funcionario__rg =  @rg,
                                      tb_funcionario_cpf = @cpf,
                                      tb_funcionario_email = @email,
                                      tb_funcionarios_senha = @senha,
                                      tb_funcionarios_cargo = @cargo,
                                      tb_funcionario_nivel_de-acessso = @nivel_de_acesso,
                                      tb_funcionario_telefone = @telefone,
                                      tb_funcionario_celular = @celular,
                                      tb_funcionario_cep = @cep,
                                      tb_funcionario_endereco = @endereco,
                                      tb_funcionario_numero = @numero,
                                      tb_funcionario_complemento= @complemento,
                                      tb_funcionario_bairro = @bairro,
                                      tb_funcionario__cidade = @cidade,
                                      tb_funcionario__estado = @estado

                                                                    where tb_funcionarios_id = @id";


                
                MySqlCommand executacmdMySql_uptade = new MySqlCommand(sql_uptade_funcionarios, con);

                executacmdMySql_uptade.Parameters.AddWithValue("@nome", nome);
                executacmdMySql_uptade.Parameters.AddWithValue("@rg", rg);
                 executacmdMySql_uptade.Parameters.AddWithValue("@cpf", cpf);
                executacmdMySql_uptade.Parameters.AddWithValue("@email", email);
                 executacmdMySql_uptade.Parameters.AddWithValue("@senha", senha);
                  executacmdMySql_uptade.Parameters.AddWithValue("@cargo", cargo);
                   executacmdMySql_uptade.Parameters.AddWithValue("@nivel_de_acesso", nivel_de_acesso);
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

                
                listarFuncionarios();
            }
            catch (Exception erro)
            {

                MessageBox.Show("aconteceu o erro: " + erro);
            }            
        }

		
		
		void btnexcluir(object sender, EventArgs e)
			
		{
	            try
            {
                
                MySqlConnection con = new MySqlConnection(conexao);

               
                int id = int.Parse(txtcodigo.Text);

                
                string sql_delete_funcionarios = @"delete from tb_funcionarios where tb_funcionarios_id = @id";

                
                MySqlCommand executacmdMySql_delete = new MySqlCommand(sql_delete_fornecedores, con);
                executacmdMySql_delete.Parameters.AddWithValue("@id", id);

                
                con.Open();

               
                executacmdMySql_delete.ExecuteNonQuery();

                
                con.Close();
                MessageBox.Show("funcionario excluido com sucesso");

                
                listarFuncionarios();

            }
            catch (Exception erro)
            {

                MessageBox.Show("aconteceu o erro: " + erro);
            }            
        }
        
        void DgvListaClienteCellClick(object sender, DataGridViewCellEventArgs e)
        {
             
             txtnome.Text  = DgvListaCliente.CurrentRow.Cells[0].Value.ToString();
             txtrg.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txtcpf.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txtemail.Text  = DgvListaCliente.CurrentRow.Cells[3].Value.ToString();
             txtsenha.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txtcargo.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txtnacesso.Text   = DgvListaCliente.CurrentRow.Cells[1].Value.ToString();
             txttelefone.Text  = DgvListaCliente.CurrentRow.Cells[2].Value.ToString();
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
	
	

