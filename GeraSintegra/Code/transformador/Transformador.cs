using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Multisoft.old.DB;

namespace Multisoft.SistemaSintegra.Code
{
    public class Transformador
    {
        private const string MEU_ESTADO = "GO";

        public Transformador()
        {

        }

        public Tipo extraiTipo10(Empresa emp)
        {
            ConstrutorTipo10 c = new ConstrutorTipo10();
            c.set1_DadosBasicos(emp.cnpj, emp.cidade, emp.razaosocial, emp.fax);
            c.set2_InscricaoEstadual(emp.ie, emp.uf);
            return c.constroi();
        }
        public Tipo extraiTipo10(DataRow emp)
        {
            ConstrutorTipo10 c = new ConstrutorTipo10();
            string fax = emp["telefone"].ToString().Replace("(","").Replace(")","").Replace("-","");
            c.set1_DadosBasicos(emp["cgc"].ToString(), emp["cidade"].ToString(), emp["razaosocia"].ToString(), fax);
            c.set2_InscricaoEstadual(emp["inscricao"].ToString(), emp["estado"].ToString());
            return c.constroi();
        }

        public Tipo extraiTipo11(Empresa emp)
        {
            ConstrutorTipo11 c = new ConstrutorTipo11();
            c.setContato(emp.responsavel, emp.telefone);
            c.setEndereco(emp.endereco, emp.numero, emp.complemento, emp.bairro, emp.cep);
            return c.constroi();
        }

        public Tipo extraiTipo11(DataRow emp)
        {
            ConstrutorTipo11 c = new ConstrutorTipo11();
            string tel = emp["telefone"].ToString().Replace("(", "").Replace(")", "").Replace("-", "");
            c.setContato(emp["nome"].ToString(), tel);
            c.setEndereco(emp["endereco"].ToString(), emp["numero"].ToString(), emp["complement"].ToString(), emp["bairro"].ToString(), emp["cep"].ToString());
            return c.constroi();
        }

        public Tipo extraiTipo50(DataRow venda, DataRow[] itens, DataRow cliente)
        {
            bool isVenda = true;
            string strSituacao = (venda["EXCLUSAO"].ToString() != "") ? Tipo50.SITUACAO_DOC_FSCL_CAN : Tipo50.SITUACAO_DOC_FSCL_NOR;
            bool isPessoaFisica = (cliente["TIPO_CLI"].ToString() == "F");
            bool isVendaConsumidor = (venda["CLIENTE"].ToString() == "1");

            double dblTOTALValorNota = 0;
            double dblTOTALbcICMS = 0;
            double dblTOTALbcICMSSubst = 0;
            double dblTOTALvalorICMS = 0;
            double dblTOTALvalorICMSSubst = 0;
            double dblTOTALisento = 0;
            
            foreach (DataRow item in itens)
            {
                //nome aos bois

                string cst = item["TRIBUTACAO"].ToString();

                double dblITEMValor = (double)item["VALOR_BRUT"] * (double)item["QUANTIDADE"]; // - item.desconto

                if (cst == "000")
                {
                    double aliquota = (double)item["ICM"];
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "020")
                {
                    double aliquota = (double)item["REDUTOR"] * (double)item["ICM"]/100;
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "040")
                {
                    //ISENTO
                    dblTOTALisento += dblITEMValor;
                }
                else if (cst == "060")
                {
                    dblTOTALvalorICMSSubst += dblITEMValor;
                }

                //incrementos

                dblTOTALValorNota += dblITEMValor;



                //int i = item["PRODUTO"];
                
            }
            
            ConstrutorTipo50 c = new ConstrutorTipo50();
            /*
            c.set1_NotaFiscal(vendas.num_nota.ToString(), mov.cfop, mov.data, isVenda);

            if (isVendaConsumidor)
                c.set2_DadosClienteConsumidor();
            else if (isPessoaFisica)
                c.set2_DadosClienteFisico(mov.cliente.estado, mov.cliente.cpf);
            else
                c.set2_DadosClienteJuridico(mov.cliente.rg, mov.cliente.estado, mov.cliente.cpf);

            c.set3_Valores(dblTOTALValorNota, dblTOTALbcICMS, dblTOTALvalorICMS, dblTOTALisento, mov.outras, 17);
            c.set4_Situacao(strSituacao);
            return c.constroi();
            */
            return null;
        }

