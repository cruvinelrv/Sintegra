using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo10 : IConstrutorTipo
    {
        #region atributos

        long cgc_mf;//
        InscrEstadual ie;//
        string nome_contrib;//
        string municipio;//
        long fax;//
        DateTime dtInicial;//
        DateTime dtFinal;//
        string codEstrutura;//
        string codNatureza;
        string codFinalidade;//

        #endregion

        public ConstrutorTipo10()
        {
            codEstrutura = Tipo10.COD_ESTRUTURA;
            codNatureza = Tipo10.COD_NATUREZA;
            codFinalidade = Tipo10.COD_FINALIDADE;

            this.dtInicial = Program.dtInicial;
            this.dtFinal = Program.dtFinal;
        }

        #region métodos

        public void set1_DadosBasicos(string cgc_mf, string municipio, string nome_contrib, string fax)
        {
            this.cgc_mf = long.Parse(Functions.SoNumero(cgc_mf));
            this.municipio = municipio;
            this.nome_contrib = nome_contrib;
            this.fax = long.Parse(Functions.SoNumero(fax));
        }

        public void set2_InscricaoEstadual(string ie, string uf)
        {
            try
            {
                this.ie = new InscrEstadual(ie, uf, false);//esse construtor pode levantar exceções
            } catch(Exception e) {
                throw new Exception("TIPO 10 \n\n " + e.Message);
            }
        }
        /*
        public void set3_Datas(DateTime dtInicial, DateTime dtFinal)
        {
            this.dtInicial = dtInicial;
            this.dtFinal = dtFinal;
            Program.dtInicial = dtInicial;
            //Program.dtFinal = dtFinal;
        }
        */
        #endregion

        private void valida()
        {
            if (!Functions.ValidaCNPJ(cgc_mf.ToString()))
                throw new Exception("TIPO 10 \n\n CGC inválido " +cgc_mf.ToString());
            if (municipio.Length < 3)
                throw new Exception("TIPO 10 \n\n Municipio menor que 3 caracteres");
            if (nome_contrib.Length < 3)
                throw new Exception("TIPO 10 \n\n Nome do Contribuinte menor que 3 caracteres");

            if (fax.ToString().Length != 10 && fax.ToString().Length != 0 )
                throw new Exception("TIPO 10 \n\n Fax precisa ter 10 caracteres, você pode optar por não preenchê-lo... fax.length: "+fax.ToString());

            if (dtFinal.Year < 2000)
                throw new Exception("TIPO 10 \n\n Data Final anterior ao ano 2000");
            if (dtInicial.Year < 2000)
                throw new Exception("TIPO 10 \n\n Data Inicial anterior ao ano 2000");
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo10(cgc_mf, ie.IE, nome_contrib, municipio, ie.UF,
                fax, dtInicial, dtFinal,
                codEstrutura, codNatureza, codFinalidade);
        }
    }
}
