using EasyWeightLoss.DAL.Interfaces;
using EasyWeightLoss.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWeightLoss.Services
{
    class ProductManager
    {
        IRepositories<Product> productRepository;

        public ProductManager(IRepositories<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Create(Product product)
        {
            if (product != null)
            {
                if (productRepository.Get(p => p.Name == product.Name).Count() != 0)
                    throw new Exception("Такой продукт уже есть");
                if (product.Name.Length == 0)
                    throw new Exception("Нет названия");
                if (product.EnergyValue <= 0)
                    throw new Exception("Неположительная энергетическая емкость");
                productRepository.Create(product);
            }
        }
        public IEnumerable<Product> GetAll()
        {
            return productRepository.Get();
        }
        public void Delete(Product product)
        {
            productRepository.Remove(product);
        }
        public void Dispose()
        {
            productRepository.Dispose();
        }

    }
}