        public Tipo extraiTipo50(LinhaMovMerc mov)
        {
            bool isVenda = ("NOTA FISCAL_CUPOM FISCAL_CF SIMPLES".Contains(mov.nome_movimento));
            string strSituacao = (mov.cancelado == "T") ? Tipo50.SITUACAO_DOC_FSCL_CAN : Tipo50.SITUACAO_DOC_FSCL_NOR;
            bool isPessoaFisica = (mov.cliente.pessoa == "F");
            bool isVendaConsumidor = (mov.cliente == null) || (mov.cliente.idCliente == 1);

            double dblTOTALValorNota = 0;
            double dblTOTALbcICMS = 0;
            double dblTOTALbcICMSSubst = 0;
            double dblTOTALvalorICMS = 0;
            double dblTOTALvalorICMSSubst = 0;
            double dblTOTALisento = 0;

            foreach (LinhaMovMercItem item in mov.itens)
            {
                //nome aos bois

                string cst = (mov.cliente.estado == "GO")
                    ? item.dadosProduto.cst_dentro_uf
                    : item.dadosProduto.cst_fora_uf;

                double dblITEMValor = item.precoU * item.quantidade; // - item.desconto

                if (cst == "000")
                {
                    double aliquota = item.dadosProduto.aliquota;
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "020")
                {
                    //(double)item["REDUTOR"] * (double)item["ICM"] / 100;
                    //double aliquota = item.dadosProduto.aliquota * 15;//WAGNER



                    double aliquota = item.dadosProduto.redutor_dentro_uf * item.dadosProduto.aliquota / 100;

                    /*
                    string s = "Reduzindo Aliquota:\r\n";
                    s += "redutor: " + item.dadosProduto.redutor_dentro_uf.ToString();
                    s += "aliquota: " + item.dadosProduto.aliquota.ToString();
                    s += "aliq red: " + aliquota.ToString();
                    System.Windows.Forms.MessageBox.Show(s);
                    /**/
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "040")
                {
                    //ISENTO
                    dblTOTALisento += dblITEMValor;
                }
                else if (cst == "060")
                {
                    /*
                    aliquota = 0;
                    double dblITEMbcICMSSubst = dblITEMValor;
                    double dblITEMvalorICMSSubst = 0;//dblITEMValor * aliquota

                    dblTOTALbcICMSSubst += dblITEMbcICMSSubst;
                    dblTOTALvalorICMSSubst += dblITEMvalorICMSSubst;
                    */
                    dblTOTALvalorICMSSubst += dblITEMValor;
                }

                //incrementos

                dblTOTALValorNota += dblITEMValor;



                int i = item.dadosProduto.idProduto;
            }

            ConstrutorTipo50 c = new ConstrutorTipo50();

            c.set1_NotaFiscal(mov.num_nota.ToString(), mov.cfop, mov.data, isVenda);

            if (isVendaConsumidor)
                c.set2_DadosClienteConsumidor();
            else if (isPessoaFisica)
                c.set2_DadosClienteFisico(mov.cliente.estado, mov.cliente.cpf);
            else
                c.set2_DadosClienteJuridico(mov.cliente.rg, mov.cliente.estado, mov.cliente.cpf);

            c.set3_Valores(dblTOTALValorNota, dblTOTALbcICMS, dblTOTALvalorICMS, dblTOTALisento, mov.outras, 17);
            c.set4_Situacao(strSituacao);
            return c.constroi();
        }

