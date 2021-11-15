using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo11 : IConstrutorTipo
    {
        #region atributos

        string logradouro;
        int numero;
        string complemento;
        string bairro;
        long cep;
        string contato_nome;
        long contato_fone;

        #endregion

        public ConstrutorTipo11()
        {

        }

        #region métodos

        public void setContato(string nome, string fone)
        {
            this.contato_nome = nome;
            this.contato_fone = long.Parse(Functions.SoNumero(fone));
        }

        public void setEndereco(string logradouro, string numero, string complemento,
            string bairro, string cep)
        {
            this.logradouro = logradouro;
            this.numero = int.Parse(Functions.SoNumero(numero));
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = long.Parse(Functions.SoNumero(cep));
        }
        
        #endregion

        private void valida()
        {
            if (numero < 1)
                throw new Exception("TIPO 11 \n\n Endereço.numero de sua empresa inválido, preencha um número maior que zero");
            if (logradouro.Length < 2)
                throw new Exception("TIPO 11 \n\n Logradouro menor que 2 caracteres");
            if (bairro.Length < 2)
                throw new Exception("TIPO 11 \n\n Bairro menor que 2 caracteres");
            if (contato_fone.ToString().Length != 10)
                throw new Exception("TIPO 11 \n\n Telefone precisa ter 10 caracteres");
            if (cep.ToString().Length != 8)
                throw new Exception("TIPO 11 \n\n CEP precisa ter 8 caracteres");
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo11(logradouro, numero, complemento, bairro,
                cep, contato_nome, contato_fone);
        }

    }
}
