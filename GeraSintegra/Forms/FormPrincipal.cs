using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Net.Sockets;

using Multisoft.old.DB;
using Multisoft.SistemaSintegra.Code;

using NHibernate;
using NHibernate.Criterion;
using System.Reflection;

namespace Multisoft.SistemaSintegra
{
    public partial class FormPrincipal : Form
    {
		#region detalhes
        private IArquivoMagnetico arquivoMagnetico;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arquivoMagnetico = new ArquivoMagnetico();
            /*
            cb60.Checked = true;
            cmbSoftware.SelectedIndex = 1;
            rbTipoImpMFD.Checked = true;
            btnGerar_Click(sender, e);
             * /**/
        }

        private void alerta(Exception ex)
        {
            MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void alerta(String s)
        {
            MessageBox.Show(s, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
		
        public void escreve()
        {
            txtRelatorio.Text += "\r\n";
        }
        public void escreve(String s)
        {
            txtRelatorio.Text += s;
            escreve();
        }
		#endregion
		
		public void BuscaDB_SET()
		{
            using (ISession ss = Thiago.NHibernateHelper.OpenSession())
            {
                using (ITransaction tx = ss.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    ss.CreateSQLQuery("UPDATE clientes SET estado = 'GO' WHERE estado IS NULL")
                        .ExecuteUpdate();
                    
                    ss.CreateSQLQuery("UPDATE mov_mercadoria SET cfop = 5102 WHERE (cfop IS NULL) AND (nome_movimento in ('NOTA FISCAL', 'CUPOM FISCAL', 'CF SIMPLES'))")
                        .ExecuteUpdate();
                    ss.CreateSQLQuery("UPDATE mov_mercadoria SET cfop = 1102 WHERE (cfop IS NULL) AND (nome_movimento = 'COMPRA')")
                        .ExecuteUpdate();
                    ss.CreateSQLQuery("UPDATE mov_mercadoria SET cfop = 1202 WHERE (cfop IS NULL) AND (nome_movimento = 'DEV.CLIENTE')")
                        .ExecuteUpdate();

                    /**/
                    ss.CreateSQLQuery("UPDATE mov_mercadoria SET cod_cliente = 1 WHERE cod_cliente = 0")
                        .ExecuteUpdate();
                    ss.CreateSQLQuery("UPDATE clientes SET codigo = 1 WHERE codigo in (SELECT cod_cliente FROM mov_mercadoria WHERE cod_cliente not in ( SELECT codigo FROM clientes ))")
                        .ExecuteUpdate();
                    /**/
                    escreve("pesquisando DB...");
                    System.Threading.Thread.Sleep(1000);
                    Application.DoEvents();

                    ICriteria crit = ss.CreateCriteria(typeof(LinhaMovMerc));
                    //crit.Add(Expression.Eq("cod_caixa", 1));
                    crit.Add(Expression.In("nome_movimento", new string[] { "COMPRA", "NOTA FISCAL", "CUPOM FISCAL", "DEV.FORNECEDOR", "DEV.CLIENTE", "CF SIMPLES" }));
                    //crit.Add(Expression.Between("data", Functions.PrimeiroDia(DateTime.Now.AddMonths(-1)), Functions.UltimoDia(DateTime.Now.AddMonths(-1))));
                    crit.Add(Expression.Between("data", Program.dtInicial, Program.dtFinal));

                    IList<LinhaMovMerc> movs = crit.List<LinhaMovMerc>();
                    Empresa emp = ss.Load<Empresa>(1);
                    Cliente clienteConsumidor = ss.Load<Cliente>(1);
                    clienteConsumidor.rg = "ISENTO";

                    escreve("iniciando conversão de dados...");
                    escreve();
                    Transformador transformador = new Transformador();
                    
                    try
                    {
                        arquivoMagnetico.insere(
                            transformador.extraiTipo10(emp)
                            );
                        arquivoMagnetico.insere(
                            transformador.extraiTipo11(emp)
                            );

                        //MessageBox.Show("vou começar a passar as notas fiscais agora");

                        escreve("quantidade de vendas desse período: "+movs.Count);

                        escreve("--------");
                        escreve("TIPOS 5x");

                        foreach (LinhaMovMerc mov in movs)
                            if (mov.nome_movimento != "CUPOM FISCAL" && mov.nome_movimento != "CF SIMPLES")//nota fiscal
                            {
                                //lblProgresso.Text = "movimento: " +mov.idMov.ToString();
                                System.Threading.Thread.Sleep(50);
                                Application.DoEvents();


                                escreve("mov: " + mov.idMov+" itens: "+mov.itens.Count);

                                if (mov.isClienteInvalido())
                                    mov.cliente = clienteConsumidor;

                                if (cb50.Checked)
                                {
                                    arquivoMagnetico.insere(
                                        transformador.extraiTipo50(mov));
                                }
                                if (cb51.Checked)
                                {
                                    arquivoMagnetico.insere(
                                        transformador.extraiTipo51(mov));
                                }
                                if (cb53.Checked)
                                {
                                    arquivoMagnetico.insere(
                                        transformador.extraiTipo53(mov));
                                }

                                if (cb54.Checked)
                                {
                                    foreach (Tipo t in transformador.extraiTipo54(mov))
                                        arquivoMagnetico.insere(t);
                                }
                                /**/
                            }

                        if (cb60.Checked)
                        {
                            alerta("Verifique se sua impressora fiscal está ligada...");
                            escreve("-------");
                            escreve("TIPO 60");

                            if (Program.isMFD)
                            {
                                escreve("lendo empresa");

                                escreve(Program.dtFinal.Year.ToString());
                                escreve(Program.dtFinal.Month.ToString().PadLeft(2, '0'));
                                escreve(Functions.LimiteLength(emp.razaosocial, 35));
                                escreve(Functions.LimiteLength(emp.endereco, 34));
                                escreve(Functions.LimiteLength(emp.numero, 5));
                                escreve(Functions.LimiteLength(emp.complemento, 22));
                                escreve(Functions.LimiteLength(emp.bairro, 15));
                                escreve(Functions.LimiteLength(emp.cidade, 30));
                                escreve(Functions.LimiteLength(emp.cep, 8));
                                escreve(Functions.LimiteLength(emp.telefone, 12));
                                escreve(Functions.LimiteLength(emp.fax, 10));
                                escreve(Functions.LimiteLength(emp.responsavel, 18));

                                escreve("--- empresa");
                                transformador.extraiTipo60termica(
                                    Program.dtFinal.Year.ToString(),
                                    Program.dtFinal.Month.ToString().PadLeft(2, '0'),
                                    emp);
                            }
                            else
                            {
                                IList<LinhaMovMerc> movsCupom = new List<LinhaMovMerc>();
                                foreach (LinhaMovMerc mov in movs)
                                {
                                    //filtra
                                    if (mov.nome_movimento == "CUPOM FISCAL" || mov.nome_movimento == "CF SIMPLES")
                                        movsCupom.Add(mov);
                                }
                                foreach (Tipo t in transformador.extraiTipo60matricial(movsCupom))
                                    arquivoMagnetico.insere(t);
                            }
                        }
                        /**/

                        if (cb75.Checked)
                        {
                            escreve("-------");
                            escreve("TIPO 75");
                            IList<Produto> produtos = new List<Produto>();
                            foreach (LinhaMovMerc mov in movs)
                            {
                                //filtra
                                foreach (LinhaMovMercItem item in mov.itens)
                                {
                                    if (!produtos.Contains(item.dadosProduto))
                                        produtos.Add(item.dadosProduto);
                                }
                            }
                            foreach (Tipo t in transformador.extraiTipo75(produtos))
                                arquivoMagnetico.insere(t);
                        }
                        escreve("-------");
                        escreve("TIPO 90");

                        arquivoMagnetico = transformador.extraiTipo90(emp, arquivoMagnetico);
                        
                    }
                    catch (Exception ex)
                    {
                        alerta(ex);
                        tx.Rollback();
                        this.Close();
                    }
                    tx.Rollback();
        }
		
            }
		}
		
		public void BuscaDB_LOJA()
		{
			OdbcConnection oConn;
			OdbcCommand oCmd;
			
			DataTable tblEmpresa;
			DataTable tblVenda;
			DataTable tblVendaItens;
			DataTable tblCompra;
			DataTable tblCompraItens;
			DataTable tblProduto;
            DataRow rowEmpresa;
			
			escreve("pesquisando DB...");
            escreve("buscando dados da empresa");
			oConn = new OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=C:\loja\Progs\;Exclusive=No;  _
                                                         Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
            oConn.Open();//C:\loja\Progs
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Progs\FIRM.SEG";
            tblEmpresa = new DataTable("TBL_FIRM");
            tblEmpresa.Load(oCmd.ExecuteReader());
            oConn.Close();//C:\loja\Progs

            rowEmpresa = tblEmpresa.Rows[0];

            //dataGridView1.DataSource = dt;
			
			System.Threading.Thread.Sleep(1000);
			Application.DoEvents();
			
			oConn = new OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=C:\loja\Dados1\;Exclusive=No;  _
                                                         Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
            oConn.Open();//C:\loja\Dados1

            escreve("buscando dados das vendas");
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Dados1\VENDAS.DBF";// WHERE DATA_VENDA > '01-02-2009' AND DATA_VENDA < '02-25-2009'";// + Program.dtFinal.ToString("dd/MM/yyyy") + "'";
            tblVenda = new DataTable("TBL_VENDAS");
            tblVenda.Load(oCmd.ExecuteReader());
			
            escreve("buscando dados das compras");
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Dados1\COMPRA.DBF";
            tblCompra = new DataTable("TBL_COMPRAS");
            tblCompra.Load(oCmd.ExecuteReader());
			
            escreve("buscando itens vendidos");
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Dados1\I_VENDAS.DBF";
            tblVenda = new DataTable("TBL_VENDAS_ITENS");
            tblVenda.Load(oCmd.ExecuteReader());
			
            escreve("buscando itens comprados");
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Dados1\I_COMPRA.DBF";
            tblCompra = new DataTable("TBL_COMPRAS_ITENS");
            tblCompra.Load(oCmd.ExecuteReader());
			
            escreve("buscando cadastro de produtos");
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();
            oCmd = oConn.CreateCommand();
            oCmd.CommandText = @"SELECT * FROM C:\loja\Dados1\PRODUTOS.DBF";
            tblProduto = new DataTable("TBL_PRODUTOS");
            tblProduto.Load(oCmd.ExecuteReader());
			
			//PRODUTO.DBF
			
            oConn.Close();//C:\loja\Dados1

            escreve("filtrando por período");

            /**
             * 
             * vendas:
             * data_venda    fazer filtro
             * cod_venda  -> I_VENDA (tabela i_venda não tem ordenador, apenas indexador)
             * cliente    -> Comum\CLIENTES.DBF
             * 
             * i_vendas:
             * cod_venda  -> indexador pra venda
             * produto    -> indexador pra produto
             * 
             * */


			/*
                    ICriteria crit = ss.CreateCriteria(typeof(LinhaMovMerc));
                    //crit.Add(Expression.Eq("cod_caixa", 1));
                    crit.Add(Expression.In("nome_movimento", new string[] { "COMPRA", "NOTA FISCAL", "CUPOM FISCAL", "DEV.FORNECEDOR", "DEV.CLIENTE", "CF SIMPLES" }));
                    //crit.Add(Expression.Between("data", Functions.PrimeiroDia(DateTime.Now.AddMonths(-1)), Functions.UltimoDia(DateTime.Now.AddMonths(-1))));
                    crit.Add(Expression.Between("data", Program.dtInicial, Program.dtFinal));
					
                    IList<LinhaMovMerc> movs = crit.List<LinhaMovMerc>();
                    Empresa emp = ss.Load<Empresa>(1);
                    Cliente clienteConsumidor = ss.Load<Cliente>(1);
                    clienteConsumidor.rg = "ISENTO";
					
                    escreve("iniciando conversão de dados...");
                    escreve();
					*/
			Transformador transformador = new Transformador();
			
			try
			{
				arquivoMagnetico.insere(
					transformador.extraiTipo10(rowEmpresa)
					);
				arquivoMagnetico.insere(
                    transformador.extraiTipo11(rowEmpresa)
					);
					
				//MessageBox.Show("vou começar a passar as notas fiscais agora");
				
				//escreve("quantidade de vendas desse período: "+movs.Count);
				
				/*
				escreve("--------");
				escreve("TIPOS 5x");
				foreach (LinhaMovMerc mov in movs)
					if (mov.nome_movimento != "CUPOM FISCAL" && mov.nome_movimento != "CF SIMPLES")//nota fiscal
					{
						//lblProgresso.Text = "movimento: " +mov.idMov.ToString();
						System.Threading.Thread.Sleep(50);
						Application.DoEvents();


						escreve("mov: " + mov.idMov+" itens: "+mov.itens.Count);

						if (mov.isClienteInvalido())
							mov.cliente = clienteConsumidor;

						if (cb50.Checked)
						{
							arquivoMagnetico.insere(
								transformador.extraiTipo50(mov));
						}
						if (cb51.Checked)
						{
							arquivoMagnetico.insere(
								transformador.extraiTipo51(mov));
						}
						if (cb53.Checked)
						{
							arquivoMagnetico.insere(
								transformador.extraiTipo53(mov));
						}

						if (cb54.Checked)
						{
							foreach (Tipo t in transformador.extraiTipo54(mov))
								arquivoMagnetico.insere(t);
						}
						
					}
				*/
				/*
				if (cb60.Checked)
				{
					alerta("Verifique se sua impressora fiscal está ligada...");
					escreve("-------");
					escreve("TIPO 60");
					IList<LinhaMovMerc> movsCupom = new List<LinhaMovMerc>();

					foreach (LinhaMovMerc mov in movs)
					{
						//filtra
						if (mov.nome_movimento == "CUPOM FISCAL" || mov.nome_movimento == "CF SIMPLES")
							movsCupom.Add(mov);
					}
					foreach (Tipo t in transformador.extraiTipo60(movsCupom))
						arquivoMagnetico.insere(t);
				}

				if (cb75.Checked)
				{
					escreve("-------");
					escreve("TIPO 75");
					IList<Produto> produtos = new List<Produto>();
					foreach (LinhaMovMerc mov in movs)
					{
						//filtra
						foreach (LinhaMovMercItem item in mov.itens)
						{
							if (!produtos.Contains(item.dadosProduto))
								produtos.Add(item.dadosProduto);
						}
					}
					foreach (Tipo t in transformador.extraiTipo75(produtos))
						arquivoMagnetico.insere(t);
				}
				*/
				escreve("-------");
				escreve("TIPO 90");
				arquivoMagnetico = transformador.extraiTipo90(rowEmpresa, arquivoMagnetico);
				
			}
			catch (Exception ex)
			{
				alerta(ex);
				//this.Close();
			}
			
		}
		
        private void btnGerar_Click(object sender, EventArgs e)
        {
            Program.software = (EnumSoftware)cmbSoftware.SelectedIndex;
            if (Program.software == EnumSoftware.Sde)
            {
                alerta("O Software Multisoft SDE 2009 não foi encontrado, por favor, instale-o.");
                return;
            }
            if (Program.software == EnumSoftware.Loja && !Directory.Exists("c:\\loja"))
            {
                alerta("O Software Multisoft LOJA não foi encontrado, por favor, instale-o.");
                return;
            }
            if (Program.software == EnumSoftware.Set && !Directory.Exists("c:\\set"))
            {
                alerta("O Software Multisoft SET não foi encontrado, por favor, instale-o.");
                return;
            }

            txtRelatorio.Text = "";
            Program.SetMes(dt10DATAINICIAL.Value);
            Program.isMFD = rbTipoImpMFD.Checked;
            alerta("Atenção, este é um processo longo, cliques e teclas vão apenas atrasar o procedimento.");
            alerta("Caso o programa verifique alguma informação no seu banco de dados que seja incoerente ao SIntegra, uma janela de alerta aparecerá.");

            string s = (!Program.isMFD) ? "matricial" : "térmica";
            escreve("UTILIZANDO UMA IMPRESSORA BEMATECH TIPO:" + s);

            backgroundWorker1.RunWorkerAsync();
        }

        private void cmbSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSoftware.SelectedIndex >= 0)
                btnGerar.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                panel1.Visible = false;
                cmbSoftware.Enabled = false;
                Application.DoEvents();

                if (Program.software == EnumSoftware.Set)
                    BuscaDB_SET();
                else if (Program.software == EnumSoftware.Loja)
                    BuscaDB_LOJA();
                else
                    throw new Exception("Software Indefinido");

                //if (!Directory.Exists("C:\\set\\sintegra\\relatorios\\"))
                //	Directory.CreateDirectory("C:\\set\\sintegra\\relatorios\\");

                string sArquivo = string.Format("C:\\sintegra_{0}.txt", dt10DATAINICIAL.Value.ToString("yyyy_MM"));
                //string sArquivoCopia = string.Format("C:\\set\\sintegra\\relatorios\\sintegra_{0}.txt", dt10DATAINICIAL.Value.ToString("yyyy_MM"));

                File.WriteAllText(sArquivo,
                    arquivoMagnetico.ToString());

                //File.Copy(sArquivo, sArquivoCopia, true);

                string s = "Operação concluída com sucesso, verifique o arquivo " + sArquivo;
                MessageBox.Show(s);
                escreve(s);
            }
            catch (Exception ex)
            {
                escreve("ERRO!");
                escreve(ex.Message);
            }

            panel1.Visible = true;
            cmbSoftware.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Assembly a = Assembly.LoadFile("c:\\DadosFBI.dll");

            foreach (Type t in a.GetTypes())
            {
                if (t.Name == "Form1")
                {
                    foreach (ConstructorInfo ci in t.GetConstructors())
                    {
                        object obj = ci.Invoke(null);

                        if (obj == null)
                            MessageBox.Show("construiu nulo");
                        else
                        {
                            Form objFrm = (Form)obj;
                            objFrm.Show();
                            //MessageBox.Show(obj.ToString());
                        }
                    }
                }
            }


            MethodInfo mi = typeof(Transformador).GetMethods()[0];
            MethodBody mb = mi.GetMethodBody();
            
            escreve("classe: "+typeof(Transformador).Name);
            escreve("método: "+mi.Name);

            */

            return;

            MessageBox.Show(
                InvocarBemaFI32.Bematech_FI_HabilitaDesabilitaRetornoEstendidoMFD("1").ToString()
            );
        }



    }
}