        public Tipo extraiTipo51(LinhaMovMerc mov)
        {
            bool isVenda = ("NOTA FISCAL_CUPOM FISCAL_CF SIMPLES".Contains(mov.nome_movimento));
            string strSituacao = (mov.cancelado == "T") ? Tipo50.SITUACAO_DOC_FSCL_CAN : Tipo50.SITUACAO_DOC_FSCL_NOR;
            bool isPessoaFisica = (mov.cliente.pessoa == "F");
            bool isVendaConsumidor = (mov.cliente.idCliente == 1);

            double dblTOTALValorNota = 0;
            double dblTOTALbcICMS = 0;
            double dblTOTALbcICMSSubst = 0;
            double dblTOTALvalorICMS = 0;
            double dblTOTALvalorICMSSubst = 0;
            double dblTOTALisentoIPI = 0;

            foreach (LinhaMovMercItem item in mov.itens)
            {
                //nome aos bois

                string cst = (mov.cliente.estado == "GO")
                    ? item.dadosProduto.cst_dentro_uf
                    : item.dadosProduto.cst_fora_uf;

                double dblITEMValor = item.precoU * item.quantidade; // - item.desconto

                if (cst == "000")
                {
                    double aliquota = item.dadosProduto.aliquota;
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "020")
                {
                    double aliquota = item.dadosProduto.aliquota * 15;//WAGNER
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "040")
                {
                    //ISENTO
                }
                else if (cst == "060")
                {
                    /*
                    aliquota = 0;
                    double dblITEMbcICMSSubst = dblITEMValor;
                    double dblITEMvalorICMSSubst = 0;//dblITEMValor * aliquota

                    dblTOTALbcICMSSubst += dblITEMbcICMSSubst;
                    dblTOTALvalorICMSSubst += dblITEMvalorICMSSubst;
                    */
                    dblTOTALvalorICMSSubst += dblITEMValor;
                }

                //incrementos

                dblTOTALisentoIPI += (mov.ipi > 0) ? 0 : dblITEMValor;

                dblTOTALValorNota += dblITEMValor;

                int i = item.dadosProduto.idProduto;
            }

            ConstrutorTipo51 c = new ConstrutorTipo51();

            c.set1_NotaFiscal(mov.num_nota.ToString(), mov.cfop, mov.data);

            if (isVendaConsumidor)
                c.set2_DadosClienteConsumidor();
            else if (isPessoaFisica)
                c.set2_DadosClienteFisico(mov.cliente.estado, mov.cliente.cpf);
            else
                c.set2_DadosClienteJuridico(mov.cliente.rg, mov.cliente.estado, mov.cliente.cpf);

            c.set3_Valores(dblTOTALValorNota, mov.ipi, dblTOTALisentoIPI, 0);
            c.set4_Situacao(strSituacao);

            return c.constroi();
        }

        public Tipo extraiTipo53(LinhaMovMerc mov)
        {
            bool isVenda = ("NOTA FISCAL_CUPOM FISCAL_CF SIMPLES".Contains(mov.nome_movimento));
            string strSituacao = (mov.cancelado == "T") ? Tipo50.SITUACAO_DOC_FSCL_CAN : Tipo50.SITUACAO_DOC_FSCL_NOR;
            bool isPessoaFisica = (mov.cliente.pessoa == "F");
            bool isVendaConsumidor = (mov.cliente.idCliente == 1);

            double dblTOTALValorNota = 0;
            double dblTOTALbcICMS = 0;
            double dblTOTALbcICMSSubst = 0;
            double dblTOTALvalorICMS = 0;
            double dblTOTALvalorICMSSubst = 0;

            foreach (LinhaMovMercItem item in mov.itens)
            {
                //nome aos bois
                

                string cst = (mov.cliente.estado == "GO")
                    ? item.dadosProduto.cst_dentro_uf
                    : item.dadosProduto.cst_fora_uf;

                double dblITEMValor = item.precoU * item.quantidade; // - item.desconto

                if (cst == "000")
                {
                    double aliquota = item.dadosProduto.aliquota;
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "020")
                {
                    double aliquota = item.dadosProduto.aliquota * 15;//WAGNER
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "040")
                {
                    //ISENTO
                }
                else if (cst == "060")
                {
                    /*
                    aliquota = 0;
                    double dblITEMbcICMSSubst = dblITEMValor;
                    double dblITEMvalorICMSSubst = 0;//dblITEMValor * aliquota

                    dblTOTALbcICMSSubst += dblITEMbcICMSSubst;
                    dblTOTALvalorICMSSubst += dblITEMvalorICMSSubst;
                    */
                    dblTOTALvalorICMSSubst += dblITEMValor;
                }

                //incrementos

                dblTOTALValorNota += dblITEMValor;

                int i = item.dadosProduto.idProduto;
            }

            ConstrutorTipo53 c = new ConstrutorTipo53();

            c.set1_NotaFiscal(mov.num_nota, mov.cfop, mov.data, isVenda);

            if (isVendaConsumidor)
                c.set2_DadosClienteConsumidor();
            else if (isPessoaFisica)
                c.set2_DadosClienteFisico(mov.cliente.estado, mov.cliente.cpf);
            else
                c.set2_DadosClienteJuridico(mov.cliente.rg, mov.cliente.estado, mov.cliente.cpf);

            c.set3_Valores(dblTOTALbcICMSSubst, dblTOTALvalorICMSSubst,
                mov.frete+mov.seguro+mov.outras);
            c.set4_Situacao(strSituacao);

            return c.constroi();
        }

