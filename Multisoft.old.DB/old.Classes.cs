using System;
using System.Collections;
using System.Collections.Generic;

namespace Multisoft.old.DB
{
    public class Empresa
    {
        #region atributos
        int _idEmpresa;
        string _nomefantasia;
        string _razaosocial;
        string _cnpj;
        string _ie;
        string _uf;
        string _cidade;
        string _endereco;
        string _numero;
        string _bairro;
        string _complemento;
        string _cep;
        string _responsavel;
        string _telefone;
        string _fax;
        #endregion

        #region get set
        public virtual int idEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }
        public virtual string nomefantasia
        {
            get { return _nomefantasia; }
            set { _nomefantasia = value; }
        }
        public virtual string razaosocial
        {
            get { return _razaosocial; }
            set { _razaosocial = value; }
        }
        public virtual string cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }
        public virtual string ie
        {
            get { return _ie; }
            set { _ie = value; }
        }
        public virtual string uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
        public virtual string cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        public virtual string endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        public virtual string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public virtual string bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        public virtual string complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }
        public virtual string cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        public virtual string responsavel
        {
            get { return _responsavel; }
            set { _responsavel = value; }
        }
        public virtual string telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        public virtual string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        #endregion
    }

    public class LinhaMovMerc
    {
        #region atributos
        int _idMov;
        string _nome_movimento;
        DateTime _data;
        int _num_nota;
        string _cancelado;
        double _valor;
        string _cfop;
        string _tipo_movimento;
        double _frete;
        double _seguro;
        double _outras;
        double _ipi;
        IList<LinhaMovMercItem> _itens;
        Cliente _cliente;
        #endregion

        public virtual bool isClienteInvalido()
        {
            return _cliente == null;
        }


        #region get set
        public virtual int idMov
        {
            get { return _idMov; }
            set { _idMov = value; }
        }
        public virtual string nome_movimento
        {
            get { return _nome_movimento; }
            set { _nome_movimento = value; }
        }
        public virtual DateTime data
        {
            get { return _data; }
            set { _data = value; }
        }
        public virtual int num_nota
        {
            get { return _num_nota; }
            set { _num_nota = value; }
        }
        public virtual string cancelado
        {
            get { return _cancelado; }
            set { _cancelado = value; }
        }
        public virtual double valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public virtual string cfop
        {
            get { return _cfop; }
            set { _cfop = value; }
        }
        public virtual string tipo_movimento
        {
            get { return _tipo_movimento; }
            set { _tipo_movimento = value; }
        }
        public virtual double frete
        {
            get { return _frete; }
            set { _frete = value; }
        }
        public virtual double seguro
        {
            get { return _seguro; }
            set { _seguro = value; }
        }
        public virtual double outras
        {
            get { return _outras; }
            set { _outras = value; }
        }
        public virtual double ipi
        {
            get { return _ipi; }
            set { _ipi = value; }
        }


        public virtual IList<LinhaMovMercItem> itens
        {
            get { return _itens; }
            set { _itens = value; }
        }
        public virtual Cliente cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        #endregion
    }

    public class Cliente
    {
        #region atributos
        int _idCliente;
        string _pessoa;
        string _rg;
        string _cpf;
        string _estado;
        #endregion
        
        #region get set
        public virtual int idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        public virtual string pessoa
        {
            get { return _pessoa; }
            set { _pessoa = value; }
        }
        public virtual string rg
        {
            get { return _rg; }
            set { _rg = value; }
        }
        public virtual string cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public virtual string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion
    }

    public class LinhaMovMercItem
    {
        #region atributos
        int _idItem;
        LinhaMovMerc _movimento;
        string _nome_movimento;
        double _quantidade;
        double _precoU;
        double _total;
        double _desconto;
        double _qtd_devolvida;
        double _ipi_percent;
        Produto _dadosProduto;
        #endregion

        #region get set
        public virtual int idItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }
        public virtual LinhaMovMerc movimento
        {
            get { return _movimento; }
            set { _movimento = value; }
        }
        public virtual string nome_movimento
        {
            get { return _nome_movimento; }
            set { _nome_movimento = value; }
        }
        public virtual double quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        public virtual double precoU
        {
            get { return _precoU; }
            set { _precoU = value; }
        }
        public virtual double total
        {
            get { return _total; }
            set { _total = value; }
        }
        public virtual double desconto
        {
            get { return _desconto; }
            set { _desconto = value; }
        }
        public virtual double qtd_devolvida
        {
            get { return _qtd_devolvida; }
            set { _qtd_devolvida = value; }
        }
        public virtual double ipi_percent
        {
            get { return _ipi_percent; }
            set { _ipi_percent = value; }
        }
        public virtual Produto dadosProduto
        {
            get { return _dadosProduto; }
            set { _dadosProduto = value; }
        }
        #endregion
    }

    public class Produto
    {
        #region atributos
        int _idProduto;
        double _aliquota;
        string _unidMed;
        string _cst_dentro_uf;
        string _cst_fora_uf;
        double _redutor_dentro_uf;
        double _redutor_fora_uf;
        string _servico;//TF
        double _ipi;
        string _nome;
        string _codigoOriginal;
        double _p_venda;
        #endregion

        #region get set
        public virtual int idProduto
        {
            get { return _idProduto; }
            set { _idProduto = value; }
        }
        public virtual double aliquota
        {
            get { return _aliquota; }
            set { _aliquota = value; }
        }
        public virtual string unidMed
        {
            get { return _unidMed; }
            set { _unidMed = value; }
        }
        public virtual string cst_dentro_uf
        {
            get { return _cst_dentro_uf; }
            set { _cst_dentro_uf = value; }
        }
        public virtual string cst_fora_uf
        {
            get { return _cst_fora_uf; }
            set { _cst_fora_uf = value; }
        }
        public virtual double redutor_dentro_uf
        {
            get { return _redutor_dentro_uf; }
            set { _redutor_dentro_uf = value; }
        }
        public virtual double redutor_fora_uf
        {
            get { return _redutor_fora_uf; }
            set { _redutor_fora_uf = value; }
        }
        public virtual string servico
        {
            get { return _servico; }
            set { _servico = value; }
        }
        public virtual double ipi
        {
            get { return _ipi; }
            set { _ipi = value; }
        }
        public virtual string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public virtual string codigoOriginal
        {
            get { return _codigoOriginal; }
            set { _codigoOriginal = value; }
        }
        public virtual double p_venda
        {
            get { return _p_venda; }
            set { _p_venda = value; }
        }
        #endregion
        /*
        public virtual int 
        {
            get { return _; }
            set { _ = value; }
        }
        */
    }
}
/*
    public class A
    {
        int _;
        public virtual int 
        {
            get { return _; }
            set { _ = value; }
        }
    }
 */