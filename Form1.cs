using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;                //Biblioteca para usar o SQL

namespace CRUD_Consulta_Cliente
{

    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;                      //Baixar pacotes do NuGet para utilização da biblioteca Data.SqlCliente
        SqlDataReader dr;

        string strSQL;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btNovo_Click(object sender, EventArgs e)       //Botão Novo
        {

            try             //Função de exeção
            {
                conexao = new SqlConnection(@"Server=DESKTOP-S5KG1CO;Database=cad_clientes;User Id=sa;Password=pjmadclkp;");

                strSQL = "INSERT INTO cad_clientes (NOME, NUMERO) VALUES (@NOME, @NUMERO)";

                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();                         //Conecta no banco
                comando.ExecuteNonQueryAsync();         //Executa o strSQL no Query SQL

                MessageBox.Show("Realizada a inclusão no banco com sucesso!");

               
            }
            catch (Exception ex)                        //Tipo um "Else", executa se não atender acima
            {
                MessageBox.Show(ex.Message);            //Manda mensagem    
            }
            finally                                     //Executa idependente se for verdadeiro ou falso a função acima.
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;
                txtID.Clear();
                txtNome.Clear();
                txtNumero.Clear();
            }



        }

        private void btExibir_Click(object sender, EventArgs e)         //Botão Exibir
        {
            try             //Função de exeção
            {
                conexao = new SqlConnection(@"Server=DESKTOP-S5KG1CO;Database=cad_clientes;User Id=sa;Password=pjmadclkp;");

                strSQL = "SELECT * FROM cad_clientes";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);           //Criado para preencher o DataSet

                conexao.Open();  //Conecta no banco

                da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];

            }
            catch (Exception ex)                        //Tipo um "Else", executa se não atender acima
            {
                MessageBox.Show(ex.Message);            //Manda mensagem    
            }
            finally                                     //Executa idependente se for verdadeiro ou falso a função acima.
            {
                conexao.Close();
                conexao = null;

            }



        }

        private void btConsultar_Click(object sender, EventArgs e)          //Botao consultar
        {
            try             //Função de exeção
            {
                conexao = new SqlConnection(@"Server=DESKTOP-S5KG1CO;Database=cad_clientes;User Id=sa;Password=pjmadclkp;");

                strSQL = "SELECT * FROM cad_clientes WHERE id = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();                         //Conecta no banco  

                dr = comando.ExecuteReader();

                while(dr.Read())
                {
                    txtNome.Text = (string)dr["nome"];
                    txtNumero.Text = Convert.ToString(dr["numero"]);
                }
   
            }
            catch (Exception ex)                        //Tipo um "Else", executa se não atender acima
            {
                MessageBox.Show(ex.Message);            //Manda mensagem    
            }
            finally                                     //Executa idependente se for verdadeiro ou falso a função acima.
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }

        }

        private void btEditar_Click(object sender, EventArgs e)             //Botão Editar
        {
            try             //Função de exeção
            {
                conexao = new SqlConnection(@"Server=DESKTOP-S5KG1CO;Database=cad_clientes;User Id=sa;Password=pjmadclkp;");

                strSQL = "UPDATE cad_clientes SET NOME = @NOME, NUMERO = @UNUMERO WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();                         //Conecta no banco
                comando.ExecuteNonQueryAsync();         //Executa o strSQL no Query SQL
               
            }
            catch (Exception ex)                        //Tipo um "Else", executa se não atender acima
            {
                MessageBox.Show(ex.Message);            //Manda mensagem    
            }
            finally                                     //Executa idependente se for verdadeiro ou falso a função acima.
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }

        }

        private void btExcluir_Click(object sender, EventArgs e)            //Botão excluir
        {

            try             //Função de exeção
            {
                conexao = new SqlConnection(@"Server=DESKTOP-S5KG1CO;Database=cad_clientes;User Id=sa;Password=pjmadclkp;");

                strSQL = "DELETE cad_clientes WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@ID", txtID.Text);
                
                conexao.Open();                         //Conecta no banco
                comando.ExecuteNonQueryAsync();         //Executa o strSQL no Query SQL

            }
            catch (Exception ex)                        //Tipo um "Else", executa se não atender acima
            {
                MessageBox.Show(ex.Message);            //Manda mensagem    
            }
            finally                                     //Executa idependente se for verdadeiro ou falso a função acima.
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }

}














