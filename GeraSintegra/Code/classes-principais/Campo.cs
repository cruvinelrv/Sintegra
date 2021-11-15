using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Campo
    {
        //public string nome;
        private string _valor="";//10,11,50.... OU "rua itagiba gonzaga" OU "12.99"
        private int _largura;
        private EnumFormato _formato;
        //public int casasDecimais = 2;

        public int largura
        {
            get
            {
                return _largura;
            }
        }
        public EnumFormato formato
        {
            get
            {
                return _formato;
            }
        }

        public Campo(int largura, EnumFormato formato)//, string _valor, int casasDecimais
        {
            if (largura <= 0)
                throw new ExcecaoLargura(largura);

            //this.nome    = nome; //nome é inútil, mas vou pedir mesmo assim...
            this._largura = largura;
            this._formato = formato;
            //this._valor   = _valor; //seria legal ter outros formatos, data, numero, decimal, talvez Object com vários setters
            //this.casasDecimais  = casasDecimais; sempre 2
            //this. = ;
        }
        public Campo appendValor(long valor)
        {
            if (this.formato != EnumFormato.NUMEROS)
                throw new ExcecaoFormatoDoCampo(EnumFormato.NUMEROS, this.formato);
            this._valor = valor.ToString();
            alinhaNumeros();
            return this;
        }
        public Campo appendValor(string valor)
        {
            if (this.formato != EnumFormato.ALPHA)
                throw new ExcecaoFormatoDoCampo(EnumFormato.ALPHA, this.formato);
            this._valor = valor;
            alinhaAlpha();
            return this;
        }
        public Campo appendValor(Double valor)
        {
            if (this.formato != EnumFormato.NUMEROS)
                throw new ExcecaoFormatoDoCampo(EnumFormato.NUMEROS, this.formato);

            long lValor = (long)Math.Truncate(valor * 100);
            this._valor = lValor.ToString();
            alinhaNumeros();
            return this;
        }
        public Campo appendValor(Double valor, int casas_decimais)
        {
            if (this.formato != EnumFormato.NUMEROS)
                throw new ExcecaoFormatoDoCampo(EnumFormato.NUMEROS, this.formato);

            long lValor = (long)Math.Truncate(valor * (10 ^ casas_decimais));
            this._valor = lValor.ToString();
            alinhaNumeros();
            return this;
        }
        public Campo appendValor(DateTime valor)
        {
            if (this.formato != EnumFormato.DATA)
                throw new ExcecaoFormatoDoCampo(EnumFormato.DATA, this.formato);
            this._valor = string.Format("{0:yyyyMMdd}", valor);
            return this;
        }

        private string alinhaAlpha()
        {
            string s =
                (_valor.Length > largura)
                ? _valor.Substring(0, largura)
                : _valor;
            return s.PadRight(largura, ' ').ToUpper(); 
        }

        private string alinhaNumeros()
        {
            string s =
                (_valor.Length > largura)
                ? _valor.Substring(0, largura)
                : _valor;
            return s.PadLeft(largura, '0');
        }

        public override string ToString()
        {
            //tratar formato, espaços brancos/texto truncado, preenchimento de zeros, casas decimais
            switch (this.formato)
            {
                case EnumFormato.ALPHA:
                    return this.alinhaAlpha();
                case EnumFormato.NUMEROS:
                    return this.alinhaNumeros();
                case EnumFormato.DATA:
                    return this._valor;//não precisamos tratar datas, pois sempre tem 8 digitos
                default:
                    throw new Exception("Formato de Campo não tratado: " + this.formato.ToString());
            }
        }
    }
}
