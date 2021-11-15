using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo75 : IConstrutorTipo
    {
        #region atributos
        DateTime dtInicial;
        DateTime dtFinal;
        string codigoProduto;
        string codigoProdutoMercosul;
        string descricao;
        string unidMed;
        int cst_interno;
        double aliquotaIPI;
        double aliquotaICMS;
        double reducaoBcICMS;
        double bcICMS;
        #endregion

        public ConstrutorTipo75()
        {
            codigoProdutoMercosul = "";
            this.dtInicial = Program.dtInicial;
            this.dtFinal = Program.dtFinal;
        }

        #region métodos

        public void set1_dadosInternos(int codigoProduto, string descricao, string unidMed, string cst_interno)
        {
            this.codigoProduto = codigoProduto.ToString();
            this.cst_interno = int.Parse(Functions.SoNumero(cst_interno));
            this.unidMed = Functions.FiltraDigitosValidos(unidMed);
            this.descricao = Functions.FiltraDigitosValidos(descricao);
        }

        public void set2_impostos(double aliquotaIPI, double aliquotaICMS, double reducaoBcICMS, double bcICMS)
        {
            this.aliquotaIPI = Functions.modulo(aliquotaIPI);
            this.aliquotaICMS = Functions.modulo(aliquotaICMS);
            this.reducaoBcICMS = Functions.modulo(reducaoBcICMS);
            this.bcICMS = Functions.modulo(bcICMS);
        }

        #endregion

        private void valida()
        {
            
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo75(dtInicial, dtFinal,
                codigoProduto, codigoProdutoMercosul,
                descricao, unidMed, cst_interno,
                aliquotaIPI, aliquotaICMS, reducaoBcICMS, bcICMS);
        }

    }
}