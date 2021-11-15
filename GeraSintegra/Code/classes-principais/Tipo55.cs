using System;
namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo55 : Tipo
    {
        public Tipo55(
            long cnpj_cpf, string inscrEstadual_substituto, string uf_substituto, string uf_favorecida,
            DateTime dtGNRE, int bancoGNRE, int agenciaGNRE, string numeroAutenticacaoGNRE, double valorGNRE,
            DateTime dtVencimento, int mes_referencia, int ano_referencia,
            string protocoloGNRE)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(55)
                );
            campos.Add(//CNPJ
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj_cpf)
                );
            campos.Add(//INSC EST
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(inscrEstadual_substituto)
                );
            campos.Add(//DT GNRE
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtGNRE)
                );
            campos.Add(//UF substituto
                new Campo(2, EnumFormato.ALPHA)
                .appendValor(uf_substituto)
                );
            campos.Add(//UF favorecida
                new Campo(2, EnumFormato.ALPHA)
                .appendValor(uf_favorecida)
                );
            campos.Add(//banco GNRE
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(bancoGNRE)
                );
            campos.Add(//agencia GNRE
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(agenciaGNRE)
                );
            campos.Add(//numero GNRE
                new Campo(20, EnumFormato.ALPHA)
                .appendValor(numeroAutenticacaoGNRE)
                );
            campos.Add(//DT VENCIMENTO
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtVencimento)
                );
            campos.Add(//mes referencia
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(mes_referencia)
                );
            campos.Add(//ano referencia
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(ano_referencia)
                );
            campos.Add(//protocoloGNRE
                new Campo(30, EnumFormato.ALPHA)
                .appendValor(protocoloGNRE)
                );

        }
    }
}