        public Tipo[] extraiTipo54(LinhaMovMerc mov)
        {
            Tipo[] tipos = new Tipo54[mov.itens.Count];

            for (int i = 0; i < tipos.Length; i++)
            {
                LinhaMovMercItem item = mov.itens[i];

                string cst = (mov.cliente.estado == MEU_ESTADO)
                    ? item.dadosProduto.cst_dentro_uf
                    : item.dadosProduto.cst_fora_uf;

                double dblITEMValor = item.precoU * item.quantidade; // - item.desconto
                double aliquota = item.dadosProduto.aliquota;//17;
                double dblITEMbcICMS = 0;
                double dblITEMbcICMSSubst = 0;

                cst = "000";

                if (cst == "000")
                {
                    dblITEMbcICMS = dblITEMValor;
                }
                else if (cst == "020")
                {
                    aliquota = item.dadosProduto.aliquota * 15;//WAGNER
                    dblITEMbcICMS = dblITEMValor;
                }
                else if (cst == "040")
                {
                    //ISENTO
                }
                else if (cst == "060")
                {
                    aliquota = 0;
                    dblITEMbcICMSSubst = dblITEMValor;
                }

                ConstrutorTipo54 c = new ConstrutorTipo54();
                c.set1_NotaFiscal(mov.num_nota, mov.cliente.cpf, mov.cfop, cst);
                c.set2_BasicoItem(i+1, item.dadosProduto.idProduto);
                c.set3_DadosItem(item.quantidade, item.total, item.desconto);
                c.set4_Valores(dblITEMbcICMS, dblITEMbcICMSSubst, item.ipi_percent * item.total, aliquota);

                tipos[i] = c.constroi();
            }
            return tipos;

        }

        public Tipo extraiTipo55(LinhaMovMerc mov)
        {
            bool isVenda = ("NOTA FISCAL_CUPOM FISCAL_CF SIMPLES".Contains(mov.nome_movimento));
            string strSituacao = (mov.cancelado == "T") ? Tipo50.SITUACAO_DOC_FSCL_CAN : Tipo50.SITUACAO_DOC_FSCL_NOR;
            bool isPessoaFisica = (mov.cliente.pessoa == "F");
            bool isVendaConsumidor = (mov.cliente.idCliente == 1);

            double dblTOTALValorNota = 0;
            double dblTOTALbcICMS = 0;
            double dblTOTALbcICMSSubst = 0;
            double dblTOTALvalorICMS = 0;
            double dblTOTALvalorICMSSubst = 0;
            double dblTOTALisento = 0;

            foreach (LinhaMovMercItem item in mov.itens)
            {
                //nome aos bois

                string cst = (mov.cliente.estado == "GO")
                    ? item.dadosProduto.cst_dentro_uf
                    : item.dadosProduto.cst_fora_uf;

                double dblITEMValor = item.precoU * item.quantidade;

                if (cst == "000")
                {
                    double aliquota = item.dadosProduto.aliquota;
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "020")
                {
                    double aliquota = item.dadosProduto.aliquota * 15;//WAGNER
                    double dblITEMbcICMS = dblITEMValor;
                    double dblITEMvalorICMS = dblITEMValor * aliquota;

                    dblTOTALbcICMS += dblITEMbcICMS;
                    dblTOTALvalorICMS += dblITEMvalorICMS;
                }
                else if (cst == "040")
                {
                    //ISENTO
                    dblTOTALisento += dblITEMValor;
                }
                else if (cst == "060")
                {
                    /*
                    aliquota = 0;
                    double dblITEMbcICMSSubst = dblITEMValor;
                    double dblITEMvalorICMSSubst = 0;//dblITEMValor * aliquota

                    dblTOTALbcICMSSubst += dblITEMbcICMSSubst;
                    dblTOTALvalorICMSSubst += dblITEMvalorICMSSubst;
                    */
                    dblTOTALvalorICMSSubst += dblITEMValor;
                }

                //incrementos

                dblTOTALValorNota += dblITEMValor;

                int i = item.dadosProduto.idProduto;
            }

            ConstrutorTipo50 c = new ConstrutorTipo50();

            c.set1_NotaFiscal(mov.num_nota.ToString(), mov.cfop, mov.data, isVenda);
            
            if (isVendaConsumidor)
                c.set2_DadosClienteConsumidor();
            else if (isPessoaFisica)
                c.set2_DadosClienteFisico(mov.cliente.estado, mov.cliente.cpf);
            else
                c.set2_DadosClienteJuridico(mov.cliente.rg, mov.cliente.estado, mov.cliente.cpf);

            c.set3_Valores(dblTOTALValorNota, dblTOTALbcICMS, dblTOTALvalorICMS, dblTOTALisento, mov.outras, 17);
            c.set4_Situacao(strSituacao);
            return c.constroi();
            
        }

