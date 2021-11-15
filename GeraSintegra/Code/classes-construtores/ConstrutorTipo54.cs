using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo54 : IConstrutorTipo
    {
        #region atributos
        long cnpj;
        int modelo_nf;
        string serie_nf;
        int numero_nf;
        long cfop;
        int cst;
        int numero_ordinal_linha;
        string cod_item;
        double quantidade;
        double valor_total_linha;
        double valor_desconto;
        double bcICMS;
        double bcICMS_substituicao;
        double valorIPI;
        double aliquotaICMS;
        #endregion

        public ConstrutorTipo54()
        {
            this.modelo_nf = 1;
            this.serie_nf = "2";
        }

        #region métodos
        public void set1_NotaFiscal(int numero_nf, string cnpj, string cfop, string cst)
        {
            this.numero_nf = numero_nf;
            this.cnpj = long.Parse(Functions.SoNumero(cnpj));
            this.cfop = long.Parse(Functions.SoNumero(cfop));
            this.cst = int.Parse(Functions.SoNumero(cst));
        }

        public void set2_BasicoItem(int numero_ordinal_linha, int cod_item)
        {
            this.numero_ordinal_linha = numero_ordinal_linha;
            this.cod_item = cod_item.ToString();
        }

        public void set3_DadosItem(double quantidade, double valor_total_linha, double valor_desconto)
        {
            this.quantidade = quantidade;
            this.valor_total_linha = valor_total_linha;
            this.valor_desconto = valor_desconto;
        }

        public void set4_Valores(double bcICMS, double bcICMS_substituicao, double valorIPI, double aliquotaICMS)
        {
            this.bcICMS = Functions.modulo(bcICMS);
            this.bcICMS_substituicao = Functions.modulo(bcICMS_substituicao);
            this.valorIPI = Functions.modulo(valorIPI);
            this.aliquotaICMS = Functions.modulo(aliquotaICMS);
        }
        #endregion

        private void valida()
        {
            /*
            if ((cnpj.ToString().Contains("000")))
            {
                if (!Functions.ValidaCNPJ(cnpj.ToString()))
                    throw new Exception("TIPO 54 \n\n CNPJ inválido " + cnpj.ToString() + "\n\n nota / item: " + numero_nf.ToString() + " / " + numero_ordinal_linha.ToString());
            }
            else
            {
                if (!Functions.ValidaCPF(cnpj.ToString()))
                    throw new Exception("TIPO 54 \n\n CNPJ inválido " + cnpj.ToString() + "\n\n nota / item: " + numero_nf.ToString() + " / " + numero_ordinal_linha.ToString());
            }
            */

            if (cfop <= 0)
                throw new Exception("TIPO 54 \n\n CFOP da nota inválido: " +numero_nf.ToString());
            if (quantidade <= 0)
                throw new Exception("TIPO 54 \n\n QUANTIDADE inválida");
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo54(
                cnpj, modelo_nf, serie_nf, numero_nf,
                cfop, cst,
                numero_ordinal_linha, cod_item,
                quantidade,
                valor_total_linha, valor_desconto,
                bcICMS, bcICMS_substituicao,
                valorIPI, aliquotaICMS);
        }

    }
}