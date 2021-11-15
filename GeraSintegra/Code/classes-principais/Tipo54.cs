using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo54 : Tipo
    {
        public Tipo54(
            long cnpj,
            int modelo_nf, string serie_nf, int numero_nf,
            long cfop, int cst,
            int numero_ordinal_linha, string cod_item,
            double quantidade,
            double valor_total_linha, double valor_desconto,
            double bcICMS, double bcICMS_substituicao,
            double valorIPI, double aliquotaICMS)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(54)
                );
            campos.Add(//CNPJ
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj)
                );
            campos.Add(//MODELO NF
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(modelo_nf)
                );
            campos.Add(//SERIE NF
                new Campo(3, EnumFormato.ALPHA)
                .appendValor(serie_nf)
                );
            campos.Add(//NUMERO NF
                new Campo(6, EnumFormato.NUMEROS)
                .appendValor(numero_nf)
                );
            campos.Add(//CFOP
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(cfop)
                );
            campos.Add(//CST
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(cst)
                );
            campos.Add(//numero da ordem do item na nota
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(numero_ordinal_linha)
                );
            campos.Add(//codigo do p/s do informante
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(cod_item)
                );
            campos.Add(//QUANTIDADE
                new Campo(11, EnumFormato.NUMEROS)
                .appendValor(quantidade,3)//aumento 1 decimal, agora tem 3
                );
            campos.Add(//VALOR DO ITEM (Vunit * Q)
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(valor_total_linha)
                );
            campos.Add(//VALOR DO DESCONTO SOBRE A VENDA
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(valor_desconto)
                );
            campos.Add(//BASE DE CALCULO DO ICMS
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(bcICMS)
                );
            campos.Add(//VALOR DO ICMS PARA SUBST
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(bcICMS_substituicao)
                );
            campos.Add(//VALOR DO IPI
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(valorIPI)
                );
            campos.Add(//ALIQUOTA DO ICMS
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(aliquotaICMS)
                );

        }
    }
}