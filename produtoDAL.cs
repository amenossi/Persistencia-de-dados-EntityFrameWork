using Microsoft.Data.SqlClient;
using EstoqueFacil.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EstoqueFacil.Banco
{
    public class ProdutoDAL
    {

        protected readonly Connection context;
        protected ProdutoDAL(Connection context)
        {
            this.context = context;
        }
        public ProdutoDAL(): this(new Connection())
        {

        }
        public void adicionarProduto(Produto produto)
        {
            context.tbl_Produtos.Add(produto);
            context.SaveChanges();
            Console.WriteLine("Item salvo com sucesso");
            Console.ReadKey();
        }
        public void adcionarProdExistente(Produto produto)
        {
            var product = context.tbl_Produtos.FirstOrDefault(p => p.Id == produto.Id);
            
            if (product != null)
            {
                product.quantidade += produto.quantidade;
                context.SaveChanges();
            }
        }
        public void subtraiItem(Produto produto)
        {
            var product = context.tbl_Produtos.Find(produto.Id);
            if (product != null)
            {
                product.quantidade -= produto.quantidade;
                context.SaveChanges();
            }
        }
        public void getProdutos(out List<Produto> produtos)
        {
            produtos = new List<Produto>();
            foreach (Produto produto in context.tbl_Produtos)
            {
                produtos.Add(produto);
            }
        }
        public void deleteProduto(int id)
        {
            var product = context.tbl_Produtos.Find(id);
            if (product != null)
            {
                context.tbl_Produtos.Remove(product);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
            
        }
        public void updateProduto(Produto produto)
        {
            var product = context.tbl_Produtos.Find(produto.Id);
            if (product != null)
            {
                product.descricao = produto.descricao;
                product.valor = produto.valor;
                product.quantidade = produto.quantidade;

                context.SaveChanges();
                Console.WriteLine("Item atualizado com sucesso.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Produto nao encontrado");
                Console.ReadKey();
            }
        }
        public int validaID(int id)
        {
            var product = context.tbl_Produtos.FirstOrDefault(p => p.Id == id);

            if(product != null)
            {
                return 1;
            }
            return 0;
        }
        public void pesquisaItem(string item)
        {
            var produto = context.tbl_Produtos.FirstOrDefault(p => p.descricao == item);
            if (produto != null)
            {
                Console.WriteLine($"ID: {produto.Id} Descricao: {produto.descricao} Valor: {produto.valor} Quantidade: {produto.quantidade}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
                Console.ReadKey();
            }
        }
    }
}
