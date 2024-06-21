using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usineJusFruit.Model.Production
{
    public class ProductsCollection : ObservableCollection<Product>
    {
        public ProductsCollection() { }

        public new void AddProduct(Product pd)
        {
            if (!this.Any(ProductInTheCollection => ProductInTheCollection.Id == pd.Id ))
            {
                this.Add(pd);
            }
            else
            {
            } //id product is already in the collection and will not be added.
        }


        public void DeleteProduct(Product pd)
        {
            if (this.Contains(pd))
            {
                this.Remove(pd);
            }
        }





    }
}
