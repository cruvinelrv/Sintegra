using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Multisoft.SistemaSintegra.Code
{
    public class InvocarBemaFI32
    {
        //bemafi32.dll 
        //dados -> matricial
        //gerarelatorio -> termica

        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_HabilitaDesabilitaRetornoEstendidoMFD(string cFlag);

        [DllImport("BemaFI32.dll")]
        private static extern int Bematech_FI_DadosSintegra(string dtInicial, string dtFinal);

        [DllImport("BemaFI32.dll")]
        private static extern int Bematech_FI_RegistrosTipo60();
        
        [DllImport("BemaFI32.dll")]
        private static extern int Bematech_FI_AbrePortaSerial();

        [DllImport("BemaFI32.dll")]
        private static extern int Bematech_FI_FechaPortaSerial();
        
        [DllImport("BemaFI32.dll")]
        private static extern int Bematech_FI_RelatorioSintegraMFD(int iRelatorios,
            string cArquivo, string cMes, string cAno,
            string cRazaoSocial,
            string cEndereco,
            string cNumero,
            string cComplemento,
            string cBairro,
            string cCidade,
            string cCEP,
            string cTelefone,
            string cFax,
            string cContato);

        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_LeituraX();

        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_DownloadMF(string s);

        public static string buscaDadosSIntegra_termica(string cAno, string cMes,
            string cRazaoSocial,
            string cEndereco,
            string cNumero,
            string cComplemento,
            string cBairro,
            string cCidade,
            string cCEP,
            string cTelefone,
            string cFax,
            string cContato)
        {
            /*
                iRelatorios: variável INTEIRA com o tamanho de um byte, onde: 
                1: gera o relatório tipo 60M (Mestre);
                2: gera o relatório tipo 60A (Analítico);
                4: gera o relatório tipo 60D (Diário);
                8: gera o relatório tipo 60I (Item);
                16: gera o relatório tipo 60R (Resumo Mensal) e;
                32: gera o relatório tipo 75.
            */

            //60M+60A+60D+60I+60R
            //31

            string arquivoRetorno = "c:\\retorno.txt";//_" + cAno + "_" + cMes + "
            /*
            System.Windows.Forms.MessageBox.Show("abre: "+
                Bematech_FI_AbrePortaSerial().ToString()
                );
            */
            int iRetorno =
                //Bematech_FI_RegistrosTipo60();
                Bematech_FI_RelatorioSintegraMFD(1, "SINTEGRA.TXT", "01", "2009", "BEMATECH S/A", "Estrada de Santa Candida", "263", "Industria", "Santa Candida", "Curitiba", "82630490", "41 351-2700", "41 351-2863", "Fulano de Tal" );
                //Bematech_FI_RelatorioSintegraMFD(63, "c:\\SINTEGRA.TXT", "11", "2008", "BEMATECH S/A", "Estrada de Santa Candida", "263", "Industria", "Santa Candida", "Curitiba", "82630490", "41 351-2700", "41 351-2863", "Fulano de Tal");
            /*
            System.Windows.Forms.MessageBox.Show("fecha: " +
                            Bematech_FI_FechaPortaSerial().ToString()
                            );
            */
            Program.form.escreve("RETORNO DA IMPRESSORA: " + iRetorno);

            

            if (iRetorno != 1)
            {
                Program.form.escreve("PROBLEMA NA IMPRESSORA TÉRMICA: " + iRetorno);
                throw new Exception("Algum problema com a impressora térmica! CÓDIGO " + iRetorno);
            }

            StringBuilder sb = new StringBuilder();
            
            using (StreamReader sr = new StreamReader(arquivoRetorno))
            {
                string s = sr.ReadLine();
                while(s.StartsWith("60"))
                {
                    Program.form.escreve(s);
                    sb.AppendLine(s);
                    s = sr.ReadLine();
                }
            }

            return sb.ToString();
        }

        public static RetornoBemaFI32 buscaDadosSIntegra_matricial(DateTime dtInicial, DateTime dtFinal)
        {

            int ret = 0;

            if (Program.isMFD==false)
                ret = Bematech_FI_DadosSintegra(dtInicial.ToString("ddMMyyyy"), dtFinal.ToString("ddMMyyyy"));

            Program.form.escreve("RETORNO DA IMPRESSORA: " + ret);

            if (ret != 1)
            {
                Program.form.escreve("PROBLEMA NA IMPRESSORA MATRICIAL: " + ret);
                throw new Exception("Algum problema com a impressora matricial! CÓDIGO " + ret.ToString());
            }

            string s = File.ReadAllText("c:\\retorno.txt");

            RetornoBemaFI32 r = new RetornoBemaFI32();

            r.dtReducaoZ = new DateTime(
                int.Parse(s.Substring(0, 4)),   //3
                int.Parse(s.Substring(4, 2)),   //5
                int.Parse(s.Substring(6, 2)));  //7

            r.num_serie_equip = s.Substring(8, 20);//27
            r.num_sequencial_ecf = int.Parse(s.Substring(28, 3));//30
            r.contador_reducao_z = int.Parse(s.Substring(31, 6));//36
            r.contador_reinicio_operacao = int.Parse(s.Substring(37, 6));//42
            r.gt_final = long.Parse(s.Substring(43, 16));//58
            r.gt_inicial = long.Parse(s.Substring(59, 16));//74
            r.situ_venda_bru = long.Parse(s.Substring(75, 16));//90
            r.situ_venda_liq = long.Parse(s.Substring(91, 16));//106
            r.situ_cancelamentos = long.Parse(s.Substring(107, 12));//118


            r.situ_descontos = long.Parse(s.Substring(119, 12));//130
            r.situ_substituicao = long.Parse(s.Substring(131, 12));//142
            r.situ_isencao = long.Parse(s.Substring(143, 12));//154
            r.situ_nao_incidenica = long.Parse(s.Substring(155, 12));//166
            r.situ_issqn = long.Parse(s.Substring(167, 12));//178
            r.situacao_trib_icms = long.Parse(s.Substring(179, 4));//182
            r.valor_acumulado_na_situacao_trib = long.Parse(s.Substring(183, 12));//194

            return r;
            /*
            if (Program.isMFD)
            {
                r.situ_descontos = long.Parse(s.Substring(119, 12));//130
                //espaço 131, 12));//142
                //espaço 143, 12));//154
                //espaço 155, 12));//166
                r.situ_substituicao = long.Parse(s.Substring(167, 12));//178
                //espaço 179, 12));//190
                r.situ_isencao = long.Parse(s.Substring(191, 12));//202
                //espaço 203, 12));//214
                r.situ_nao_incidenica = long.Parse(s.Substring(214, 12));//226
                //espaço 227, 12));//238
                r.situ_issqn = long.Parse(s.Substring(239, 12));//250
                r.situacao_trib_icms = long.Parse(s.Substring(251, 4));//255
                r.valor_acumulado_na_situacao_trib = long.Parse(s.Substring(256, 12));//258
            }
            /**/
            
        }
        
        public static int tiraLeituraX()
        {
            return Bematech_FI_LeituraX();
        }

        public static int tiraMemoriaFiscal()
        {
            return Bematech_FI_DownloadMF("c:\\MFISCAL.MF");
        }
        
    }



    public class RetornoBemaFI32
    {

        public DateTime dtReducaoZ;
        public string num_serie_equip = "";
        public int num_sequencial_ecf = 0;
        public int contador_reducao_z = 0;
        public int contador_reinicio_operacao = 0;
        public long gt_final = 0;
        public long gt_inicial = 0;
        public long situ_venda_bru = 0;
        public long situ_venda_liq = 0;
        public long situ_cancelamentos = 0;
        public long situ_descontos = 0;
        public long situ_substituicao = 0;
        public long situ_isencao = 0;
        public long situ_nao_incidenica = 0;
        public long situ_issqn = 0;
        public long situacao_trib_icms = 0;
        public long valor_acumulado_na_situacao_trib = 0;
    }
}
