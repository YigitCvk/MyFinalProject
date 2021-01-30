using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        //Çıplak class kalmasın-->eğer bir class inharetince almıyorsa ilerde hata vermesi olası.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
