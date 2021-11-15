using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo75 : Tipo
    {
        public Tipo75(DateTime dtInicial, DateTime dtFinal, string codigoProduto,
            string codigoProdutoMercosul, string descricao, string unidMed,
            int cst_interno, double aliquotaIPI, double aliquotaICMS, double reducaoBcICMS, double bcICMS)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(75)
                );
            campos.Add(//2
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtInicial)
                );
            campos.Add(//3
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtFinal)
                );
            campos.Add(//4
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(codigoProduto)
                );
            campos.Add(//5
                new Campo(8, EnumFormato.ALPHA)
                .appendValor(codigoProdutoMercosul)
                );
            campos.Add(//6
                new Campo(53, EnumFormato.ALPHA)
                .appendValor(descricao)
                );
            campos.Add(//7
                new Campo(6, EnumFormato.ALPHA)
                .appendValor(unidMed)
                );
            /*
            campos.Add(//8
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(cst_interno)
                );
            campos.Add(//9
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(aliquotaIPI)
                );
            campos.Add(//10
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(aliquotaICMS)
                );
            campos.Add(//11
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(reducaoBcICMS)
                );
            */
            campos.Add(//9
                new Campo(5, EnumFormato.NUMEROS)
                .appendValor(aliquotaIPI)
                );
            campos.Add(//10
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(aliquotaICMS)
                );
            campos.Add(//11
                new Campo(5, EnumFormato.NUMEROS)
                .appendValor(reducaoBcICMS)
                );
            campos.Add(//12
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(bcICMS)
                );

        }

    }
}