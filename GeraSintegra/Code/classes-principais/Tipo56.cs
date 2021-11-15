using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo56 : Tipo
    {
        public Tipo56(
            long cnpj_cpf,
            int modelo_nf, string serie_nf, int numero_nf,
            long cfop, int cst,
            int numero_ordinal_linha, string cod_item,
            int tipo_operacao,
            long cnpj_concessionaria,
            double aliquotaIPI, string chassi
            )
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(56)
                );
            campos.Add(//CNPJ
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj_cpf)
                );
            campos.Add(//CNPJ
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj_cpf)
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
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cod_item)
                );
            campos.Add(//tipo operacao
                new Campo(1, EnumFormato.NUMEROS)
                .appendValor(tipo_operacao)
                );
            campos.Add(//cnpj concessionária
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj_concessionaria)
                );
            campos.Add(//aliquota IPI
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(aliquotaIPI)
                );
            campos.Add(//chassi
                new Campo(17, EnumFormato.NUMEROS)
                .appendValor(chassi)
                );
            campos.Add(//brancos
                new Campo(39, EnumFormato.ALPHA)
                .appendValor("")
                );

        }
    }
}