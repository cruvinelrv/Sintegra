using System;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo11 : Tipo
    {
        public Tipo11(
            string logradouro, int numero, string complemento, string bairro,
            long cep, string contato_nome, long contato_fone)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(11)
                );
            campos.Add(//LOGRADOURO
                new Campo(34, EnumFormato.ALPHA)
                .appendValor(logradouro)
                );
            campos.Add(//NUMERO
                new Campo(5, EnumFormato.NUMEROS)
                .appendValor(numero)
                );
            campos.Add(//COMPLEMENTO
                new Campo(22, EnumFormato.ALPHA)
                .appendValor(complemento)
                );
            campos.Add(//BAIRRO
                new Campo(15, EnumFormato.ALPHA)
                .appendValor(bairro)
                );
            campos.Add(//CEP
                new Campo(8, EnumFormato.NUMEROS)
                .appendValor(cep)
                );
            campos.Add(//NOME
                new Campo(28, EnumFormato.ALPHA)
                .appendValor(contato_nome)
                );
            campos.Add(//FONE
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(contato_fone)
                );
        }
    }
}