        public string extraiTipo60termica(string ano, string mes, Empresa emp)
        {
            return InvocarBemaFI32.buscaDadosSIntegra_termica(
                ano, mes,
                Functions.LimiteLength(emp.razaosocial, 35),
                Functions.LimiteLength(emp.endereco, 34), Functions.LimiteLength(emp.numero, 5), Functions.LimiteLength(emp.complemento, 22), Functions.LimiteLength(emp.bairro, 15), Functions.LimiteLength(emp.cidade, 30), Functions.LimiteLength(emp.cep, 8),
                Functions.LimiteLength(emp.telefone, 12), Functions.LimiteLength(emp.fax, 10), Functions.LimiteLength(emp.responsavel, 18)
                );
        }

        public IList<Tipo> extraiTipo60matricial(IList<LinhaMovMerc> movs)
        {

            /**
             * muito cuidado, chamar a propriedade DateTime.Date
             **/

            SortedList<DateTime, LinhaMovMerc> slPrimeiraDoDia = new SortedList<DateTime, LinhaMovMerc>();
            SortedList<DateTime, LinhaMovMerc> slUltimaDoDia = new SortedList<DateTime, LinhaMovMerc>();

            SortedList<DateTime, RetornoBemaFI32> slLeiturasX
                = new SortedList<DateTime, RetornoBemaFI32>();

            foreach (LinhaMovMerc mov in movs)
            {
                //se ainda não existe item na lista para esta data, cria
                if (!slPrimeiraDoDia.ContainsKey(mov.data.Date))
                {
                    slPrimeiraDoDia.Add(mov.data.Date, mov);
                    slUltimaDoDia.Add(mov.data.Date, mov);
                }

                //agora, com certeza aquela data existe na lista...

                //o objetivo aqui é encontrar o MENOR numero de nota desse dia
                if (slPrimeiraDoDia[mov.data.Date].num_nota > mov.num_nota)
                    slPrimeiraDoDia[mov.data.Date] = mov;

                //o objetivo aqui é encontrar o MAIOR numero de nota desse dia
                if (slUltimaDoDia[mov.data.Date].num_nota < mov.num_nota)
                    slUltimaDoDia[mov.data.Date] = mov;

            }

            IList<Tipo> tipos = new List<Tipo>();

            //Program.progress.Maximum = slPrimeiraDoDia.Keys.Count;

            //vamos popular as leituras-X para não precisarmos buscá-las depois.
            for (int i = 0; i < slPrimeiraDoDia.Keys.Count; i++)
            {
                slLeiturasX.Add(
                    slPrimeiraDoDia.Keys[i],
                    InvocarBemaFI32.buscaDadosSIntegra_matricial(
                        slPrimeiraDoDia.Keys[i],
                        slPrimeiraDoDia.Keys[i])
                    );
                System.Threading.Thread.Sleep(100);
                System.Windows.Forms.Application.DoEvents();
                //Program.progress.Value = i;
                //Program.label.Text = "pegando leituras-X " + i.ToString() + " / " + slPrimeiraDoDia.Keys.Count.ToString();
            }
            /*
            try
            {
                File.Delete("c:\\delete-me.xml");
            }
            catch { }
            using (StreamWriter sw = File.CreateText("c:\\delete-me.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(RetornoBemaFI32));
                
                for (int i = 0; i < slPrimeiraDoDia.Keys.Count; i++)
                {
                    RetornoBemaFI32 bema = slLeiturasX[slPrimeiraDoDia.Keys[i]];
                    xs.Serialize(sw, bema);
                }

            }
            return tipos;
            */

            //criando tipos 60M
            for (int i = 0; i < slPrimeiraDoDia.Keys.Count; i++)
            {
                RetornoBemaFI32 bema = slLeiturasX[slPrimeiraDoDia.Keys[i]];

                using (StreamWriter sw = File.AppendText("c:\\thread.txt"))
                {
                    sw.WriteLine(slPrimeiraDoDia.Keys[i].ToShortDateString());
                }
                System.Threading.Thread.Sleep(100);
                System.Windows.Forms.Application.DoEvents();
                //Program.progress.Value = i;
                //Program.label.Text = "criando tipos 60 " + i.ToString() + "/" + slPrimeiraDoDia.Keys.Count.ToString();
                
                LinhaMovMerc movIni = slPrimeiraDoDia.Values[i];
                LinhaMovMerc movFin = slUltimaDoDia.Values[i];
                ConstrutorTipo60 c;

                #region insere tipo 60M
                c = new ConstrutorTipo60(Tipo60.SUBTIPO_60M);
                c.setM_Mestre(
                    bema.dtReducaoZ, bema.num_serie_equip, bema.num_sequencial_ecf,
                    "2D", movIni.num_nota, movFin.num_nota, bema.contador_reducao_z,
                    bema.contador_reinicio_operacao, bema.situ_venda_bru, bema.gt_final);

                tipos.Add(c.constroi());
                #endregion

                #region insere tipos 60A
                c = new ConstrutorTipo60(Tipo60.SUBTIPO_60A);

                c.setA_Analitico(
                    bema.dtReducaoZ, bema.num_serie_equip,
                    "1700", bema.situacao_trib_icms
                );
                tipos.Add(c.constroi());
                
                if (bema.situ_substituicao > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "F", bema.situ_substituicao
                    );
                    tipos.Add(c.constroi());
                }
                if (bema.situ_isencao > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "I", bema.situ_isencao
                        );
                    tipos.Add(c.constroi());
                }
                if (bema.situ_nao_incidenica > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "N", bema.situ_nao_incidenica
                        );
                    tipos.Add(c.constroi());
                }
                if (bema.situ_cancelamentos > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "CANC", bema.situ_cancelamentos
                        );
                    tipos.Add(c.constroi());
                }
                if (bema.situ_descontos > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "DESC", bema.situ_descontos
                        );
                    tipos.Add(c.constroi());
                }
                if (bema.situ_issqn > 0)
                {
                    c.setA_Analitico(
                        bema.dtReducaoZ, bema.num_serie_equip,
                        "ISS", bema.situ_issqn
                        );
                    tipos.Add(c.constroi());
                }
                #endregion
            
            }

            return tipos;
        }

        public IList<Tipo> extraiTipo75(IList<Produto> produtos)
        {
            IList<Tipo> tipos = new List<Tipo>();

            foreach (Produto p in produtos)
            {
                ConstrutorTipo75 c = new ConstrutorTipo75();
                //c.set1_Datas();
                c.set1_dadosInternos(p.idProduto, p.nome, p.unidMed, p.cst_dentro_uf);
                c.set2_impostos(p.ipi, p.aliquota, p.redutor_dentro_uf, p.p_venda);

                tipos.Add(c.constroi());
            }

            return tipos;
        }

        public IArquivoMagnetico extraiTipo90(Empresa emp, IArquivoMagnetico arq)
        {
            ConstrutorTipo90 c = new ConstrutorTipo90(emp.cnpj, emp.ie, arq);
            return c.preenche();
        }

        public IArquivoMagnetico extraiTipo90(DataRow emp, IArquivoMagnetico arq)
        {
            ConstrutorTipo90 c = new ConstrutorTipo90(emp["cgc"].ToString(), emp["inscricao"].ToString(), arq);
            return c.preenche();
        }

    }
}
